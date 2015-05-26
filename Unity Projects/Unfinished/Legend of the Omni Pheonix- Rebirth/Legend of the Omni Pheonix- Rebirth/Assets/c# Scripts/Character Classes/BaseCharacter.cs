using UnityEngine;
using System.Collections;
using System;					//added to acces the enum class

public class BaseCharacter : MonoBehaviour {
	private string _name;
	private int _level;
	private uint _freeExp;
	
	private Attribute[] _primaryAttribute;
	private Vital[] _vital;
	private Skill[] _skill; 
	
	public void  Awake() {
		_name = string.Empty;
		_level = 0;
		_freeExp = 0;
		
		_primaryAttribute = new Attribute[Enum.GetValues (typeof(AttributeName)).Length];
		_vital = new Vital[Enum.GetValues(typeof(VitalName)).Length];
		_skill = new Skill[Enum.GetValues(typeof(SkillName)).Length];
		
		SetupPrimaryAttributes();
		SetupVitals();
		SetupSkills();
	}
	
	//Update is called onece per frame 
	void Update() {
	}

	
	
	public String Name {
		get{ return _name; }
		set{ _name = value; }
	}
	
	public int Level {
		get{ return _level; }
		set{ _level = value; }
	}
	
	public uint FreeExp {
		get{ return _freeExp; }
		set{ _freeExp = value; }
	}
	
	public void AddExp(uint exp) {
		_freeExp += exp; 
		
		CalculateLevel();
	}
	
	//tak avg of all the players skills and assign that as the player level 
	public void CalculateLevel() {
	}
	
	private void SetupPrimaryAttributes() {
		for(int cnt = 0; cnt < _primaryAttribute.Length; cnt++){
			_primaryAttribute[cnt] = new Attribute();
			_primaryAttribute[cnt].Name = ((AttributeName)cnt).ToString();
		}
	}
		
	private void SetupVitals() {
		for(int cnt = 0; cnt < _vital.Length; cnt++)
			_vital[cnt] = new Vital();
		
		SetupVitalModifiers();
	}
			
	private void SetupSkills() {
		for(int cnt = 0; cnt < _skill.Length; cnt++)
			_skill[cnt] = new Skill();
		
		SetupSkillModifiers();
	}
	public Attribute GetPrimaryAttribute(int index){
		return _primaryAttribute[index]; 
	}
	public Vital  GetVital(int index){
		return _vital[index]; 
	}
	public Skill  GetSkill(int index){
		return _skill[index]; 
	}

	private void SetupVitalModifiers(){
		//Health
		GetVital((int)VitalName.Health).AddModifier(new modifyingAttribute(GetPrimaryAttribute((int)AttributeName.Vigor), .5f));
		GetVital((int)VitalName.Health).AddModifier(new modifyingAttribute(GetPrimaryAttribute((int)AttributeName.Endurance), .5f));
		
		//Stamina
		GetVital((int)VitalName.Stamina).AddModifier(new modifyingAttribute(GetPrimaryAttribute((int)AttributeName.Endurance), 1f));
		
		//Mana
		GetVital((int)VitalName.Mana).AddModifier(new modifyingAttribute(GetPrimaryAttribute((int)AttributeName.Wit), .5f));
		GetVital((int)VitalName.Mana).AddModifier(new modifyingAttribute(GetPrimaryAttribute((int)AttributeName.Intelegence), .5f));

	}

	private void SetupSkillModifiers(){
		//Marksman
		GetSkill((int)SkillName.Marksman).AddModifier(new modifyingAttribute(GetPrimaryAttribute((int)AttributeName.Dexterity), .5f));
		
		//Heavy Weapons
		GetSkill((int)SkillName.Heavy_Weapons).AddModifier(new modifyingAttribute(GetPrimaryAttribute((int)AttributeName.Vigor), .5f));
		GetSkill((int)SkillName.Heavy_Weapons).AddModifier(new modifyingAttribute(GetPrimaryAttribute((int)AttributeName.Endurance), .5f));
		
		//Light Weapons
		GetSkill((int)SkillName.Light_Weapons).AddModifier(new modifyingAttribute(GetPrimaryAttribute((int)AttributeName.Endurance), .5f));
		GetSkill((int)SkillName.Light_Weapons).AddModifier(new modifyingAttribute(GetPrimaryAttribute((int)AttributeName.Dexterity), .5f));
		
		//Heavy Armor
		GetSkill((int)SkillName.Heavy_Armor).AddModifier(new modifyingAttribute(GetPrimaryAttribute((int)AttributeName.Endurance), .5f));
		
		//Light Armor
		GetSkill((int)SkillName.Light_Armor).AddModifier(new modifyingAttribute(GetPrimaryAttribute((int)AttributeName.Endurance), .5f));
		
		//Pickpocket 
		GetSkill((int)SkillName.Pickpocket).AddModifier(new modifyingAttribute(GetPrimaryAttribute((int)AttributeName.Dexterity), .5f));
		
		//Stealth
		GetSkill((int)SkillName.Stealth).AddModifier(new modifyingAttribute(GetPrimaryAttribute((int)AttributeName.Dexterity), .5f));
		
		//Lockpick
		GetSkill((int)SkillName.Lockpick).AddModifier(new modifyingAttribute(GetPrimaryAttribute((int)AttributeName.Dexterity), .5f));
		
		//Alchemy
		GetSkill((int)SkillName.Alchemy).AddModifier(new modifyingAttribute(GetPrimaryAttribute((int)AttributeName.Intelegence), .5f));
		
		//Unarmored
		GetSkill((int)SkillName.Unarmored).AddModifier(new modifyingAttribute(GetPrimaryAttribute((int)AttributeName.Dexterity), .5f));
		
		//Defelect
		GetSkill((int)SkillName.Deflect).AddModifier(new modifyingAttribute(GetPrimaryAttribute((int)AttributeName.Endurance), .5f));
		GetSkill((int)SkillName.Deflect).AddModifier(new modifyingAttribute(GetPrimaryAttribute((int)AttributeName.Dexterity), .5f));
		
		//Speechcraft
		GetSkill((int)SkillName.Speechcraft).AddModifier(new modifyingAttribute(GetPrimaryAttribute((int)AttributeName.Wit), .5f));
		GetSkill((int)SkillName.Speechcraft).AddModifier(new modifyingAttribute(GetPrimaryAttribute((int)AttributeName.Intelegence), .5f));

		//Hand To Hand
		GetSkill((int)SkillName.Hand_To_Hand).AddModifier(new modifyingAttribute(GetPrimaryAttribute((int)AttributeName.Dexterity), .5f));
		GetSkill((int)SkillName.Speechcraft).AddModifier(new modifyingAttribute(GetPrimaryAttribute((int)AttributeName.Endurance), .5f));

	}
	public void StatUpdate() {
		for(int cnt = 0; cnt < _vital.Length; cnt++)
			_vital[cnt].update();
		
		for(int cnt = 0; cnt < _skill.Length; cnt++)
			_skill[cnt].update();

	}
}

			


