using UnityEngine;
using System.Collections;

public class Baddie_Spawning : MonoBehaviour {
	public GameObject Spawn_Point_One;
	public GameObject Spawn_Point_Two;
	public GameObject Spawn_Point_Three;
	public GameObject Spawn_Point_Four;
	public GameObject Spawn_Point_Five;
	public GameObject Spawn_Point_six;
	public GameObject Spawn_Point_seven;
	public GameObject Spawn_Point_Eight;
	public GameObject Spawn_Point_Nine;
	public GameObject Spawn_Point_Ten;
	public GameObject Spawn_Point_Eleven;
	public GameObject Spawn_Point_Twelve;
		
	//public int Wave = 1; 
	public Rigidbody[] Baddies;

	private float waveTimer = 0f;
	private int waitTime = 10;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("WOP1", 1, 2);
		InvokeRepeating ("WOP3", 1, 3);
		InvokeRepeating ("WOP5", 3, 1.5f);
	}
	
	// Update is called once per frame
	void Update () {
		waveTimer += Time.deltaTime;
		if (waveTimer > waitTime) {
			CancelInvoke ("WOP1");
			CancelInvoke ("WOP3");
			CancelInvoke ("WOP5");
			waveTimer = 0;
		}
	
	}

	void WOP1 () {
		Rigidbody clone;
		clone = Instantiate(Baddies[0], Spawn_Point_One.transform.position, transform.rotation) as Rigidbody;
	}
	
	void WOP3 () {
		Rigidbody clone;
		clone = Instantiate (Baddies[1], Spawn_Point_Three.transform.position, transform.rotation) as Rigidbody; 
	}

	void WOP5 () {
		Rigidbody clone;
		clone = Instantiate (Baddies [2], Spawn_Point_Five.transform.position, transform.rotation) as Rigidbody;
	}
}