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
		float kx = gameObject.transform.localPosition.x;
		float kz = gameObject.transform.localPosition.z;
		int ikx = Mathf.FloorToInt(kx/100)*100;
		int ikz = Mathf.FloorToInt(kx/100)*100;
		spawnScraper(ikx + 20,ikz);
	}
	void spawnScraper(int x, int z)
	{
		Vector3 spawnPos = new Vector3(x, 20, z);
		int heightVar = ScraperStore.getHeight(x, z);
		
		scraper.transform.localScale = new Vector3(25,100 + heightVar, 25);
		spawnPos.y += heightVar/2;
		Instantiate(scraper, spawnPos, Quaternion.identity);
	}
	void spawnScraper()
	{
		Vector3 spawnPos = new Vector3(250, 20, -100) + new Vector3(Random.Range(-50, 50), 0 , Random.Range(-50, 50));
		int heightVar = Random.Range(-20, 50);
		scraper.transform.localScale = new Vector3(25,100 + heightVar, 25);
		spawnPos.y += heightVar/2;
		Instantiate(scraper, spawnPos, Quaternion.identity);
	}
}
