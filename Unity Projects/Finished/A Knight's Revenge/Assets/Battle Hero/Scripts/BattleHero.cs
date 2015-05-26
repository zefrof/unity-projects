using UnityEngine;
using System.Collections;

public class BattleHero : MonoBehaviour {
	public GameObject Sword;
	public GameObject Dagger;
	public GameObject Arrow;
	public GameObject Hand;
	public GameObject Bow;
	public GameObject FireBall;
	public GameObject Axe;
	public GUIStyle Battle_Buttons;
	public bool PlayerTurn;
	public int playerHealth;
	public int playerMana;
	public AudioClip fireballNoise;
	public AudioClip bowString;

	private int playerManaMax;
	private int playerHealthMax;
	private int EnemyTurnLenglth = 6;
	private bool playerDead = false;
	private bool swordthrow = false;
	private bool nockarrow = false;
	private bool throwaxe = false;
	private bool summonfireball = false;
	private float EnemyTurnTimer = 0;
	private Animator heroAnimator;
	// Use this for initialization
	void Start () {
		PlayerTurn = true;
		heroAnimator = GetComponent<Animator>();

		if (Application.loadedLevelName == "Level 01") {
			playerHealth = 30;
			playerHealthMax = 30;
			playerMana = 30;
			playerManaMax = 30;
		}
		if (Application.loadedLevelName == "Level 02") {
			playerHealth = 40;
			playerHealthMax = 40;
			playerMana = 40;
			playerManaMax = 40;
		}
		if (Application.loadedLevelName == "Level 03") {
			playerHealth = 50; 
			playerHealthMax = 50;
			playerMana = 50;
			playerManaMax = 50;
		}
		if (Application.loadedLevelName == "Level 04") {
			playerHealth = 50; 
			playerHealthMax = 50;
			playerMana = 50;
			playerManaMax = 50;
		}
		if (Application.loadedLevelName == "Level 05") {
			playerHealth = 60;
			playerHealthMax = 60;
			playerMana = 60;
			playerManaMax = 60;
		}
		if (Application.loadedLevelName == "Level 06") {
			playerHealth = 65;
			playerHealthMax = 65;
			playerMana = 65;
			playerManaMax = 65;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (playerHealth <= 0) {
			playerDead = true;	
		}
		//sword and dagger
		if (swordthrow) {
			heroAnimator.SetBool ("swordThrowAnimation", true);	
			swordthrow = false;
		} 
		else {
			heroAnimator.SetBool ("swordThrowAnimation", false);
		}
		//arrow
		if (nockarrow) {
			heroAnimator.SetBool ("nockArrow", true);
			nockarrow = false;
		}
		else {
			heroAnimator.SetBool ("nockArrow", false);
		}
		//fireball
		if (summonfireball) {
			heroAnimator.SetBool ("summonFireBall", true);
			summonfireball = false;
		}
		else {
			heroAnimator.SetBool ("summonFireBall", false);
		}
		//axe
		if (throwaxe) {
			heroAnimator.SetBool ("axeThrow", true);
			throwaxe = false;
		}
		else{
			heroAnimator.SetBool ("axeThrow", false);
		}
	}

	void OnGUI () {
		if (PlayerTurn == true && playerDead == false) {
			if (GUI.Button (new Rect (10, 10, 100, 50), "Dagger", Battle_Buttons) && playerMana >= 5) {
				swordthrow = true;
				PlayerTurn = false;
				playerMana -= 5;
				Rigidbody clone;
				clone = Instantiate (Dagger, Hand.transform.position, transform.rotation) as Rigidbody;
			}

			if (GUI.Button (new Rect(115, 10, 100, 50), "Sword", Battle_Buttons) && playerMana >= 10) {
				swordthrow = true;
				PlayerTurn = false;
				playerMana -= 10;
				Rigidbody clone;
				clone = Instantiate(Sword, Hand.transform.position, transform.rotation) as Rigidbody;		
			}

			if(Application.loadedLevelName == "Level 02" || Application.loadedLevelName == "Level 03" || Application.loadedLevelName == "Level 04" || Application.loadedLevelName == "Level 05" || Application.loadedLevelName == "Level 06") {
				Debug.Log ("Bow unlocked");
				if(GUI.Button (new Rect(220, 10, 100, 50), "Bow", Battle_Buttons) && playerMana >= 15) {
					nockarrow = true;
					PlayerTurn = false;
					playerMana -= 15;
					GetComponent<AudioSource>().clip = bowString;
					GetComponent<AudioSource>().Play ();
					Rigidbody clone;
					clone = Instantiate (Arrow, Bow.transform.position, transform.rotation) as Rigidbody;
				}
			}

			if(Application.loadedLevelName == "Level 04" || Application.loadedLevelName == "Level 05" || Application.loadedLevelName == "Level 06"){
				Debug.Log ("Fire ball unlocked");
				if(GUI.Button (new Rect(325, 10, 100, 50), "Fire ball", Battle_Buttons) && playerMana >= 40) {
					summonfireball = true;
					PlayerTurn = false;
					playerMana -= 40;
					GetComponent<AudioSource>().clip = fireballNoise;
					GetComponent<AudioSource>().Play ();
					Rigidbody clone;
					clone = Instantiate (FireBall, Hand.transform.position, transform.rotation) as Rigidbody;
				}
			}
			if(Application.loadedLevelName == "Level 05" || Application.loadedLevelName == "Level 06"){
				Debug.Log ("axe unlocked");
				if(GUI.Button (new Rect(430, 10, 100, 50), "Axe", Battle_Buttons) && playerMana >= 45) {
					throwaxe = true;
					PlayerTurn = false;
					playerMana -= 45;
					Rigidbody clone;
					clone = Instantiate (Axe, Hand.transform.position, transform.rotation) as Rigidbody;
				}
			}
		}

		if(playerDead == true && Application.loadedLevelName == "Level 01"){
			if(GUI.Button (new Rect(185,70,200, 100), "Retry?", Battle_Buttons)){
				Application.LoadLevel(1);
			}
		}
		if (playerDead == true && Application.loadedLevelName == "Level 02") {
			if (GUI.Button (new Rect (185, 70, 200, 100), "Retry?", Battle_Buttons)) {
				Application.LoadLevel (2);
			}
		}
		if (playerDead == true && Application.loadedLevelName == "Level 03") {
			if (GUI.Button (new Rect (185, 70, 200, 100), "Retry?", Battle_Buttons)) {
				Application.LoadLevel (3);
			}
		}
		if (playerDead == true && Application.loadedLevelName == "Level 04") {
			if (GUI.Button (new Rect (185, 70, 200, 100), "Retry?", Battle_Buttons)) {
				Application.LoadLevel (4);
			}
		}
		if (playerDead == true && Application.loadedLevelName == "Level 05") {
			if (GUI.Button (new Rect (185, 70, 200, 100), "Retry?", Battle_Buttons)) {
				Application.LoadLevel (5);
			}
		}
		if (playerDead == true && Application.loadedLevelName == "Level 06") {
			if (GUI.Button (new Rect (185, 70, 200, 100), "Retry?", Battle_Buttons)) {
				Application.LoadLevel (6);
			}
		}
		//Health UI bar
		GUI.Box (new Rect (140, 345, (playerHealth / playerHealthMax) + 50, 20), playerHealth + "/" + playerHealthMax);

		//Mana UI bat
		GUI.Box (new Rect (140, 370, (playerMana / playerManaMax) + 50, 20), playerMana + "/" + playerManaMax);
	}
}