using UnityEngine;
using System.Collections;

public class Plasma_AI : MonoBehaviour {
	private float Death_Timer = 0;
	private float Dead = .5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Death_Timer += Time.deltaTime;
		if (Death_Timer > Dead) {
			Destroy (gameObject);		
		}

	}

	void OnTriggerEnter(Collider col){
		if(col.rigidbody.tag == "Enemy"){
			Destroy (gameObject);
		}
	} 
}