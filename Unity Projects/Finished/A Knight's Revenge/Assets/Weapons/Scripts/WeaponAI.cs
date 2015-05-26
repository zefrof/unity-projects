using UnityEngine;
using System.Collections;

public class WeaponAI : MonoBehaviour {
	 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 temp = transform.position;
		temp.x += .3f;
		transform.position = temp;
	}
	void OnTriggerEnter (Collider col){
		if(col.CompareTag ("Enemy")){
			Destroy (gameObject);
		}
	}
}
