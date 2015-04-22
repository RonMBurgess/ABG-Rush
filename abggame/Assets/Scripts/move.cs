using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class move : MonoBehaviour {
    public GameplayUIScript gameplayUI;
	NavMeshAgent navmsh;
	Transform target;
	public GameObject abgTool;
	Ray ray; 
	bool withPatient = false;
	private int walkingHash = Animator.StringToHash("IsWalking");
	private	Animator anim;
	Quaternion rot;
	bool walking = false, usingTool = false, canMove = true;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rot = transform.rotation;
		navmsh = this.transform.GetComponent<NavMeshAgent> ();
	}

	void preventRotation() {
		transform.rotation = rot;
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool (walkingHash, walking);
		//Debug.Log (withPatient);
		preventRotation ();

		//TEMPOORARY BUTTON TO CLOSE UI
		if (usingTool && Input.GetKeyDown (KeyCode.X)) {
			usingTool = false;
			//abgTool.gameObject.SetActive(false);
            gameplayUI.ABGToolUse(false);
		}

		//

		if (navmsh.remainingDistance < .1 /*temporary */ && !Input.GetKey(KeyCode.X)) {
			walking = false;
			if(target && target.name.Equals("Reference_Desk")) {
                gameplayUI.ABGToolUse(true);
                //abgTool.gameObject.SetActive(true);
				usingTool = true;
			}
			else {
				//abgTool.gameObject.SetActive(false);
                gameplayUI.ABGToolUse(false);
                usingTool = false;
			}
		} 
		//Debug.Log (navmsh.remainingDistance);
		if(Input.GetMouseButtonDown(0)) {
			RaycastHit hit;
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray,out hit) && hit.transform.gameObject.name.Equals("Reference_Desk")) {
				usingTool = true;
				navmsh.Resume();
				walking = true;
				target = hit.transform.gameObject.transform;
				navmsh.SetDestination(new Vector3(hit.transform.position.x - .5f, hit.transform.position.y, hit.transform.position.z));
			}

			if (Physics.Raycast(ray, out hit) && !hit.transform.gameObject.name.Equals("floor") && !withPatient && !usingTool) {
				/** These lines are for going to specific objects**/
				navmsh.Resume();
				walking = true;
				target = hit.transform.gameObject.transform;
				navmsh.SetDestination(hit.transform.position);


			}
		}
		if (target && canMove) {
			navmsh.SetDestination(target.position);
			//walking = true;
			//walking = true;
		}
	}

	void OnTriggerEnter(Collider col) {
		//Debug.Log (col.gameObject.GetComponent<patientSpawn> ().getPrevTarget ().name);
		if (col.gameObject.tag.Equals ("Patient") && 
		    col.gameObject.GetComponent<patientSpawn>().atDestination()/* && 
		    (col.gameObject.GetComponent<patientSpawn>().getTarget().name.Contains("Waiting") || 
		 	col.gameObject.GetComponent<patientSpawn>().getTarget().name.Equals("patient"))*/ ) {
				if(col.GetComponent<patientSpawn>().isPatientDiagnosable()) {
					//abgTool.gameObject.SetActive(true);
                    gameplayUI.ABGToolUse(true);
					usingTool = true;
				}
				walking = false;
				stopIt();
				//col.gameObject.GetComponent<patientSpawn>().displayOptions();
				if(!usingTool) {
					col.gameObject.GetComponent<patientSpawn>().seek();
				}
				//canMove = false;
				withPatient = true;

		}
	}

	public void patientServiced() {
		withPatient = false;

	}

	public void cantMove() {
		canMove = true;
	}
	//I am a horrible programmer for doing this
	public void sendAway() {
		//c.gameObject.GetComponent<patientSpawn> ().sendToExit ();
		usingTool = false;
		//abgTool.gameObject.SetActive(false);
        gameplayUI.ABGToolUse(false);
	}
	

	public void stopIt() {
		walking = false;

		navmsh.Stop ();
	}
}
