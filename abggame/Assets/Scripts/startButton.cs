using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class startButton : MonoBehaviour {
	public Button startBtn;
	// Use this for initialization
	void Start () {
		startBtn.onClick.AddListener (() => {startGame ();});
	}
	
	// Update is called once per frame
	void startGame() {
		Application.LoadLevel (Application.loadedLevel+1);
	}
}
