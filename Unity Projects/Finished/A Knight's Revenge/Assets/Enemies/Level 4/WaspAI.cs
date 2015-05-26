using UnityEngine;
using System.Collections;

public class WaspAI : MonoBehaviour {
	public bool dead = false;
	public GameObject player;
	public BattleHero battleHero;
	public float attack;
	public float HealthbarXPos;
	public float HealthbarYPos;
	public AudioClip swordHit;
	public AudioClip arrowHit;
	
	private int Health = 60;
	private SpriteRenderer spriteRenderer;
	private SphereCollider sphereCollider;
	private WaspAI babyMedusaAI;
	private Animator BabyMedusaAnimator;
	// Use this for initialization
	void Start () {
		sphereCollider = GetComponent<SphereCollider> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
		babyMedusaAI = GetComponent<WaspAI> ();
		battleHero = player.GetComponent<BattleHero> ();
		BabyMedusaAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (battleHero.PlayerTurn == false) {
			battleHero.PlayerTurn = true;
			battleHero.playerMana += 6;
			attack = Random.Range (1, 5);
			
		}
		if (attack == 2 || attack == 4) {
			battleHero.playerHealth -= 5;	
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
		GUI.Box (new Rect (HealthbarXPos, HealthbarYPos, (Health / 60) + 50, 20), Health + "/" + 60);
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
		if(col.CompareTag ("Arrow")) {
			GetComponent<AudioSource>().clip = arrowHit;
			GetComponent<AudioSource>().Play ();
			Debug.Log ("bow hti");
			Health -= 15;
		}
		if(col.CompareTag ("Fire Ball")) {
			Debug.Log ("fire ball hit");
			Health -= 30;
		}
	}
}
