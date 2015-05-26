using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {
	RaycastHit hit;

	private float raycastLength = 500;

	public GameObject[] spawnPoints; 
	public GameObject spawn;

	public MapNav map;
	public TileNode node;

	void Start () {
		spawnPoints = GameObject.FindGameObjectsWithTag("Spawn Point");
		//turn on node colliders
		foreach (GameObject n in spawnPoints) {
			n.collider.enabled = true; 		
		}
	}

	// Update is called once per frame
	void Update () {

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);	

		if (Physics.Raycast (ray, out hit, raycastLength)) {
			if(hit.collider.tag == "Spawn Point"){
				node = hit.collider.GetComponent<TileNode>();

				if(Input.GetMouseButtonDown(0)){
					Debug.Log ("clicking the terrian");
					GameObject clone;
					clone = Instantiate (spawn, node.transform.position, Quaternion.identity) as GameObject;
				}
			}
		}
	}
}
