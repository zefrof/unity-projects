using UnityEngine;
using UnityEditor;
using System.Collections;

public class TurretSpawn : MonoBehaviour {
	
	public Texture2D NotHere;
	
	public float ScreenHeight;
	public float ScreenWidth;
	
	public Vector3 MousePos;
	
	public bool HoveringOverTrack = false;

	// Use this for initialization
	void Start () {
		
		ScreenHeight = Screen.height;
		
		ScreenWidth = Screen.width;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		//Debug.Log(HoveringOverTrack);
				
		MousePos = Input.mousePosition;
	
	}
	
	void OnGUI () {
		if(HoveringOverTrack == true) {
			GUI.Label(new Rect(MousePos.x - ScreenWidth * (0.0366f), MousePos.y, ScreenHeight * (0.156f), ScreenWidth * (0.075f)), NotHere);
		}
	}
	
	void OnMouseOver () {
		HoveringOverTrack = true;
	}
	
	void OnMouseExit () {
		HoveringOverTrack = false;
	}
}
