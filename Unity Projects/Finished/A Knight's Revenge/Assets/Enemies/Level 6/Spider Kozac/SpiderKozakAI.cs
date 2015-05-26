using UnityEngine;
using System.Collections;

public class SpiderKozakAI : MonoBehaviour {
	public bool dead = false;
	public GameObject player;
	public GameObject webs;
	public GameObject Mouth;
	public BattleHero battleHero;
	public float attack;
	public float HealthbarXPos;
	public AudioClip swordHit;
	public AudioClip arrowHit;
	public AudioClip attackNoise;
	
	private int Health = 60;
	private SpriteRenderer spriteRenderer;
	private SphereCollider sphereCollider;
	private SpiderAI babyMedusaAI;
	// Use this for initialization
	void Start () {
		sphereCollider = GetComponent<SphereCollider> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
		babyMedusaAI = GetComponent<SpiderAI> ();
		battleHero = player.GetComponent<BattleHero> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (battleHero.PlayerTurn == false) {
			battleHero.PlayerTurn = true;
			battleHero.playerMana += 6;
			attack = Random.Range (1, 10);
			
		}
		if (attack == 2 || attack == 8) {
			GetComponent<AudioSource>().clip = attackNoise;
			GetComponent<AudioSource>().Play ();
			Rigidbody clone;
			clone = Instantiate (webs, Mouth.transform.position, transform.rotation) as Rigidbody;
			battleHero.playerHealth -= 35;	
			attack = 0;
		}
		
		if (Health <= 0) {
			dead = true;		
		}
		if (dead == true) {
			spriteRenderer.enabled = false;		
			sphereCollider.enabled = false;
			babyMedusaAI.enabled = false;
		}
	}
	
	void OnGUI (){
		GUI.Box (new Rect (HealthbarXPos, 420, (Health / 60) + 50, 20), Health + "/" + 60);
	}
	
	void OnTriggerEnter (Collider col){
		if (col.CompareTag("Sword")) {
			GetComponent<AudioSource>().clip = swordHit;
			GetComponent<AudioSource>().Play ();
			Debug.Log ("Sword Hit");
			Health -= 10;
		}
		if(col.CompareTag ("Dagger")) {
			GetComponent<AudioSource>().clip = swordHit;
			GetComponent<AudioSource>().Play ();
			Debug.Log ("Dagger Hit");
			Health -= 5;
		}
		if (col.CompareTag ("Arrow")) {
			GetComponent<AudioSource>().clip = arrowHit;
			GetComponent<AudioSource>().Play ();
			Debug.Log ("Arrow Hit");
			Health -= 15;
		}
		if (col.CompareTag ("Fire Ball")) {
			Debug.Log ("Fire ball hit");
			Health -= 30;
		}
		if (col.CompareTag ("Axe")) {
			GetComponent<AudioSource>().clip = swordHit;
			GetComponent<AudioSource>().Play ();
			Debug.Log ("Axe hit");
			Health -= 40;
		}
	}	
}
