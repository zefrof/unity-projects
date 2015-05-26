/// <summary>
/// Targetting.cs
/// Darren Wiltse
/// Sep 16, 2012
/// 
/// This script can be attached to any permenent gameobject and is responsible for allowing the player to target different mobs that are within range
/// </summary>
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Targetting : MonoBehaviour {
	public List<Transform> targets; 
	public  Transform selectedTarget;
	
	private Transform MyTransform; 
	
	// Use this for initialization
	void Start () {
		targets = new List<Transform>();  
		selectedTarget = null;
		MyTransform = transform;  
		
		
		AddAllEnemies();
		
	}
	
	public void AddAllEnemies()
	{
		GameObject[] go = GameObject.FindGameObjectsWithTag("Enemy");
		
		foreach(GameObject enemy in go)
			AddTarget(enemy.transform);
	}
	
	public void AddTarget(Transform Enemy)
	{
		targets.Add(Enemy);
	}
	
	private void SortTargetsByDistance()
	{
		targets.Sort(delegate(Transform t1, Transform t2) {
			return(Vector3.Distance (t1.position, MyTransform.position).CompareTo(Vector3.Distance(t2.position, MyTransform.position))); });	
	}
	private void TargetEnemy()
	{
		if(selectedTarget == null)
		{
			SortTargetsByDistance();
			selectedTarget = targets[0];
		}
		else 
		{
			int index = targets.IndexOf(selectedTarget);
			
			if(index < targets.Count - 1)
			{
				index++;
			}
			else 
			{
				index = 0; 
			}
			DeselectTarget();
			selectedTarget = targets[index];  
		}
		SelectTarget();	
	}
	
	private void SelectTarget() {
		Transform name = selectedTarget.FindChild("Name");
		
		name.GetComponent<TextMesh>().text = selectedTarget.GetComponent<Mob>().Name;
		name.GetComponent<MeshRenderer>().enabled = true;
	}
	
	private void DeselectTarget(){
		selectedTarget.FindChild("Name").GetComponent<MeshRenderer>().enabled = false;
		
		selectedTarget = null; 
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Tab))
		{
			TargetEnemy();
		}
	
	
	}
}
