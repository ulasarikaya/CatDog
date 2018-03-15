using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodCanisBig : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if 		(Camera.main.gameObject.transform.position.x > transform.position.x + (transform.localScale.x * 220)) {
			transform.localPosition = new Vector3 (Camera.main.gameObject.transform.position.x + (transform.localScale.x * 30), transform.position.y, transform.position.z);
		}
		else if (Camera.main.gameObject.transform.position.x < transform.position.x - (transform.localScale.x * 220)) {
			transform.localPosition = new Vector3 (Camera.main.gameObject.transform.position.x + (transform.localScale.x * 30), transform.position.y, transform.position.z);
		}
	}
}
