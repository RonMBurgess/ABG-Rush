using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {
	public GameObject patient1, patient2, patient3, patient4, patient5, patient6;
	GameObject[] patients;
	public int spawnDelay;
	bool spawnCooldown = true;
	// Use this for initialization
	void Start () {
		patients = new GameObject[]{ patient1, patient2, patient3, patient4, patient5, patient6};
	}
	
	// Update is called once per frame
	void Update () {
		if (spawnCooldown) {
			Invoke("spawnPatient", spawnDelay);
			spawnCooldown = false;
		}
	}

	void spawnPatient() {
		Instantiate (patients[Random.Range(0,patients.Length)], transform.position, Quaternion.identity);
		spawnCooldown = true;
	}
}
