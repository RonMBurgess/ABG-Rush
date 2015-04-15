using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class language : MonoBehaviour {
	public Toggle languageButton;
	// Use this for initialization
	void Start () {
		languageButton.isOn = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(languageButton.isOn) {
			PlayerPrefs.SetString("Language", "Spanish");
		}
		else {
			PlayerPrefs.SetString("Language", "English");
		}
	}
}
