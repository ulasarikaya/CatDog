using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameScript : MonoBehaviour {

	// Use this for initialization
	public void Clicked() {
		SceneManager.LoadScene ("menuScene");
	}
}
