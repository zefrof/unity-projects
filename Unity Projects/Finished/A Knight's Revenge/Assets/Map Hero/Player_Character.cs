using UnityEngine;
using System.Collections;

public class Player_Character : MonoBehaviour {
	public GameObject Battle_one;
	public GameObject Battle_two;
	public GameObject Battle_three;
	public GameObject Battle_four;
	public GameObject Battle_five;
	public GameObject Battle_six;
	public GUIStyle Buttons; 

	public float speed = 5;

	public int Levels_Unlocked = 0;

	bool battle1 = false;
	bool battle2 = false;
	bool battle3 = false;
	bool battle4 = false;
	bool battle5 = false;
	bool battle6 = false;
	// Use this for initialization
	void Start () {
		Levels_Unlocked = PlayerPrefs.GetInt ("Level Unlocked");

		Levels_Unlocked += 1;

		PlayerPrefs.SetInt ("Level Unlocked", Levels_Unlocked);

		if (Levels_Unlocked == 2) {
			Vector3 temp = transform.position;
			temp = Battle_one.transform.position;
			transform.position = temp;
		}
		if (Levels_Unlocked == 3) {
			Vector3 temp = transform.position;
			temp = Battle_two.transform.position;
			transform.position = temp;
		}
		if (Levels_Unlocked == 4) {
			Vector3 temp = transform.position;
			temp = Battle_three.transform.position;
			transform.position = temp;
		}
		if (Levels_Unlocked == 5) {
			Vector3 temp = transform.position;
			temp = Battle_four.transform.position;
			transform.position = temp;
		}
		if (Levels_Unlocked == 6) {
			Vector3 temp = transform.position;
			temp = Battle_five.transform.position;
			transform.position = temp;
		}
	}
	
	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;

		if(Input.GetKey (KeyCode.RightArrow) && Levels_Unlocked == 1){
			transform.position = Vector3.MoveTowards(transform.position, Battle_one.transform.position, step);
		}
		if(Input.GetKey (KeyCode.RightArrow) && Levels_Unlocked == 2){
			transform.position = Vector3.MoveTowards(transform.position, Battle_two.transform.position, step);
		}
		if(Input.GetKey (KeyCode.RightArrow) && Levels_Unlocked == 3){
			transform.position = Vector3.MoveTowards(transform.position, Battle_three.transform.position, step);
		}
		if(Input.GetKey (KeyCode.RightArrow) && Levels_Unlocked == 4){
			transform.position = Vector3.MoveTowards(transform.position, Battle_four.transform.position, step);
		}
		if(Input.GetKey (KeyCode.RightArrow) && Levels_Unlocked == 5){
			transform.position = Vector3.MoveTowards(transform.position, Battle_five.transform.position, step);
		}
		if(Input.GetKey (KeyCode.RightArrow) && Levels_Unlocked == 6){
			transform.position = Vector3.MoveTowards(transform.position, Battle_six.transform.position, step);
		}
	}

	void OnGUI (){
		if (battle1) {
			if(GUI.Button (new Rect(225, 20, 100, 50), "BATTLE!", Buttons)){
				Application.LoadLevel (1);
			}
		}
		if (battle2) {
			if(GUI.Button (new Rect(225, 20, 100, 50), "BATTLE!", Buttons)){
				Application.LoadLevel (2);
			}
		}
		if (battle3) {
			if(GUI.Button (new Rect(225, 20, 100, 50), "BATTLE!", Buttons)){
				Application.LoadLevel (3);
			}
		}
		if (battle4) {
			if(GUI.Button (new Rect(225, 20, 100, 50), "BATTLE!", Buttons)){
				Application.LoadLevel (4);
			}
		}
		if (battle5) {
			if(GUI.Button (new Rect(225, 20, 100, 50), "BATTLE!", Buttons)){
				Application.LoadLevel (5);
			}
		}
		if (battle6) {
			if(GUI.Button (new Rect(225, 20, 100, 50), "BATTLE!", Buttons)){
				Application.LoadLevel (6);
			}
		}

		if(GUI.Button (new Rect(20, 20, 100, 50), "Restart", Buttons)){
			PlayerPrefs.DeleteAll ();
			Application.LoadLevel (0);
		}
	}

	void OnTriggerEnter (Collider col){
		if (col.GetComponent<Rigidbody>().name == "Battle 1") {
			battle1 = true;
		}
		if (col.GetComponent<Rigidbody>().name == "Battle 2") {
			battle2 = true;
		}
		if (col.GetComponent<Rigidbody>().name == "Battle 3") {
			battle3 = true;
		}
		if (col.GetComponent<Rigidbody>().name == "Battle 4") {
			battle4 = true;
		}
		if (col.GetComponent<Rigidbody>().name == "Battle 5") {
			battle5 = true;
		}
		if (col.GetComponent<Rigidbody>().name == "Battle 6") {
			battle6 = true;
		}
	}
	void OnTriggerExit (Collider col){
		if(col.GetComponent<Rigidbody>().name == "Battle 1"){
			battle1 = false;
		}
		if(col.GetComponent<Rigidbody>().name == "Battle 2"){
			battle2 = false;
		}
		if(col.GetComponent<Rigidbody>().name == "Battle 3"){
			battle3 = false;
		}
		if(col.GetComponent<Rigidbody>().name == "Battle 4"){
			battle4 = false;
		}
		if(col.GetComponent<Rigidbody>().name == "Battle 5"){
			battle5 = false;
		}
		if(col.GetComponent<Rigidbody>().name == "Battle 6"){
			battle6 = false;
		}
	}
}
