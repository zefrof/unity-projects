using UnityEngine;
using System.Collections;

public class VehicleInteraction : MonoBehaviour {
	/*
	public bool EnterVehiclePossible = false;
	public bool InVehicle = false;

	private CapsuleCollider capCol;

	[SerializeField] private GameObject[] vehicles;
	[SerializeField] private SpeederControls[] speederControls; 

	// Use this for initialization
	void Awake () {
		capCol = GetComponent<CapsuleCollider> ();

		vehicles = GameObject.FindGameObjectsWithTag ("Vehicle");
		speederControls = new SpeederControls[vehicles.Length];
		for(int i = 0; i < vehicles.Length; i++){
			SpeederControls[i] = vehicles[i].GetComponent<SpeederControls> ();
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if(Input.GetKeyDown(KeyCode.E)){
			
			if (!InVehicle && EnterVehiclePossible) {
				InVehicle = !InVehicle;
				//camController.cam1.camera.enabled = false;
				//camController.cam2.camera.enabled = true;
				//aeroPlaneControls.playerInPlane = true;
				capCol.enabled = false;
			}
			else{
				Debug.Log ("Leaving the Plane");

				Vector3 setup = transform.position;
				//setup = vhclExitPoints[0].transform.position;
				transform.position = setup;

				InVehicle = !InVehicle;
				//camController.cam1.camera.enabled = true;
				//camController.cam2.camera.enabled = false;
				//aeroPlaneControls.playerInPlane = false;
				capCol.enabled = true;
			}
		}	
	}

	void OnTriggerStay(Collider col){
		if (col.CompareTag ("Cockpit")) {
			Debug.Log ("I can get in a vehicle");
			EnterVehiclePossible = true;
		}	
	}
	*/
}
