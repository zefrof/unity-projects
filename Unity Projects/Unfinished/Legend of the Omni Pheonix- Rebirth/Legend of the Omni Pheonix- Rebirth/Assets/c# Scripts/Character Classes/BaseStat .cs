/// <summary>
/// Base stat.cs
/// Darren Wiltse
/// Aug 15, 2012
/// 
/// This is the base class for a stats in game
/// </summary>

using UnityEngine;

public class BaseStat {
	public const int STARTING_EXP_COST = 100;	 //publicly accesable value for all the base stats to start at
	
	private int _baseValue;						//The base value of this stat
	private int _buffValue;						//The amount of buff to this stat
	private int _expToLevel;					//The total amount of exp needed to raise this skill	
	private float _levelModifier;				//The moddifier applied to the exp needed to raise this skill
	
	/// <summary>
	/// Initializes a new instance of the <see cref="BaseStat"/> class.
	/// </summary>
	public BaseStat() {
		Debug.Log("Base Stat Created");
		_baseValue = 0;
		_buffValue = 0;
		_expToLevel = STARTING_EXP_COST;
		_levelModifier = 1.1f;
	}
	
#region Setters and Getters	
	/// <summary>
	/// Gets or sets the _baseValue.
	/// </summary>
	/// <value>
	/// The _baseValue.
	/// </value>
	//Basic Setters and Getters 
	public int BaseValue {
		get { return _baseValue;}
		set { _baseValue = value;}
	}
	
	/// <summary>
	/// Gets or sets the _buffValue.
	/// </summary>
	/// <value>
	/// The _buffValue.
	/// </value>
	public int BuffValue {
		get { return _baseValue;}
		set { _buffValue = value;} 
	}
	
	/// <summary>
	/// Gets or sets the _expToLevel.
	/// </summary>
	/// <value>
	/// The _expToLevel.
	/// </value>
	public int ExpToLevel {
		get { return _expToLevel;}
		set { _expToLevel = value;}
	}
	
	/// <summary>
	/// Gets or sets the _levelModifier.
	/// </summary>
	/// <value>
	/// The _levelModifier.
	/// </value>
	public float LevelModifier {
		get { return _levelModifier;}
		set { _levelModifier = value;} 
	}
	
#endregion
	/// <summary>
	/// Gets the adjusted base value and return it.
	/// </summary>
	/// <value>
	/// The adjusted base value.
	/// </value>
	public int AdjustedBaseValue{
		get{ return _baseValue + _buffValue; }
	}
	
	/// <summary>
	/// Calculates the exp to level.
	/// </summary>
	/// <returns>
	/// The exp to level.
	/// </returns>
	private int CalculateExpToLevel() {
		return (int)(_expToLevel * LevelModifier); 
	}
	
	/// <summary>
	/// Assign a new value to _expToLevel and then increase the _baseValue by one. 
	/// </summary>
	public void LevelUp () {
		_expToLevel = CalculateExpToLevel(); 
		_baseValue++; 
	}
}

