using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GoList : MonoBehaviour {
	//Declare GameObject List
	public List<GameObject> GObj = new List<GameObject> ();
	//Declare GameObject Array
	public GameObject[] enemyList;
	//Declare int's
	public int enemyListLength;
	public int p = 0;
	public int c;

	// Use this for initialization
	void Start () {

		//Find all GameObjects with the tag "Character" and make enemyListLength equal to the number of Gameobjects with the tag
		enemyList = GameObject.FindGameObjectsWithTag ("Character");
		enemyListLength = enemyList.Length;
		//For each value of enemyListLength Find a GameObject and add it to the list
		for (int i = 0; i < enemyListLength; i++){
			GObj.Add (enemyList[i]);
		}
		//run the sort method
		GObj.Sort (SortMethod);
		/* foreach (GameObject go in GObj) {
				print (go.name);		
		} */
		//Set int c equal to the number of objects in the List GObj
		c = GObj.Count;
		GObj[0].GetComponent<PlayerTurn>().turnActive = true;

	}

	private int SortMethod (GameObject A, GameObject B){
		if (!A && !B) return 0;
		else if (!A) return -1;
		else if (!B) return 1;
		else if (A.GetComponent<Attributes>().speed > B.GetComponent<Attributes>().speed) return 1;
		else return -1;
	}

	// Update is called once per frame
	 void Update () {

		//possibly would be better as a for loop, needs to be tested
		if(GObj[p].GetComponent<PlayerTurn>().turnActive == false){

			p++;

			if(p < c){
				GObj[p].GetComponent<PlayerTurn>().turnActive = true;
			}
			else
				if(p >= c){
				p = 0;
				GObj[p].GetComponent<PlayerTurn>().turnActive = true;
			}
		}
	} 
}
