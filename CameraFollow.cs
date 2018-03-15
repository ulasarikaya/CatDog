using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public Transform target;
	public GameObject felisEtCanis;
	public FelisEtCanisController felisEtCanisScript;
	private bool canisActive;
	private bool reportedOnce = false;
	private bool animationComplete = false;
	private float switchCanisAnimation = 15.5f;
	private float switchFelisAnimation = -16.5f;
	private float currentPos = 15.5f;
	private float targetPos = 15.5f;
	// Use this for initialization
	void Start () {
		GameObject FelisEtCanisObject = GameObject.Find("FelisEtCanis");
//		FelisEtCanisController felisEtCanisScript = FelisEtCanisObject.GetComponent<FelisEtCanisController>();
		canisActive = FelisEtCanisController.canisActive;
	
		if (canisActive) {
			currentPos = 15.5f;
			targetPos = 15.5f;
		} else {
			currentPos = -16.5f;
			targetPos = -16.5f;
		}


	}
	// Update is called once per frame
	void Update () {
		
//		transform.position = new Vector3 (target.position.x + 50, target.position.y, -10);
		canisActive = FelisEtCanisController.canisActive;
		if (canisActive) {
			targetPos = switchCanisAnimation;
			if (currentPos >= targetPos) {
				animationComplete = true;
				currentPos = targetPos;
			} else {
				currentPos = currentPos + 0.5f;
			}
		} else {
			targetPos = switchFelisAnimation;
			if (currentPos <= targetPos) {
				animationComplete = true;
				currentPos = targetPos;
			} else {
				currentPos = currentPos - 0.5f;
			}
		}

//		if (!animationComplete) {
		transform.position = new Vector3 (target.position.x + currentPos, target.position.y + 2.2f, -10);
//		}
//			
//
//		if (canisActive && !animationComplete) {
//			transform.position = new Vector3 (target.position.x + currentPos, target.position.y, -10);
//			screenAnimation = screenAnimation + 0.1f;
//			if (screenAnimation >= switchCanisAnimation) {
//				screenAnimation = switchCanisAnimation;
//				transform.position = new Vector3 (target.position.x + currentPos, target.position.y, -10);
//				animationComplete = true;
//			}
//		} else if (!animationComplete) {
//			transform.position = new Vector3 (target.position.x + currentPos, target.position.y, -10);
//			screenAnimation = screenAnimation - 0.1f;
//			if (screenAnimation <= switchFelisAnimation) {
//				screenAnimation = switchFelisAnimation;
//				transform.position = new Vector3 (target.position.x + screenAnimation, target.position.y, -10);
//				animationComplete = true;
//			}
//		}

	}
}
