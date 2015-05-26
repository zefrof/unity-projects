using UnityEngine;
using System.Collections;

public class MenuGUI : MonoBehaviour {
	public GUIStyle menuButtons;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		if (GUI.Button (new Rect (430, 210, 100, 50), "Play", menuButtons)) {
			Debug.Log ("Start Game");
			Application.LoadLevel (8);
		}

		if (GUI.Button (new Rect (420, 325, 100, 50), "Reset", menuButtons)) {
			PlayerPrefs.DeleteAll ();
		}
	
		if (GUI.Button (new Rect (410, 440, 100, 50), "Quit", menuButtons)) {
			Debug.Log ("Quit");
			Application.Quit ();
		}
	}
}
