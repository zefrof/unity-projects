//EnemyList.cs

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelThreeBrain : MonoBehaviour {
	
	public List<GameObject> enemies = new List<GameObject>();
	int dead = 0;
	private bool victory = false;
	public GUIStyle buttons;
	
	void Update()
	{
		foreach(GameObject go in GameObject.FindObjectsOfType (typeof(GameObject)))
		{
			if(go.tag == "Enemy" && !enemies.Contains(go) && !go.GetComponent<DZAI>().dead)
				enemies.Add (go);
			Debug.Log ("First if ran");
			if(go.tag == "Enemy" && go.GetComponent<DZAI>().dead && enemies.Contains(go))
			{
				enemies.Remove(go);
				dead++;
				Debug.Log ("Second if ran");
			}
		}
		
		if (dead == 1) {
			victory = true;			
		}
	}
	
	void OnGUI(){
		if (victory == true) {
			if(GUI.Button (new Rect(185,70,200, 100), "Continue", buttons)){
				Debug.Log ("unlock next level");
				Application.LoadLevel ("Map");
			}
		}
		
		//	GUILayout.Label("Dead Enemies - " + dead.ToString ());
	} 
}
