/// <summary>
/// Modified stat.cs
/// Darren Wiltse
/// Aug 17, 2012
/// 
/// This is the base class for all the stats that will be modifiable by the attributes
/// </summary>

using System.Collections.Generic;				//Generic was added so we can use the Lists<>
	
public class ModifiedStat : BaseStat  {
	private List<modifyingAttribute> _mods;		//A list of attributs that modify this stat
	private int _ModValue; 						//The amount added to the base value from the modifiers 
	
	/// <summary>
	/// Initializes a new instance of the <see cref="ModifiedStat"/> class.
	/// </summary>
	public ModifiedStat(){
		UnityEngine.Debug.Log("Modified Created");
		_mods = new List<modifyingAttribute>();
		_ModValue = 0; 
	}
	
	/// <summary>
	/// Add a modifying attribute to our list of mods for this ModifiedStat
	/// </summary>
	/// <param name='mod'>
	/// Mod.
	/// </param>
	public void AddModifier(modifyingAttribute mod){
		_mods.Add(mod);
	}
	
	/// <summary>
	/// Reset _modValue to 0.
	/// Check to see if we have at least one modifying attribut in our list of mods
	/// If we do then iterate through the list and add the AdjustedBaseValue * ratio to our modValue
	/// </summary>
	private void CalculateModValue() {
		_ModValue = 0;
		
		if(_mods.Count > 0)
			foreach (modifyingAttribute att in _mods)
				_ModValue += (int)(att.attribute.AdjustedBaseValue * att.ratio); 
	}
	
	/// <summary>
	/// This function is overwriting the AdjustedBaseValue in the BaseStat class.
	/// Calculate the AdjustedBaseValue from the BaseValue + BuffValue + _midValue
	/// </summary>
	/// <value>
	/// The adjusted base value.
	/// </value>
	public new int AdjustedBaseValue {
				get{ return BaseValue + BuffValue + _ModValue; }

	}
	
	/// <summary>
	/// Update this instance.
	/// </summary>
	public void update(){
		CalculateModValue();
	}
	
	public string GetModifyingAttributeString(){
		string temp = "";
		
//		UnityEngine.Debug.Log(_mods.Count);

		
		for(int cnt = 0; cnt < _mods.Count; cnt++) {
			temp += _mods[cnt].attribute.Name;
			temp += "_";
			temp += _mods[cnt].ratio;
			
			if(cnt < _mods.Count - 1)
				temp += "|"; 	
		}
		
		UnityEngine.Debug.Log(temp);
		
		return temp;
	}
}

/// <summary>
/// A structure that will hold an Attribute and a ration that will be added as a modifying attribute to our ModifiedStats
/// </summary>
public struct modifyingAttribute{
	public Attribute attribute;			//the attribute to be used as a modifier
	public float ratio; 				//the percent of the attributes AdjustedBaseValue that will be applied to the ModifiedStat
	
	/// <summary>
	/// Initializes a new instance of the <see cref="modifyingAttribute"/> struct.
	/// </summary>
	/// <param name='att'>
	/// Att. the attribute to be used
	/// </param>
	/// <param name='rat'>
	/// Rat. the ratio to use
	/// </param>
	public modifyingAttribute(Attribute att, float rat) {
		UnityEngine.Debug.Log("Modifying Attribute Created");
		attribute = att;
		ratio = rat;
	}
}
