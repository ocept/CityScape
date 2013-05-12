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
		float kx = gameObject.transform.localPosition.x;
		float kz = gameObject.transform.localPosition.z;
		int ikx = Mathf.FloorToInt(kx/100)*100;
		int ikz = Mathf.FloorToInt(kz/100)*100;
		if(GameObject.Find((ikx + 20).ToString()+","+ikz.ToString())== null){
			spawnScraper(ikx + 20,ikz);
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
