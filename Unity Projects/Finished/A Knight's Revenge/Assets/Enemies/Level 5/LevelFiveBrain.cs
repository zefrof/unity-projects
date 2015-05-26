//EnemyList.cs

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelFiveBrain : MonoBehaviour {
	
	public List<GameObject> enemies = new List<GameObject>();
	int dead = 0;
	private bool victory = false;
	public GUIStyle Buttons;
	
	void Update()
	{
		foreach(GameObject go in GameObject.FindObjectsOfType (typeof(GameObject)))
		{
			if(go.tag == "Enemy" && !enemies.Contains(go) && !go.GetComponent<antlerfrogAI>().dead)
				enemies.Add (go);
			Debug.Log ("First if ran");
			if(go.tag == "Enemy" && go.GetComponent<antlerfrogAI>().dead && enemies.Contains(go))
			{
				enemies.Remove(go);
				dead++;
				Debug.Log ("Second if ran");
			}
		}
		
		if (dead == 2) {
			victory = true;			
		}
	}
	
	void OnGUI(){
		if (victory == true) {
			if(GUI.Button (new Rect(185,70,200, 100), "Continue", Buttons)){
				Debug.Log ("unlock next level");
				Application.LoadLevel ("Map");
			}
		}
		
		//	GUILayout.Label("Dead Enemies - " + dead.ToString ());
	} 
}
