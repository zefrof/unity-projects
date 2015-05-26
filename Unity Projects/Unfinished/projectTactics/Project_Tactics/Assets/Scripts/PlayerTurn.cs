using UnityEngine;
using System.Collections;

public class PlayerTurn : MonoBehaviour {
	public bool turnActive = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		/* if(turnActive) {
			Turn();
		} */
	}

	void OnGUI (){
		if (GUI.Button (new Rect (200, 300, 75, 75), "End Turn")) {
			Debug.Log ("Taking Turn");
			turnActive = false;
		}
	}

	public void Turn() {
		//not used yet
	}
}
