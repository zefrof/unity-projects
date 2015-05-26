using UnityEngine;
using System.Collections;

public class BabyMedusaAI : MonoBehaviour {
	public bool dead = false;
	public GameObject player;
	public BattleHero battleHero;
	public float attack;
	public float HealthbarXPos;
	public AudioClip swordhit;
	public AudioClip Attacknoise;

	private int Health = 20;
	private SpriteRenderer spriteRenderer;
	private SphereCollider sphereCollider;
	private BabyMedusaAI babyMedusaAI;
	private Animator BabyMedusaAnimator;
	// Use this for initialization
	void Start () {
		sphereCollider = GetComponent<SphereCollider> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
		babyMedusaAI = GetComponent<BabyMedusaAI> ();
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
			GetComponent<AudioSource>().clip = Attacknoise;
			GetComponent<AudioSource>().Play ();
			BabyMedusaAnimator.SetBool ("MedusaAttackAnimation", true);
			battleHero.playerHealth -= 5;	
			attack = 0;
		}
		else{
			BabyMedusaAnimator.SetBool ("MedusaAttackAnimation", false);
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
		GUI.Box (new Rect (HealthbarXPos, 490, (Health / 20) + 50, 20), Health + "/" + 20);
	}

	void OnTriggerEnter (Collider col){
		if (col.CompareTag("Sword")) {
			GetComponent<AudioSource>().clip = swordhit;
			GetComponent<AudioSource>().Play ();
			Debug.Log ("Sword Hit");
			Health -= 10;
		}
		if(col.CompareTag ("Dagger")) {
			GetComponent<AudioSource>().clip = swordhit;
			GetComponent<AudioSource>().Play ();
			Debug.Log ("Dagger Hit");
			Health -= 5;
		}
	}	
}
