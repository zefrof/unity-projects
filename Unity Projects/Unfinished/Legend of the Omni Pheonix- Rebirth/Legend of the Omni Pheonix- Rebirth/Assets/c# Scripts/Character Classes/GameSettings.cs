using UnityEngine;
using System.Collections;
using System;

public class GameSettings : MonoBehaviour {
	public const string PLAYER_SPAWN_POINT = "Player Spawn Point"; 		//This is the name of the gameobject that the player will spawn at at start of level
	
	void Awake () {
		DontDestroyOnLoad(this);
	}
	
	public void SaveCharacterData(){
		GameObject pc = GameObject.Find("pc");
		
		PlayerCharacter pcClass = pc.GetComponent<PlayerCharacter>();
		
		PlayerPrefs.DeleteAll();
		
		PlayerPrefs.SetString("Player Name", pcClass.Name); 
		
		for(int cnt = 0; cnt < Enum.GetValues(typeof(AttributeName)).Length; cnt++) {
			PlayerPrefs.SetInt(((AttributeName)cnt).ToString() + " - Base Value", pcClass.GetPrimaryAttribute(cnt).BaseValue);
			PlayerPrefs.SetInt(((AttributeName)cnt).ToString() + " - Exp To Level", pcClass.GetPrimaryAttribute(cnt).ExpToLevel);

		}
		
		for(int cnt = 0; cnt < Enum.GetValues(typeof(VitalName)).Length; cnt++) {
			PlayerPrefs.SetInt(((VitalName)cnt).ToString() + " - Base Value", pcClass.GetVital(cnt).BaseValue);
			PlayerPrefs.SetInt(((VitalName)cnt).ToString() + " - Exp To Level", pcClass.GetVital(cnt).ExpToLevel);
			PlayerPrefs.SetInt(((VitalName)cnt).ToString() + " - Cur Value", pcClass.GetVital(cnt).CurValue);
		
//			PlayerPrefs.SetString(((VitalName)cnt) + " - Mods", pcClass.GetVital(cnt).GetModifyingAttributeString());

		}
		
		for(int cnt = 0; cnt < Enum.GetValues(typeof(SkillName)).Length; cnt++) {
			PlayerPrefs.SetInt(((SkillName)cnt).ToString() + " - Base Value", pcClass.GetSkill(cnt).BaseValue);
			PlayerPrefs.SetInt(((SkillName)cnt).ToString() + " - Exp To Level", pcClass.GetSkill(cnt).ExpToLevel);
			
//			PlayerPrefs.SetString(((SkillName)cnt) + " - Mods", pcClass.GetSkill(cnt).GetModifyingAttributeString());

		
	}
}
		
	public void LoadCharacterData(){
		GameObject pc = GameObject.Find("pc");
		
		PlayerCharacter pcClass = pc.GetComponent<PlayerCharacter>();
		
		pcClass.Name = PlayerPrefs.GetString("Player Name", "Phil"); 
		
		for(int cnt = 0; cnt < Enum.GetValues(typeof(AttributeName)).Length; cnt++) {
			pcClass.GetPrimaryAttribute(cnt).BaseValue = PlayerPrefs.GetInt(((AttributeName)cnt).ToString() + " - Base Value", 0);
			pcClass.GetPrimaryAttribute(cnt).ExpToLevel = PlayerPrefs.GetInt(((AttributeName)cnt).ToString() + " - Exp To Level", Attribute.STARTING_EXP_COST);
			}
		
		
		for(int cnt = 0; cnt < Enum.GetValues(typeof(VitalName)).Length; cnt++) {
			pcClass.GetVital(cnt).BaseValue = PlayerPrefs.GetInt(((VitalName)cnt).ToString() + " - Base Value", 0);
			pcClass.GetVital(cnt).ExpToLevel = PlayerPrefs.GetInt(((VitalName)cnt).ToString() + " - Exp To Level", 0);
		
			//Call this so AdjustedbaseValue will be updated before curValue is called
			pcClass.GetVital(cnt).update();
			
			//get the stored value for curValue on each vital
			pcClass.GetVital(cnt).CurValue = PlayerPrefs.GetInt(((VitalName)cnt).ToString() + " - Cur Value", 1);
		}
	
			for(int cnt = 0; cnt < Enum.GetValues(typeof(SkillName)).Length; cnt++) {
			pcClass.GetSkill(cnt).BaseValue = PlayerPrefs.GetInt(((SkillName)cnt).ToString() + " - Base Value", 0);
			pcClass.GetSkill(cnt).ExpToLevel = PlayerPrefs.GetInt(((SkillName)cnt).ToString() + " - Exp To Level", 0);
			
	}

		//Output the curValue for each of the vitals
		for(int cnt = 0; cnt < Enum.GetValues(typeof(VitalName)).Length; cnt++) {
			Debug.Log(((VitalName)cnt).ToString() + ": " + pcClass.GetVital(cnt).CurValue);
		}
	}
}