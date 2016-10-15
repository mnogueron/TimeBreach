using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class LoadSaveManager : MonoBehaviour {

    public static LoadSaveManager instance;

	// Use this for initialization
	void Awake () {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
	
	public static void Save(PlayerData data)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        bf.Serialize(file, data);
        file.Close();
    }

    public static PlayerData Load()
    {
        PlayerData data = null;
        if (IsSaveAvailable())
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            data = (PlayerData)bf.Deserialize(file);
            file.Close();
        }
        return data;
    }

    public static bool IsSaveAvailable()
    {
        return File.Exists(Application.persistentDataPath + "/playerInfo.dat");
    }
}

[Serializable]
public class PlayerData {

    public string sceneName;
    public bool playerHasOrb;
    public bool isCheckpoint;
    public int checkpointID;

}
