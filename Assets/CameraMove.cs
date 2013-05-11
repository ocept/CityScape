using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
	
	float mSpeed;
	float sumRot;
	// Use this for initialization
	void Start () {
		mSpeed = 0;
		sumRot = 0;
	}
	
	// Update is called once per frame
	void Update () {
		float rot = Input.GetAxis ("Horizontal")/50;
		sumRot += rot;
		
		transform.RotateAround(new Vector3(0,1,0),rot);
		
		//mSpeed *= 0.98f;
		if(Input.GetAxis ("Vertical") != 0)
	    	mSpeed += Input.GetAxis("Vertical") * Time.deltaTime * 8;
		else mSpeed *= 0.90f;
		
        transform.position += new Vector3(Mathf.Sin(sumRot)*mSpeed, 0, Mathf.Cos(sumRot)*mSpeed);
	}
}
