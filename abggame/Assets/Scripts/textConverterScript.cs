using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class textConverterScript : MonoBehaviour {
    public Text targetText;
    public void convertText()
    {
        targetText.text = gameObject.name;
        ///
    }
}
