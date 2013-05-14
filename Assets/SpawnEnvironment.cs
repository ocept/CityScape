using UnityEngine;
using System.Collections;

public class SpawnEnvironment : MonoBehaviour {
	
	public Transform scraper;

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
		int spawnBoundary = 500;
		int gridSize = 1000;
		int gridSeparation = 100;
		float kx = gameObject.transform.localPosition.x;
		float kz = gameObject.transform.localPosition.z;
		int ikx = Mathf.FloorToInt(kx/gridSize)*gridSize;
		int ikz = Mathf.FloorToInt(kz/gridSize)*gridSize;
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
		}
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
