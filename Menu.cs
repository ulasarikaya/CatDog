using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
	public static bool Beast; // 0 = Felis, 1 = Canis
	public FelisEtCanisController felisEtCanisScript;
	public Image felisSelected;
	public Image canisSelected;


	public void LoadLevel(string levelName) {
		GameObject FelisEtCanisObject = GameObject.Find("FelisEtCanis");
//		FelisEtCanisController felisEtCanisScript = FelisEtCanisObject.GetComponent<FelisEtCanisController>();
		FelisEtCanisController.pickBeast(Beast);

		SceneManager.LoadScene (levelName);
	}

	public void ChooseBeast(bool beast) {
		Beast = beast;
		if (beast) { // canis
			felisSelected.enabled = false;
			canisSelected.enabled = true;
		} else { // felis
			felisSelected.enabled = true;
			canisSelected.enabled = false;
		}
	}
}
