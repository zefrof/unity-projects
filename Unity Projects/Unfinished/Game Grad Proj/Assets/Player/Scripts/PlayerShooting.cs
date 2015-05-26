using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {
	public Rigidbody Plasma;

	public GameObject barrel;

	public float Plasma_Cooldown;
	public float Plasma_Cooldown_Timer = 0.5f;
	public float Plasma_Movement_Speed = 32f;

	// Use this for initialization
	void Start () {
		Plasma_Cooldown = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Plasma_Cooldown < 0) {
			Plasma_Cooldown = 0;
		}

		if (Plasma_Cooldown > 0) {
			Plasma_Cooldown -= Time.deltaTime;
		}

		if (Input.GetKey(KeyCode.Space) && Plasma_Cooldown == 0){
			Rigidbody clone;
			clone = Instantiate(Plasma, barrel.transform.position, transform.rotation) as Rigidbody;
			clone.velocity = transform.TransformDirection(Vector3.up * Plasma_Movement_Speed);

			Plasma_Cooldown += Plasma_Cooldown_Timer;
		}
	}
}
