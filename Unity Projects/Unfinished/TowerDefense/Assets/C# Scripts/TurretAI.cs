/// <summary>
/// Turret AI
/// Darren Wiltse
/// May 22, 2013
/// </summary>
using UnityEngine;
using System.Collections;

public class TurretAI : MonoBehaviour {
	
	public Transform target;
	
	public GameObject Projectile;
	public GameObject Barrel;
	
	private float Reload = 2;
	private float CoolDown;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
				
		//Movement
		transform.LookAt(target);
		
		//Shooting
		if(target != null && CoolDown == 0){
			Instantiate (Projectile, Barrel.transform.position, transform.rotation);
			CoolDown += Reload;
				
		}
		
		if(CoolDown > 0){
			CoolDown -= Time.deltaTime;
		}
		
		if(CoolDown < 0){
			CoolDown = 0;
		}		
	}
	
	void OnTriggerStay(Collider other){
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
