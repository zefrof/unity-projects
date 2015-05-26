using UnityEngine;
using System.Collections;

public class DZAI : MonoBehaviour {
	public bool dead = false;
	public GameObject player;
	public GameObject fireBall;
	public GameObject Mouth;
	public BattleHero battleHero;
	public float attack;
	public float HealthbarXPos;
	public AudioClip attackNoise;
	public AudioClip swordHit;
	public AudioClip arrowHit;
	
	private int Health = 80;
	private SpriteRenderer spriteRenderer;
	private SphereCollider sphereCollider;
	private DZAI babyMedusaAI;
	private Animator DZanimator;
	// Use this for initialization
	void Start () {
		sphereCollider = GetComponent<SphereCollider> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
		babyMedusaAI = GetComponent<DZAI> ();
		battleHero = player.GetComponent<BattleHero> ();
		DZanimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (battleHero.PlayerTurn == false) {
			battleHero.PlayerTurn = true;
			battleHero.playerMana += 6;
			attack = Random.Range (1, 4);
			
		}
		if (attack == 2 || attack == 4) {
			DZanimator.SetBool ("DZanimation", true);
			GetComponent<AudioSource>().clip = attackNoise;
			GetComponent<AudioSource>().Play ();
			Rigidbody clone;
			clone = Instantiate (fireBall, Mouth.transform.position, transform.rotation) as Rigidbody;
			battleHero.playerHealth -= 15;	
			attack = 0;
		}
		else {
			DZanimator.SetBool ("DZanimation", false);
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
		GUI.Box (new Rect (HealthbarXPos, 410, (Health / 80) + 50, 20), Health + "/" + 80);
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
	}	
}
