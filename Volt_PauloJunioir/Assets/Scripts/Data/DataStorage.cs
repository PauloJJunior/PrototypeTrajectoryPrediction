using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class DataStorage : MonoBehaviour
{

    
    public static DataStorage instance;

    /// The persistent player data
    public static DataCloud playerData;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        playerData = LoadData();


    }


    private void OnDestroy()
    {

        SaveData(playerData);
    }


    public void SaveData(DataCloud data)
    {
        //Test Plataform Android
        string applicationPath;
        if (Application.platform == RuntimePlatform.Android)
            applicationPath = Application.persistentDataPath;
        else
            applicationPath = Application.dataPath;

        string json = JsonUtility.ToJson(data);

        StreamWriter tw = new StreamWriter(applicationPath + "/data.sv");
        tw.Write(json);
        tw.Close();
        Debug.Log("Saving as JSON: " + json);
    }


    public DataCloud LoadData()
    {
        //Test Plataform Android
        string applicationPath;
        if (Application.platform == RuntimePlatform.Android)
            applicationPath = Application.persistentDataPath;
        else
            applicationPath = Application.dataPath;

        if (!File.Exists(applicationPath + "/data.sv"))
            return new DataCloud();

        TextReader tr = new StreamReader(applicationPath + "/data.sv");
        string json = tr.ReadToEnd();
        tr.Close();

        Debug.Log("Load as JSON: " + json);

        DataCloud data = JsonUtility.FromJson<DataCloud>(json);

        return data;
    }


    public void ResetData()
    {
        //Teste Plataform Android
        string applicationPath;
        if (Application.platform == RuntimePlatform.Android)
            applicationPath = Application.persistentDataPath;
        else
            applicationPath = Application.dataPath;

        if (File.Exists(applicationPath + "/data.sv"))
            File.Delete(applicationPath + "/data.sv");

        PlayerPrefs.DeleteAll();

        playerData = new DataCloud();
    }
}
