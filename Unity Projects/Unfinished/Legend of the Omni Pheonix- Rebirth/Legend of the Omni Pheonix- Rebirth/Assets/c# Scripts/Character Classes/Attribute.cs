/// <summary>
/// Attribute.cs
/// Darren Wiltse
/// Aug 17, 2012
/// 
/// This is the class for all the character attrbutes in-game
/// </summary>
public class Attribute : BaseStat {
	new public const int STARTING_EXP_COST = 50;	//this is the starting cost for all the attributes
	
	private string _name;							//this is the name of the attribute
	
	/// <summary>
	/// Initializes a new instance of the <see cref="Attribute"/> class.
	/// </summary>
	public Attribute (){
		UnityEngine.Debug.Log("Attribute Created");
		ExpToLevel = STARTING_EXP_COST; 	 
		LevelModifier = 1.05f; 
	}
	
	/// <summary>
	/// Gets or sets the _name.
	/// </summary>
	/// <value>
	/// The _name.
	/// </value>
	public string Name{
		get{return _name; }
		set{_name = value; }
	}
}

/// <summary>
/// List of all the attributes that are used in-game for our characters 
/// </summary>
public enum AttributeName {
	Vigor,
	Wit, 
	Dexterity, 
	Endurance,
	Intelegence
	
	
} 