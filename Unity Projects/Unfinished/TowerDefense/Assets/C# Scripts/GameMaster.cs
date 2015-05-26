/// <summary>
/// Game master
/// Darren Wiltse
/// May 22, 2013
/// </summary>
using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {
	
	public GUIStyle Style;
	
	public GameObject SpawnPosition;
	public GameObject[] Enemies;
	public GameObject[] Turrets;
	
	private float SpawnTime;
	private float RechargeTime = 2;
	public float GameTime;
	public float ScreenHeight;
	public float ScreenWidth;
	
	private int SpawnCount = 2;
	
	private bool FrogTurretBool = false;
	
	private EnemyAI enemyAI;
	
	// Use this for initialization
	void Start () {
		ScreenHeight = Screen.height;
		
		ScreenWidth = Screen.width;
		
		if(Application.loadedLevelName == "Level_Meadow"){
			 enemyAI = Enemies[0].gameObject.GetComponent<EnemyAI>();
			enemyAI.BasicMoveSpeed = 60;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
		GameTime = GameTime + Time.deltaTime;
		
		//TurretSpawning
		if(FrogTurretBool == true && Input.GetMouseButtonDown(0)){
			Vector3 mousePos = Input.mousePosition;
			mousePos.z = 100;
				
			Vector3 pos = Camera.main.ScreenToWorldPoint(mousePos);
			
			GameObject.Instantiate (Turrets[0], pos, transform.rotation);
			FrogTurretBool = false;
		}
		
		//EnemySpawning
		if(SpawnCount > 0 && SpawnTime == 0){
         GameObject.Instantiate(Enemies[0], SpawnPosition.transform.position, SpawnPosition.transform.rotation);
         SpawnCount--;
		 SpawnTime += RechargeTime; 	
       }
		
		if(SpawnTime > 0){
			SpawnTime -= Time.deltaTime; 
		}
		
		if(SpawnTime < 0) {
			SpawnTime = 0;
		}
	}
	
	void OnGUI() {
		if(GUI.Button(new Rect(ScreenWidth * (0.0002f),ScreenHeight * (0.845f),ScreenWidth * (0.023f), ScreenHeight * (0.156f)),"D")){
		}
		
		if(GUI.Button(new Rect(ScreenWidth * (0.0216f),ScreenHeight * (0.845f),ScreenWidth * (0.07f), ScreenHeight * (0.156f)),"Frog")){
			FrogTurretBool = true;
		}
		
		if(GUI.Button(new Rect(ScreenWidth * (0.0898f),ScreenHeight * (0.845f),ScreenWidth * (0.07f), ScreenHeight * (0.156f)),"Done")){
		}
		
		if(GUI.Button(new Rect(ScreenWidth * (0.1578f),ScreenHeight * (0.845f),ScreenWidth * (0.07f), ScreenHeight * (0.156f)),"Done")){
		}
							//Bigger is farther right and down						//smaller the # smaller the button	
		if(GUI.Button(new Rect(ScreenWidth * (0.226f),ScreenHeight * (0.845f),ScreenWidth * (0.07f), ScreenHeight * (0.156f)),"Done")){
		}
		
		if(GUI.Button(new Rect(ScreenWidth * (0.2942f),ScreenHeight * (0.845f),ScreenWidth * (0.07f), ScreenHeight * (0.156f)),"Done")){
		}
		
		if(GUI.Button(new Rect(ScreenWidth * (0.3622f),ScreenHeight * (0.845f),ScreenWidth * (0.07f), ScreenHeight * (0.156f)),"Done")){
		}
		
		if(GUI.Button(new Rect(ScreenWidth * (0.4302f),ScreenHeight * (0.845f),ScreenWidth * (0.07f), ScreenHeight * (0.156f)),"Done")){
		}
		
		if(GUI.Button(new Rect(ScreenWidth * (0.4982f),ScreenHeight * (0.845f),ScreenWidth * (0.07f), ScreenHeight * (0.156f)),"Done")){
		}
		
		if(GUI.Button(new Rect(ScreenWidth * (0.5664f),ScreenHeight * (0.845f),ScreenWidth * (0.07f), ScreenHeight * (0.156f)),"Done")){
		}
		
		if(GUI.Button(new Rect(ScreenWidth * (0.6344f),ScreenHeight * (0.845f),ScreenWidth * (0.07f), ScreenHeight * (0.156f)),"Done")){
		}
		
		if(GUI.Button(new Rect(ScreenWidth * (0.7026f),ScreenHeight * (0.845f),ScreenWidth * (0.07f), ScreenHeight * (0.156f)),"Done")){
		}
		
		if(GUI.Button(new Rect(ScreenWidth * (0.7706f),ScreenHeight * (0.845f),ScreenWidth * (0.07f), ScreenHeight * (0.156f)),"Done")){
		}
		
		if(GUI.Button(new Rect(ScreenWidth * (0.8388f),ScreenHeight * (0.845f),ScreenWidth * (0.07f), ScreenHeight * (0.156f)),"Done")){
		}
		
		if(GUI.Button(new Rect(ScreenWidth * (0.907f),ScreenHeight * (0.845f),ScreenWidth * (0.07f), ScreenHeight * (0.156f)),"Done")){
		}
		
		if(GUI.Button(new Rect(ScreenWidth * (0.977f),ScreenHeight * (0.845f),ScreenWidth * (0.0235f), ScreenHeight * (0.156f)),"D")){
		}
		
		GUI.Label(new Rect(ScreenWidth * (0.015f), ScreenHeight * (0.015f), ScreenWidth * (0.0235f), ScreenHeight * (0.0334f)), GameTime.ToString(), Style);
	}
}