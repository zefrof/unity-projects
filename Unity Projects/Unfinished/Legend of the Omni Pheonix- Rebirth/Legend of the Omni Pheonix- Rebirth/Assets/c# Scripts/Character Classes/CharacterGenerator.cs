using UnityEngine;
using System.Collections;
using System; 					//used for Enum Class

public class CharacterGenerator : MonoBehaviour {
	
	private PlayerCharacter _toon; 
	private const int STARTING_POINTS = 20; 
	private const int MIN_STARTING_ATTIBUTE_VALUE = 10;
	private const int STARTING_VALUE = 10;
	private int PointsLeft;
	
	private const int OFFSET = 5;
	private const int LINE_HIGHT = 20;
	
	private const int STAT_LABLE_WIDTH = 100;
	private const int BASEVALUE_LABEL_WIDTH = 30;
	private const int BUTTON_WIDTH = 20;
	private const int BUTTON_HEIGHT = 20;
	
	private int statStartingPos = 40; 
	
	public GUISkin mySkin; 
	
	public GameObject PlayerPrefab;

	// Use this for initialization
	void Start () {
		GameObject pc = Instantiate(PlayerPrefab, Vector3.zero, Quaternion.identity) as GameObject;
		
		pc.name = "pc";
		
		_toon = pc.GetComponent<PlayerCharacter>();
		PointsLeft = STARTING_POINTS;
		
		for(int cnt = 0; cnt < Enum.GetValues(typeof(AttributeName)).Length; cnt++) {
			_toon.GetPrimaryAttribute(cnt).BaseValue = STARTING_VALUE;
			PointsLeft -= (STARTING_VALUE - MIN_STARTING_ATTIBUTE_VALUE);
		}
		
		_toon.StatUpdate();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI() {
		GUI.skin = mySkin;
		DisplayName();
		DisplayPointsLeft(); 
		DisplayAttributes();		
		DisplayVitals();
		DisplaySkills();
		
		if(_toon.Name == "" || PointsLeft > 0)
			DisplayCreateLabel();
		else
			DisplayCreateButton();
	}
	
	private void DisplayName(){
		GUI.Label(new Rect(10, 10, 50, 250), "Name:");
		_toon.Name = GUI.TextField(new Rect(65, 10, 100, 25), _toon.Name);
	}
	
	private void DisplayAttributes(){
		for(int cnt = 0; cnt < Enum.GetValues(typeof(AttributeName)).Length; cnt++) {
			GUI.Label(new Rect(OFFSET,						//x
				statStartingPos + (cnt * LINE_HIGHT),		//y
				STAT_LABLE_WIDTH, 							//Width
				LINE_HIGHT),								//Height
				((AttributeName)cnt).ToString());
			
			GUI.Label(new Rect(STAT_LABLE_WIDTH + OFFSET,	//x
				statStartingPos + (cnt * LINE_HIGHT),		//y
				BASEVALUE_LABEL_WIDTH,						//Width
				LINE_HIGHT),								//Height
				_toon.GetPrimaryAttribute(cnt).AdjustedBaseValue.ToString());
			
			if(GUI.Button(new Rect(OFFSET + STAT_LABLE_WIDTH + BASEVALUE_LABEL_WIDTH,	//x
				statStartingPos + (cnt * BUTTON_HEIGHT),								//y
				BUTTON_WIDTH,															//Width
				BUTTON_HEIGHT),															//Height
				"-")){
				
				if(_toon.GetPrimaryAttribute(cnt).BaseValue > MIN_STARTING_ATTIBUTE_VALUE) {
					_toon.GetPrimaryAttribute(cnt).BaseValue--;
					PointsLeft++;
					_toon.StatUpdate();
			}
		}
			
			if(GUI.Button(new Rect(OFFSET + STAT_LABLE_WIDTH + BASEVALUE_LABEL_WIDTH + BUTTON_WIDTH,	//x
				statStartingPos + (cnt * BUTTON_HEIGHT),												//y
				BUTTON_WIDTH,																			//Width
				BUTTON_HEIGHT),																			//Height
				"+")){
				
				if(PointsLeft > 0) {
					_toon.GetPrimaryAttribute(cnt).BaseValue++;
					PointsLeft--;
					_toon.StatUpdate();
				}
			}
		}
	}
	
	private void DisplayVitals(){
		for(int cnt = 0; cnt < Enum.GetValues(typeof(VitalName)).Length; cnt++) {
			GUI.Label(new Rect(OFFSET,							//x
				statStartingPos + ((cnt + 7) * LINE_HIGHT),		//y	
				STAT_LABLE_WIDTH,								//Width
				LINE_HIGHT),									//Height
				((VitalName)cnt).ToString());
			
			GUI.Label(new Rect(OFFSET + STAT_LABLE_WIDTH,		//x
				statStartingPos + ((cnt + 7) * LINE_HIGHT),		//y
				BASEVALUE_LABEL_WIDTH,							//Width
				LINE_HIGHT),									//Height
				_toon.GetVital(cnt).AdjustedBaseValue.ToString());
		}
	}
	
	private void DisplaySkills(){
		for(int cnt = 0; cnt < Enum.GetValues(typeof(SkillName)).Length; cnt++) {
			GUI.Label(new Rect(OFFSET + STAT_LABLE_WIDTH + BASEVALUE_LABEL_WIDTH + BUTTON_WIDTH * 2 + OFFSET * 2,	//x
				statStartingPos + (cnt * LINE_HIGHT),																//y
				STAT_LABLE_WIDTH,																					//Width
				LINE_HIGHT),																						//Height
				((SkillName)cnt).ToString());
			
			GUI.Label(new Rect(OFFSET + STAT_LABLE_WIDTH + BASEVALUE_LABEL_WIDTH + BUTTON_WIDTH * 2 + OFFSET * 2 + STAT_LABLE_WIDTH,	//x
				statStartingPos + (cnt * LINE_HIGHT),																					//y
				BASEVALUE_LABEL_WIDTH,																									//Width
				LINE_HIGHT),																											//Height
				_toon.GetSkill(cnt).AdjustedBaseValue.ToString());
		}
	}
	
	private void DisplayPointsLeft(){
		GUI.Label(new Rect(250, 10, 100, 250), "Points Left: " + PointsLeft.ToString());
	}
	
	private void DisplayCreateLabel() {
		GUI.Label (new Rect(Screen.width/ 2 -50,statStartingPos + (10 * LINE_HIGHT),100,LINE_HIGHT),"Creating. . .", "Button"); 

	}
	
	private void DisplayCreateButton() {
		if(GUI.Button (new Rect(Screen.width/ 2 -50,statStartingPos + (10 * LINE_HIGHT),100,LINE_HIGHT),"Create")) {
			GameSettings gsScript = GameObject.Find("__GameSettings").GetComponent<GameSettings>();
		
			//change current value of the vitals to the max modified value of the vitals
			UpdateCurVitalValues(); 
			
			gsScript.SaveCharacterData();
			
			Application.LoadLevel("Level 1");
		}
	}
	
	private void  UpdateCurVitalValues(){
		for(int cnt = 0; cnt < Enum.GetValues(typeof(VitalName)).Length; cnt++) {
			_toon.GetVital(cnt).CurValue = _toon.GetVital(cnt).AdjustedBaseValue;
		}
	}
}
