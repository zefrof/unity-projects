/// <summary>
/// Skill.cs
/// Darren Wiltse
/// Sep 14, 2012
/// 
/// This class contains all the extra functions that are needed for a skill
/// </summary>
public class Skill : ModifiedStat {
	private bool _Known; 					//a boolean variable to toggle if a chacter knows a skill
	
	/// <summary>
	/// Initializes a new instance of the <see cref="Skill"/> class.
	/// </summary>
	public Skill (){
		UnityEngine.Debug.Log("Skill created");
		_Known = false;
		ExpToLevel = 25;
		LevelModifier = 1.1f;
	}
	
	/// <summary>
	/// Gets or sets a value indicating whether this <see cref="Skill"/> is known.
	/// </summary>
	/// <value>
	/// <c>true</c> if known; otherwise, <c>false</c>.
	/// </value>
	public bool Known {
		get{ return _Known; }
		set{ _Known = value; }
	}
}

/// <summary>
/// This enumeration is just a list of skill the player can learn
/// </summary>
public enum SkillName {
	Marksman,
	Heavy_Weapons,
	Light_Weapons,
	Hand_To_Hand,
	Heavy_Armor,
	Light_Armor,
	Unarmored, 
	Pickpocket,
	Stealth,
	Lockpick,
	Alchemy,
	Deflect,
	Speechcraft 
	
}