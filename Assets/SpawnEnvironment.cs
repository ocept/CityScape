using UnityEngine;
using System.Collections;

public class SpawnEnvironment : MonoBehaviour {
	protected GameObject[] scraper;
	protected GameObject scraperGroup;
	protected int spawnBoundary = 250;
	protected int gridSeparation = 100;
	protected int gridSize = 500;
	protected Vector3 camLocationLastSpawn;
	public const string TowerPath = "Towers";
	// Use this for initialization
	void Start () 
	{
		//load scrapers
		Object[] loadedScrapers = Resources.LoadAll(TowerPath, typeof(UnityEngine.GameObject));
		scraper = new GameObject[loadedScrapers.Length];
		for(int i = 0; i < loadedScrapers.Length; i++)
		{
			scraper[i] = (GameObject) loadedScrapers[i];
		}
		
		scraperGroup = new GameObject("Scrapers");
		ScraperStore = new AssemblyCSharp.scraperStore();
		spawnSurroundings();
		camLocationLastSpawn = gameObject.camera.transform.position;
	}
	private AssemblyCSharp.scraperStore ScraperStore;
	// Update is called once per frame
	void Update () 
	{
		if(gameObject.camera.transform.position.x < camLocationLastSpawn.x - gridSize ||
			gameObject.camera.transform.position.x > camLocationLastSpawn.x + gridSize ||
			gameObject.camera.transform.position.z < camLocationLastSpawn.z - gridSize ||
			gameObject.camera.transform.position.z > camLocationLastSpawn.z + gridSize)
		{
			spawnSurroundings();
			camLocationLastSpawn = gameObject.camera.transform.position;
		}
	}
	void spawnSurroundings()
	{

		float kx = gameObject.transform.localPosition.x;
		float kz = gameObject.transform.localPosition.z;
		int ikx = Mathf.FloorToInt(kx/gridSize)*gridSize;
		int ikz = Mathf.FloorToInt(kz/gridSize)*gridSize;
		
		for(int jkx = ikx - 3*gridSize; jkx <= ikx + 4*gridSize; jkx += gridSize)
		{
			for(int jkz = ikz - 3*gridSize; jkz <= ikz + 4*gridSize; jkz += gridSize){
					drawGrid(jkx, jkz);
			}		
		}
	}
	int drawGrid(int ikx, int ikz)
	{
		if(!ScraperStore.isGridDrawn(ikx, ikz))
		{
			for(int i = ikx - spawnBoundary; i < ikx + spawnBoundary; i+= gridSeparation)
			{
				for(int j = ikz -spawnBoundary; j < ikz + spawnBoundary; j+= gridSeparation)
				{
						spawnScraper(i,j);
				}
			}
			ScraperStore.markGridDrawn(ikx,ikz);
			return 1;
		}
		else return 0;
	}
	void spawnScraper(int x, int z)
	{	
		Vector3 spawnPos = new Vector3(x, 0, z);
		int heightVar = ScraperStore.getHeight(x, z);
		int scraperType = Random.Range(0, scraper.Length);
		scraper[scraperType].transform.localScale = new Vector3(25,heightVar, 25);
		//spawnPos.y = (scraper.renderer.bounds.size.y)/2;
		spawnPos.y = (float) (scraper[scraperType].transform.localScale.y * 1.111); //TODO: figure out why the *1.1 is necessary
		//spawnPos.y += (heightVar/2) * scraperBaseHeight;
		GameObject scrape = Object.Instantiate(scraper[scraperType], spawnPos, Quaternion.identity) as GameObject;
		scrape.name = (x.ToString()+","+z.ToString());
		//scrape.parent = scraperGroup.transform;
		//scrape.transform.parent = scraperGroup.transform;
	}
}
