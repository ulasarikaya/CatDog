using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour {
	public static bool soundOn = true;
	public GameObject audioSource;
	public void Clicked (UnityEngine.UI.Text text){
		soundOn = !soundOn;

		if (soundOn) {
			text.text = "Sound: On";
			if (Time.timeScale == 1) {
				audioSource.SetActive (true);
			}
		} else {
			text.text = "Sound: Off";
			audioSource.SetActive (false);
		}
	}
}
