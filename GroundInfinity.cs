using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundInfinity : MonoBehaviour {
	//private GameObject cameraPos = Camera.mainCamera.gameObject.transform.position;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Camera.main.gameObject.transform.position.x > transform.position.x + (transform.localScale.x * 2)) {
			transform.localPosition = new Vector3 (transform.position.x + (transform.localScale.x * 3), transform.position.y, transform.position.z);
		}
		else if (Camera.main.gameObject.transform.position.x < transform.position.x - (transform.localScale.x * 2)) {
			transform.localPosition = new Vector3 (transform.position.x - (transform.localScale.x * 3), transform.position.y, transform.position.z);
		}
	}
}
