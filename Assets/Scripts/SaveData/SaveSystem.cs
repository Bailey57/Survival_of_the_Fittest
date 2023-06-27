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

public class SaveSystem : MonoBehaviour
{

    private string fileName = "";
    public GameData gameData;


    // Start is called before the first frame update
    void Start()
    {
        MakeFileName();
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
        string path = ".sotf";

        FileStream stream = new FileStream(fileName, FileMode.Create);

        gameData.UpdateGameData();


        //Formatter.Serialize(stream, gd);
        bf.Serialize(stream, gameData);
        stream.Close();
    }






    public void LoadGame() 
    {
        
    
    
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



    public void MakeFileName()
    {
        //(statistics.gameObject.GetComponent("Statistics") as Statistics).GetGameTimeSimpleToString();
        //make names from hash
        var dt = DateTime.Now;
        string dateAndTimeStr = dt.ToLongDateString() + "_" + dt.ToLongTimeString();
        //worldNumber
        //dateAndTimeStr

        fileName = Directory.GetCurrentDirectory() + @"\GameSave_files\world_" + DateTime.Now.ToString("yyyy-MM-dd_hh.mm.ss") + ".sotf";
        Debug.Log(fileName);
        //AddToDebug(fileName);
    }

}