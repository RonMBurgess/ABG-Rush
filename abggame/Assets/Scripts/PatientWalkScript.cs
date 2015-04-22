using UnityEngine;
using System.Collections;

public class PatientWalkScript : MonoBehaviour {
	private bool isWalking = false;
	private int isWalkingHash = Animator.StringToHash("isWalking");
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}

	public void setWalking (bool b) {
		isWalking = b;
		anim.SetBool (isWalkingHash, isWalking);
	}
}
