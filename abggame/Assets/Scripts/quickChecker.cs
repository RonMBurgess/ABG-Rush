using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class quickChecker : MonoBehaviour {
    public Text targetText, thisText, checkTest;
	// Use this for initialization
	void Start () {
        //thisText = gameObject.GetComponent<Text>().text;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(thisText.text + " : " + targetText.text);
	    if(!thisText.text.Equals(targetText.text)) {
            checkTest.text = "WRONG";
        }

        else
        {
            checkTest.text = "CORRECT";
        }
	}
}
