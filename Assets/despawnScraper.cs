using UnityEngine;
using System.Collections;

public class despawnScraper : MonoBehaviour {
	
	private int despawnPoint;
	// Use this for initialization
	void Start () {
		despawnPoint = 5000;
	}
	
	// Update is called once per frame
	void Update () {
		if(Camera.main.transform.position.x < transform.position.x - despawnPoint ||
		Camera.main.transform.position.x > transform.position.x + despawnPoint ||
		Camera.main.transform.position.z < transform.position.z - despawnPoint ||
		Camera.main.transform.position.z > transform.position.z + despawnPoint)
		{
			Destroy(gameObject);
		}
	}
}
