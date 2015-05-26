using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	private int damage;								//dmg delt to object hit
	private float screenWidth;						
	private float screenHeight;

	private Vector3 lineTransform;
	private Vector3 startTransfrom;
 
	public GameObject par;

	// Use this for initialization
	void Start () {
		//cache screen width a height * .5
		screenWidth = Screen.width * .5f;
		screenHeight = Screen.height * .5f;

		//set a base dmg value
		damage = 50;

		lineTransform = transform.position;
		startTransfrom = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (new Vector3(screenWidth, screenHeight, 0));

		if (Input.GetMouseButtonDown (0)) {

			if(Physics.Raycast (ray,out hit,100)) {
				GameObject particleClone;
				particleClone = Instantiate (par, hit.point, Quaternion.LookRotation (hit.normal)) as GameObject;
				Destroy (particleClone,2);
				hit.transform.SendMessage ("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
			}
		}

		Debug.DrawRay (startTransfrom, lineTransform, Color.red);
	
	}
}
