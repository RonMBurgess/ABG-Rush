using UnityEngine;
using System.Collections;

public class playerBasic : MonoBehaviour {
	/*
    public int speed;
	public bool atDesk, atDestination;
	public GameObject topNodeA,topNodeB,botNodeA,botNodeB,deskNode;
	GameObject[] path1, path2, thePath;
	private int travelIndex;
	Vector2 nodeLocation;
	bool travelling;
	// Use this for initialization
	void Start () {
		travelling = false;
		travelIndex = 0;
		atDesk = false;
		atDestination = false;
		path1 = new GameObject[2]{topNodeA,topNodeB};
		path2 = new GameObject[2]{botNodeA,botNodeB};

	}
	
	// Update is called once per frame
	void Update () {

		if(transform.position == deskNode.transform.position) {
			atDesk = true;
		}
		if(!atDesk) {
			transform.position = Vector2.MoveTowards(transform.position,deskNode.transform.position,speed*Time.deltaTime);
		}
		else if(travelling) {
			transform.position = Vector2.MoveTowards(transform.position, nodeLocation, speed*Time.deltaTime);
		}
		if(transform.position == thePath[travelIndex].transform.position) {
			Debug.Log ("incremented");
			travelIndex++;
			nodeLocation = new Vector2(thePath[travelIndex].transform.position.x,thePath[travelIndex].transform.position.y);

		}
	}

	void OnMouseDown() {
		//Debug.Log ("clicked");
		if (atDesk) {
			travel(path1);
		}
	}

	void travel(GameObject[] nodePath) {
			
		thePath = nodePath;
		nodeLocation = new Vector2(thePath[travelIndex].transform.position.x,thePath[travelIndex].transform.position.y);
		travelling = true;
			

	}
     * */
}
