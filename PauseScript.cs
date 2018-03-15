using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour { 
	public Image image;
	public Sprite pause;
	public Sprite play;

	public Button endGameButton;
	public Text endGameText;

//	public SoundScript soundScript;
	public GameObject audioSource;

	public void Clicked () {
		if (Time.timeScale == 1) {
			Time.timeScale = 0;
			image.sprite = play;
//			endGameButton.enabled = true;
//			endGameText.enabled = true;
//			currentScene = 
//			DontDestroyOnLoad(currentScene);
//			currentScene = SceneManager.GetActiveScene();
//			SceneManager.LoadScene ("pauseScene");
		} else {
			if (SoundScript.soundOn) {
				audioSource.SetActive (true);
			}
//			GameObject soundScriptObject = GameObject.Find("FelisEtCanis");
//			SceneManager.LoadScene (currentScene);
//			SceneManager.SetActiveScene (currentScene);
//			if (soundObject.GetComponent<>)
//			endGameButton.enabled = false;
//			endGameText.enabled = false;
			Time.timeScale = 1;
			image.sprite = pause;
		}
	}
}
