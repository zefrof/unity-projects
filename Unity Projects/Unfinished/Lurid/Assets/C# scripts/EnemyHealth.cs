/// <summary>
/// Enemy health.cs
/// Darren Wiltse
/// Jan 13, 2013
/// This script manages enemies health
/// </summary>
using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	
	public int Health = 50;
		
	// Use this for initialization
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Health == 0){
			Debug.Log("Dead");
		}
		
		if(Health < 0){
			Health = 0;
		}
	}
}
