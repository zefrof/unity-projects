using UnityEngine;
using System.Collections;

public class Collison : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision col){
		if(col.rigidbody.gameObject.name == "Enemy"){
			Debug.Log ("Collision Detected");
			Destroy(col.gameObject);
		}
	}
}
