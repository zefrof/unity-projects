using UnityEngine;
using System.Collections;

public class FireBallAI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Vector3 temp = transform.rotation.eulerAngles;
		temp.y = 180f;
		transform.rotation = Quaternion.Euler (temp);

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 temp = transform.position;
		temp.x -= .3f;
		transform.position = temp;
	}
}
