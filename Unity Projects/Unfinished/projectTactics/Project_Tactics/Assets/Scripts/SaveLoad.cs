using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoad : MonoBehaviour {

	public static SaveLoad saveLoad;

	public GameObject[] playerGuild;

	// Use this for initialization
	void Awake () {
		if (saveLoad == null) {
			DontDestroyOnLoad(gameObject);
			saveLoad = this;
		}
		else if(saveLoad != this){
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	public void Save () {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerInfo.dat");

		PlayerData data = new PlayerData ();
		data.playerGuild = playerGuild;

		bf.Serialize (file, data);
		file.Close ();
	}

	public void Load () {

		if(File.Exists (Application.persistentDataPath + "/playerInfo.dat")){
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize (file);
			file.Close ();

			playerGuild = data.playerGuild;
		}
	}
}

[Serializable]
class PlayerData {

	public GameObject[] playerGuild;
}