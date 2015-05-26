using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public GameObject self;

	private bool PlayerActive = true;

	public float Movement_Speed;
	public float Self_Pos_y;
	private float Width_Restriction = 10.6f;
	private float Height_Restriction = 9.25f;
	private float Neg_Height_Restriction = -6.7f;
	// Use this for initialization
	void Start () {
		Movement_Speed = .25f;
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 temp = transform.position;
		temp.y = 0;
		transform.position = temp;

		if(Input.GetKey(KeyCode.UpArrow) && PlayerActive == true){
			Debug.Log ("Up");
			transform.Translate (Vector3.up * Movement_Speed);
		}
		if(Input.GetKey(KeyCode.DownArrow) && PlayerActive == true){
			Debug.Log ("Down");
			transform.Translate (-Vector3.up * Movement_Speed);
		}
		if(Input.GetKey(KeyCode.RightArrow) && PlayerActive == true){
			Debug.Log ("Right");
			transform.Translate (Vector3.forward * Movement_Speed);
		}
		if(Input.GetKey(KeyCode.LeftArrow) && PlayerActive == true){
			Debug.Log ("Left");
			transform.Translate (-Vector3.forward * Movement_Speed);
		}
		if (transform.position.x > Width_Restriction) {
			Vector3 Wtemp = transform.position;
			Wtemp.x = Width_Restriction;
			transform.position = Wtemp;
		}
		if (transform.position.x < -Width_Restriction) {
			Vector3 NegWtemp = transform.position;
			NegWtemp.x = -Width_Restriction;
			transform.position = NegWtemp;
		}
		if (transform.position.z > Height_Restriction) {
			Vector3 Ztemp = transform.position;
			Ztemp.z = Height_Restriction;
			transform.position = Ztemp;
		}
		if (transform.position.z < Neg_Height_Restriction) {
			Vector3 NegZtemp = transform.position;
			NegZtemp.z = Neg_Height_Restriction;
			transform.position = NegZtemp;
		}
	}

	void OnGUI () {
		if(PlayerActive == false){
			if(GUI.Button(new Rect(200, 150, 200, 100), "Retry?")){
				Application.LoadLevel (0);
			}
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.rigidbody.tag == "Enemy"){
			PlayerActive = false;
		}
	}
}