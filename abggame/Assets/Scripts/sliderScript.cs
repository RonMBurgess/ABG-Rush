using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class sliderScript : MonoBehaviour {
	
	private Slider slider;
	private int counter;
	
	public float MaxHealth;
	public Image Fill;  // assign in the editor the "Fill"
	public Color MaxHealthColor = Color.blue;
	public Color MinHealthColor = Color.red;
	
	private void Awake() {
		slider = gameObject.GetComponent<Slider>();
		MaxHealth = (float) slider.maxValue;
		if(gameObject.name.Equals("coSlider")) {
			MaxHealthColor = Color.red;
			MinHealthColor = Color.blue;
		}

	}
	
	private void Start() {
		//slider.wholeNumbers = true;        // I dont want 3.543 Health but 3 or 4
		//slider.minValue = 0f;
		//slider.maxValue = MaxHealth;
		//slider.value = MaxHealth/2;        // start with full health
	}
	
	private void Update() {
		UpdateHealthBar();        // just for testing purposes
		//counter--;                        // just for testing purposes
	}
	
	public void UpdateHealthBar() {
		//slider.value = val;
		float range = slider.maxValue - slider.minValue;
		float temp = ((float)slider.value-slider.minValue) / range;
		Fill.color = Color.Lerp (MinHealthColor, MaxHealthColor, temp);
	}
}