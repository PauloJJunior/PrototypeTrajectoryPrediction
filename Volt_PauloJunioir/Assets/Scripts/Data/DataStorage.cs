using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

// This class is responsible for storing the data that will be consumed and permanently saved on the device.
public class DataStorage : MonoBehaviour
{

    // Declare a static instance
    public static DataStorage instance;

    /// The persistent player data
    public static DataCloud playerData;


    private void Awake()
    {
        // Tests if the class has already been instantiated, in addition to not destroying the current instance.
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);


        // Load playerData
        playerData = LoadData();


    }


    private void OnDestroy()
    {
        // Save PlayerData every time the class is destroyed.
        SaveData(playerData);
    }

    //Class responsible for saving data in the date.sv file
    public void SaveData(DataCloud data)
    {
        //Test Plataform Android and determine applicationPath
        string applicationPath;
        if (Application.platform == RuntimePlatform.Android)
            applicationPath = Application.persistentDataPath;
        else
            applicationPath = Application.dataPath;

        //Turns the DataCloud class into a json string.
        string json = JsonUtility.ToJson(data);

        //Save in File.
        StreamWriter tw = new StreamWriter(applicationPath + "/data.sv");
        tw.Write(json);
        tw.Close();
        Debug.Log("Saving as JSON: " + json);
    }


    //Class responsible for load date.sv file
    public DataCloud LoadData()
    {
        //Test Plataform Android and determine applicationPath
        string applicationPath;
        if (Application.platform == RuntimePlatform.Android)
            applicationPath = Application.persistentDataPath;
        else
            applicationPath = Application.dataPath;

        //Test if file exists, if there is no instance a new DataCloud
        if (!File.Exists(applicationPath + "/data.sv"))
            return new DataCloud();


        //Read the file information.
        TextReader tr = new StreamReader(applicationPath + "/data.sv");
        string json = tr.ReadToEnd();
        tr.Close();

        Debug.Log("Load as JSON: " + json);

        //Serializes the reading in the data class.
        DataCloud data = JsonUtility.FromJson<DataCloud>(json);

        return data;
    }


    ////Class responsible for reset all persistent date
    public void ResetData()
    {
        //Test Plataform Android and determine applicationPath
        string applicationPath;
        if (Application.platform == RuntimePlatform.Android)
            applicationPath = Application.persistentDataPath;
        else
            applicationPath = Application.dataPath;

        //Test if file exists, if there is no delete file
        if (File.Exists(applicationPath + "/data.sv"))
            File.Delete(applicationPath + "/data.sv");

        //Delete all PlayerPrefs
        PlayerPrefs.DeleteAll();

        //Instance a new DataCloud
        playerData = new DataCloud();
    }
}
