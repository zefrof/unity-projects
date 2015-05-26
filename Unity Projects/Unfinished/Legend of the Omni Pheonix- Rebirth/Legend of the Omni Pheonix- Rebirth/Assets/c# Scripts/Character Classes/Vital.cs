/// <summary>
/// Vital.cs
/// Darren Wiltse
/// Aug 24, 2012
/// 
/// This class contains all the extra functions for a characters vitals
/// </summary>
public class Vital : ModifiedStat {

	private int _currentValue; 			//This is the current value of this vital
	
	/// <summary>
	/// Initializes a new instance of the <see cref="Vital"/> class.
	/// </summary>
	public Vital (){
		UnityEngine.Debug.Log("Vital Created");
		_currentValue = 0;
		ExpToLevel = 50; 
		LevelModifier = 1.1f; 
	}
	
	/// <summary>
	/// When getting the _curValue make sure that it is not greater than our AdjustedBaseValue
	/// if it is make it the same size as the AdjustedBaseValue
	/// </summary>
	/// <value>
	/// The current value.
	/// </value>
	public int CurValue {
		get{
			if(_currentValue > AdjustedBaseValue)
				_currentValue = AdjustedBaseValue; 
			
			return _currentValue;
		}
		set{ _currentValue = value;}
	}
}

/// <summary>
/// This enumeration is just a list of the vitals our character will have
/// </summary>
public enum VitalName {
	Health,
	Stamina,
	Mana 
}		
	