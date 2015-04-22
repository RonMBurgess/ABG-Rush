using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class patientSpawn : MonoBehaviour {
	public GameObject target, oldTarget, player;
	NavMeshAgent navmesh;
	Quaternion rot;
	//GameObject walkScript;
	Canvas speechBubbleCanvas;
	bool waiting = false, flagged = false, seeking = false, isAtDestination = false, isDiagnosable = false;
	public GameObject optionsPanel, helloBtn;
	Ray ray;
	// Use this for initialization
	void Start () {
		//walkScript = GetComponent<PatientWalkScript>();
		GetComponent<PatientWalkScript> ().setWalking (true);
		navmesh = this.transform.GetComponent<NavMeshAgent> ();
		speechBubbleCanvas = this.GetComponentInChildren<Canvas> ();
		//optionsPanel = GameObject.Find ("Options");
		//helloBtn = GameObject.Find ("helloBtn");
		speechBubbleCanvas.gameObject.SetActive (false);
		rot =  Quaternion.Euler(90,0,0);
		target = GameObject.Find ("patient spot");




	}
	
	// Update is called once per frame
	void Update () {
		isAtDestination = atDestination ();
		//set mode for diagnosis
		if (target.name.Contains ("Chair") && !target.name.Contains ("Waiting") && isAtDestination) {
			isDiagnosable = true;
		}
		preventRotation ();
		navmesh.SetDestination (target.transform.position);
		//CancelInvoke ();
		//Debug.Log (navmesh.remainingDistance);
		displaySpeech ();
		if (seeking) {
			direct ();
			player.GetComponent<move>().stopIt();
			GetComponent<PatientWalkScript>().setWalking(true);


		}
		serviceHack ();


	}
	



	void serviceHack() {
		//one of the test chairs
		if (navmesh.remainingDistance == 0 && target.name.Contains("Waiting_Chair")) {
			GameObject.Find("Player").GetComponent<move>().patientServiced();
			//player.GetComponent<move>().stopIt();

			Invoke("sendToExit", 25);
		}
	}



	void displaySpeech() {
		//THE BELOW CONDITIONAL IS ONLY TEMPORARY, ONLY OPTIONS WILL BE DISPLAYED WHILE AT TRIAGE DESK
		if (navmesh.remainingDistance == 0 && navmesh.remainingDistance != Mathf.Infinity && target.name.Equals("patient spot"))  {
			//spot = true;
			//GetComponent<PatientWalkScript>().setWalking(false);
			//isAtDestination = atDestination();
			speechBubbleCanvas.gameObject.SetActive (true);
			Invoke("sendToExit",25);
		}

		else if (!flagged) {
			speechBubbleCanvas.gameObject.SetActive(false);
		}
	}

	void preventRotation() {
		transform.rotation = rot;
	}

	void OnTriggerEnter(Collider col) {
		//Debug.Log ("got here");
		if (col.tag.Equals ("Patient") && col.GetComponent<patientSpawn> ().getTarget () == target) {
			//Debug.Log("And here? ");
			navmesh.Stop ();
			waiting = true;
			//GetComponent<PatientWalkScript>().setWalking(false);

			Invoke("sendToExit", 25);
		}
		if (col.name.Equals ("Exit")) 
			Destroy (gameObject);
	}


	//TARGETS ARENT EQUAL WHILE EXITING

	void OnTriggerExit(Collider col) {
		if (col.tag.Equals ("Patient") && (col.GetComponent<patientSpawn> ().getTarget () == oldTarget || col.GetComponent<patientSpawn>().getTarget() == target)) {
			col.gameObject.GetComponent<patientSpawn>().resumeMesh();
			//CancelInvoke();
		}
	}

	public GameObject getTarget() {
		return target;
	}

	public GameObject getPrevTarget() {
		return oldTarget;
	}

	public void seek() {
		//Debug.Log("Firing");
		//waiting = false;
		seeking = true;
	}

	public bool atDestination () {
		//Debug.Log (navmesh.remainingDistance);
		if(navmesh.remainingDistance == 0) {
			GetComponent<PatientWalkScript>().setWalking(false);
			return true;
		}
		else {
			if(!waiting) {
				GetComponent<PatientWalkScript>().setWalking(true);
			}
			return false;
		}
	}

	void direct() {
		if(Input.GetMouseButtonDown(0)) {
			RaycastHit hit;
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit) && !hit.transform.gameObject.name.Equals("floor")  /* Add conditional here */) {
				/** These lines are for going to specific objects**/
				navmesh.Resume();
				waiting = false;
				GetComponent<PatientWalkScript>().setWalking(true);
				oldTarget = target;
				target = hit.transform.gameObject;
				navmesh.SetDestination(hit.transform.position);
				CancelInvoke();
				seeking = false;
				hideOptions();
				//GameObject.Find("Player").GetComponent<NavMeshAgent>().Stop();
				/** This line is for going to a point**/
				//navmsh.SetDestination(hit.point);
				
			}
		}
	}

	public void sendToExit() {
		oldTarget = target;
		target = GameObject.Find ("Exit");
		//GameObject.Find ("Player").GetComponent<move> ().patientServiced ();
		navmesh.Resume ();
		waiting = false;
		GetComponent<PatientWalkScript>().setWalking(true);
		flagged = false;
		hideOptions ();
	}

	public void displayOptions() {
		//display modal buttons here
		helloBtn.gameObject.SetActive (false);
		if (!flagged) {
			optionsPanel.SetActive (true);
			flagged = true;
		}

	}

	public bool isPatientDiagnosable() {
		Debug.Log (isDiagnosable);
		return isDiagnosable;
	}

	void hideOptions () {
		speechBubbleCanvas.gameObject.SetActive (false);
		GameObject.Find ("Player").GetComponent<move> ().patientServiced ();
	}

	public void resumeMesh() {
		navmesh.Resume ();
		waiting = false;
		GetComponent<PatientWalkScript>().setWalking(true);
	}
}
