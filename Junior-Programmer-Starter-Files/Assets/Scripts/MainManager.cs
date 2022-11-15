using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static MainManager Instance;

    public Color teamColor;

    private void Awake()
    {

        LoadColor();

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        
    }

    [System.Serializable]
    class SaveData
    {
        public Color TeamColor;
    }

    public void SaveColor() 
    {
        SaveData data = new SaveData();
        data.TeamColor = teamColor;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            teamColor = data.TeamColor;
        }

        
    }
}
