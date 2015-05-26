using UnityEngine;
using System.Collections;

public class FirstCutscene : MonoBehaviour {
	float timer;

	public int changeTimer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if (timer > changeTimer) {
			Application .LoadLevel (7);		
		}
	}
}
