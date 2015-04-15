using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class text : MonoBehaviour {
	public Text thisTextElement;
	public string SpanishText, EnglishText;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerPrefs.GetString("Language").Equals("Spanish")) {
			thisTextElement.text = SpanishText;
		}

		else {
			thisTextElement.text = EnglishText;
		}
	}

	public void setText(string spanishtxt, string englishtxt) {
		SpanishText = spanishtxt;
		EnglishText = englishtxt;
	}
}
