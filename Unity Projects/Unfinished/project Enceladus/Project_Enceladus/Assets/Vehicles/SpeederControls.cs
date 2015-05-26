using UnityEngine;
using System.Collections;

public class SpeederControls : MonoBehaviour {
	[SerializeField] private float maxSpeed;
	[SerializeField] private float minSpeed;
	[SerializeField] private float curSpeed;
	[SerializeField] private float accel;
	[SerializeField] private float rotateSpeed;
	
	// Use this for initialization
	void Start () {
		if(gameObject.name == ("Cube")){
			rotateSpeed = 1f;
			accel = .1f;
			curSpeed = 0;
			maxSpeed = 10;
			minSpeed = 0;
		}
	}

	void FixedUpdate () {

		if (curSpeed > maxSpeed) {
			curSpeed = maxSpeed;		
		}

		if (curSpeed < minSpeed) {
			curSpeed = minSpeed;		
		}

		rigidbody.velocity = transform.TransformDirection(Vector3.right * curSpeed);

		Debug.Log ("speed = " + curSpeed);

		if(Input.GetButton("W")){
			Debug.Log ("w is pressed");

			Vector3 tempz = transform.rotation.eulerAngles;
			tempz.z += rotateSpeed;
			transform.rotation = Quaternion.Euler (tempz);
		}

		if (Input.GetButton ("S")) {
			Debug.Log ("s is pressed");

			Vector3 temp = transform.rotation.eulerAngles;
			temp.z -= rotateSpeed;
			transform.rotation = Quaternion.Euler (temp);		
		}

		if (Input.GetButton ("A")) {
			Vector3 tempa = transform.rotation.eulerAngles;
			tempa.x += rotateSpeed;
			transform.rotation = Quaternion.Euler (tempa);

			//rigidbody.velocity = transform.TransformDire
		}

		if (Input.GetButton ("D")) {
			Vector3 tempd = transform.rotation.eulerAngles;
			tempd.x -= rotateSpeed;
			transform.rotation = Quaternion.Euler (tempd);

		}

		if(Input.GetButton("Up")){

			Debug.Log ("up is pressed");

			curSpeed += accel;
		}

		if(Input.GetButton("Down")){
			
			Debug.Log ("Down is pressed");
			
			curSpeed -= accel;
		}
	}
}
