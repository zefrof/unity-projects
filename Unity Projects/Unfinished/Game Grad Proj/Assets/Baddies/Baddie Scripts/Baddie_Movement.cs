using UnityEngine;
using System.Collections;

public class Baddie_Movement : MonoBehaviour {
	public string pathName;

	// Use this for initialization
	void Start () {
		if(gameObject.name == "Path_1_baddie(Clone)") {
			pathName = "Path_1";
		}
		if (gameObject.name == "Path_3_baddie(Clone)") {
			pathName = "Path_3";
		}
		if (gameObject.name == "Path_5_baddie(Clone)") {
			pathName = "Path_5";
		}

		iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath (pathName), "time", 15, "easetype", iTween.EaseType.easeInOutSine));
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider col){
		if (col.rigidbody.tag == "projectile"){
			Destroy (gameObject);
		}
	}
}