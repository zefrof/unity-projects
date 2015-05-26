using UnityEngine;
using System.Collections;

public class Mob : BaseCharacter {

	// Use this for initialization
	void Start () {
		GetPrimaryAttribute((int)AttributeName.Vigor).BaseValue = 100;
		GetVital((int)VitalName.Health).update();
		
		Name = "Slug Mob"; 

	}
	
	// Update is called once per frame
	void Update () {
		Messenger<int, int>.Broadcast("mob health update", 80, 100);

	
	}
}
