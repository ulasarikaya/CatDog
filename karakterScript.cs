using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karakterScript : MonoBehaviour {

	public int rotationSpeed;
	private int updateInterval;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale == 1) {
			updateInterval = updateInterval + 1;
			if (updateInterval % 10 == 0) {
				rotationSpeed = -rotationSpeed;
			}
		}
		transform.Rotate (Vector3.forward * (rotationSpeed * Time.deltaTime));
	}
}
