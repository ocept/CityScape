using UnityEngine;
using System.Collections;

public class SpawnEnvironment : MonoBehaviour {
	
	public Transform scraper;
	protected int spawnBoundary = 500;
	protected int gridSeparation = 100;
	protected int gridSize = 1000;
	// Use this for initialization
	void Start () 
	{
		ScraperStore = new AssemblyCSharp.scraperStore();
	}
	private AssemblyCSharp.scraperStore ScraperStore;
	// Update is called once per frame
	void Update () 
	{
		spawnSurroundings(); //TODO: should only be called when camera has moved into new area
	}
	void spawnSurroundings()
	{

		float kx = gameObject.transform.localPosition.x;
		float kz = gameObject.transform.localPosition.z;
		int ikx = Mathf.FloorToInt(kx/gridSize)*gridSize;
		int ikz = Mathf.FloorToInt(kz/gridSize)*gridSize;
		
		for(int jkx = ikx - gridSize; jkx <= ikx + gridSize; jkx += gridSize)
		{
			for(int jkz = ikz - gridSize; jkz <= ikz + gridSize; jkz += gridSize){
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
		Vector3 spawnPos = new Vector3(x, 20, z);
		int heightVar = ScraperStore.getHeight(x, z);

		scraper.transform.localScale = new Vector3(25,100 + heightVar, 25);
		spawnPos.y += heightVar/2;
		var scrape = Instantiate(scraper, spawnPos, Quaternion.identity);
		scrape.name = (x.ToString()+","+z.ToString());
	}
}
