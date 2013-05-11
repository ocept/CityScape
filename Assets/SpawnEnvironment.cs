using UnityEngine;
using System.Collections;

public class SpawnEnvironment : MonoBehaviour {
	
	public Transform scraper;
	private float nextSpawnTime = 0.0f;
	private float spawnRate = 1.5f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(nextSpawnTime < Time.time)
		{
			nextSpawnTime = Time.time + spawnRate;
			spawnScraper();
		}
		double kx = gameObject.transform.localPosition.x;
		double kz = gameObject.transform.localPosition.z;
		//kx = Mathf.Floor(kx/10)*10;
		//kz = Mathf.Floor(kz/10)*10;
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
