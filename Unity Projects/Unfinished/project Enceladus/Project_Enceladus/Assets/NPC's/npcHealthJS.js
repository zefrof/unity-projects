#pragma strict

var Health = 100;

function Start () {

}

function Update () {

	if(Health <= 0){
			Debug.Log("Dead");
		}
}

function ApplyDamage (damage : int){
	Health -= damage; 
}