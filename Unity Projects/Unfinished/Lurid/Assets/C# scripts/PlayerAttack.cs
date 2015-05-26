/// <summary>
/// Player attack.cs
/// Darren Wiltse
/// This script manages the player's attacking and weapons.
/// </summary>
using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	
	private float MaxDistance;
	
	public GameObject Target;
	
	private float CoolDown = 0;
	private float RechargeCoolDown = 2;
	
	// Use this for initialization
	void Start () {
	
		MaxDistance = Vector3.Distance(Target.transform.position, transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetMouseButton(0) && CoolDown == 0){
			Debug.Log ("Attack");
			PCAttack();
		}
		
		if(CoolDown > 0){
			CoolDown -= Time.deltaTime;
			Debug.Log("Cool Down Complete");
		}
		
		if(CoolDown < 0){
			CoolDown = 0;
		}
	}
	
	void PCAttack () {
		EnemyHealth eh = Target.GetComponent<EnemyHealth>();
		eh.Health -= 25;
		CoolDown += RechargeCoolDown;
	}
}