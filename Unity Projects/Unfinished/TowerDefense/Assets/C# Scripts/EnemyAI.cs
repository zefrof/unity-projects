/// <summary>
/// Enemy AI
/// Darren Wiltse
/// May 22, 2013
/// </summary>
using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	
	private float EnemyHealth;
	
	public int BasicMoveSpeed;
	

	// Use this for initialization
	void Start () {
		
		//WhatEnemy
		if(gameObject.name == "Fly(Clone)"){ //add "(Clone)" to name 
			EnemyHealth = 10;
			iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("PathOne"), "time", BasicMoveSpeed, "easetype", iTween.EaseType.easeInOutSine));

		}
	}
	
	// Update is called once per frame
	void Update () {
		
		//Health
		if(EnemyHealth <= 0){
			Destroy (gameObject);
		}
	
	}
	
	 void OnTriggerEnter(Collider col) {
		if(col.rigidbody != null){
			if(col.rigidbody.tag == "Bullet1") {
				Debug.Log ("Damage Delt");
				EnemyHealth -= 10;
			}
		}
	}
}
