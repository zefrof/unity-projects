using UnityEngine;
using System.Collections;

public class EnemyAi : MonoBehaviour {
	public Transform target;
	public int moveSpeed;
	public int rotationSpeed;

	private Transform myTransform;

	void Awake(){
		myTransform = transform;
	}
	// Use this for initialization
	void Start () {
		GameObject go = GameObject.FindGameObjectWithTag("Player");
		target = go.transform;

	}
		void Update () {
	
		Debug.DrawLine (target.position, myTransform.position, Color.yellow); 

		//look at target
		myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (target.position - myTransform.position), rotationSpeed * Time.deltaTime);

		//move to target

		myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
	}

}