/// <summary>
/// Bullet AI
/// Darren Wiltse
/// May 22, 2013
/// </summary>
using UnityEngine;
using System.Collections;

public class BulletAI : MonoBehaviour {
	
	public GameObject Self;
	
	public Transform target;
	
	public float LifeTime = .5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//LifeTimeFunction
		LifeTime -= Time.deltaTime;
		
		if(LifeTime <= 0){
			Destroy (gameObject);
		}
		
		//Movement
		Self.rigidbody.AddForce(transform.forward * 750);
		transform.LookAt(target);
	}
	void OnTriggerEnter(Collider other){
		if(target == null){
			if(other.rigidbody.tag == "Enemy"){
				target = other.transform;
			}
		}
	}
	
	void OnTriggerExit(Collider other) {
		if(target != null){
			target = null;
		}
	}
}
