using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;
using TMPro;
using System.Runtime.InteropServices.ComTypes;
using UnityEditor;





public class SaveSystem : MonoBehaviour
{

    private string filePath = "";
    public GameData gameData;


    // Start is called before the first frame update
    void Start()
    {
        MakefilePath();
        MakeSaveFileDirectory();


    }

    

    // Update is called once per frame
    void Update()
    {
        
    }



    //(statistics.gameObject.GetComponent("Statistics") as Statistics).GetGameTimeSimpleToString()


    //auto save every once in a while 



    public void SaveGame() 
    {
        BinaryFormatter bf = new BinaryFormatter();
        //string path = ".sotf";

        FileStream stream = new FileStream(filePath, FileMode.Create);

        gameData.UpdateGameData();


        //Formatter.Serialize(stream, gd);
        bf.Serialize(stream, gameData);
        stream.Close();
    }



    private void GetFile() 
    {
        filePath = EditorUtility.OpenFilePanel("Saves", Directory.GetCurrentDirectory() + @"\GameSave_files", "sotf");


    }




    public void LoadGame() 
    {
        GetFile();
        //GetFile();

        if (File.Exists(filePath))
        {
            BinaryFormatter bf = new BinaryFormatter();




            FileStream stream = new FileStream(filePath, FileMode.Open);



            gameData = bf.Deserialize(stream) as GameData;

            Debug.Log("Loaded save! " + gameData.organisms[0].organismName);
            stream.Close();
            
            //return newGameData;
        }
        else 
        {
            Debug.LogError("Save file not found " + filePath);
            //return null;
        }

    }


    public void MakeSaveFileDirectory()
    {
        try
        {

            string path = Directory.GetCurrentDirectory() + @"\GameSave_files";
            Debug.Log(path);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                Debug.Log("Created \\GameSave_files path");
            }

        }
        catch (Exception e)
        {
            Console.WriteLine("Failed to make file path", e.ToString());
            Debug.Log("Failed to make file path");
            //AddToDebug("Failed to make file path");
        }

    }



    public void MakefilePath()
    {
        //(statistics.gameObject.GetComponent("Statistics") as Statistics).GetGameTimeSimpleToString();
        //make names from hash
        var dt = DateTime.Now;
        string dateAndTimeStr = dt.ToLongDateString() + "_" + dt.ToLongTimeString();
        //worldNumber
        //dateAndTimeStr

        filePath = Directory.GetCurrentDirectory() + @"\GameSave_files\world_" + DateTime.Now.ToString("yyyy-MM-dd_hh.mm.ss") + ".sotf";
        Debug.Log(filePath);
        //AddToDebug(filePath);
    }

}
