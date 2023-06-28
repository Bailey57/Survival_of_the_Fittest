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
using UnityEngine.SceneManagement;
using System.Diagnostics;
using SFB;

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
        //filePath = EditorUtility.OpenFilePanel("Saves", Directory.GetCurrentDirectory() + @"\GameSave_files", "sotf");

        //ProcessStartInfo StartInformation = new ProcessStartInfo();

        //StartInformation.FileName = Directory.GetCurrentDirectory() + @"\GameSave_files";

        //Process process = Process.Start(StartInformation);

        //process.EnableRaisingEvents = true;


        string[] path = StandaloneFileBrowser.OpenFilePanel("Saves", Directory.GetCurrentDirectory() + @"\GameSave_files", "sotf", false);
        filePath = path[0];
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


            //loads blank scene 1
            //SceneManager.LoadScene(1);

            //spawn all the organisms
            LoadOrganisms(gameData);

            LoadPlants(gameData);
            LoadStats(gameData);
            //LoadFamilyTree








            UnityEngine.Debug.Log("Loaded save! " + gameData.organisms[0].organismName);
            stream.Close();
            
            //return newGameData;
        }
        else 
        {
            UnityEngine.Debug.LogError("Save file not found " + filePath);
            //return null;
        }

    }


    public void LoadOrganisms(GameData gameData) 
    {
        for (int i = 0; i < gameData.organisms.Count; i++)
        {
            //gameData.organisms[i]
            GameObject newObject = (GameObject)Instantiate(Resources.Load("Prefabs/organism1_32x32"));
            newObject.transform.position = new Vector3(gameData.organisms[i].x, gameData.organisms[i].y, 0);
            //newObject.transform.rotation = Quaternion.Euler(0, 0, gameData.organisms[i].rotation);
            newObject.transform.rotation.Set(0, 0, gameData.organisms[i].rotation, 0);

            newObject.name = gameData.organisms[i].organismName;
            (newObject.GetComponent(typeof(Organism)) as Organism).organismName = gameData.organisms[i].organismName;
            (newObject.GetComponent(typeof(Organism)) as Organism).health = gameData.organisms[i].health;
            (newObject.GetComponent(typeof(Organism)) as Organism).energy = gameData.organisms[i].energy;
            (newObject.GetComponent(typeof(Organism)) as Organism).age = gameData.organisms[i].age;




            (newObject.GetComponent(typeof(Genetics)) as Genetics).generationNum = gameData.organisms[i].generationNum;
            (newObject.GetComponent(typeof(Genetics)) as Genetics).agility = gameData.organisms[i].agility;
            (newObject.GetComponent(typeof(Genetics)) as Genetics).metabolism = gameData.organisms[i].metabolism;
            (newObject.GetComponent(typeof(Genetics)) as Genetics).eggLayingAge = gameData.organisms[i].eggLayingAge;
            (newObject.GetComponent(typeof(Genetics)) as Genetics).visualDistance = gameData.organisms[i].visualDistance;
            (newObject.GetComponent(typeof(Genetics)) as Genetics).visualAngle = gameData.organisms[i].visualAngle;
            (newObject.GetComponent(typeof(Genetics)) as Genetics).maxHealth = gameData.organisms[i].maxHealth;
            (newObject.GetComponent(typeof(Genetics)) as Genetics).deathAge = gameData.organisms[i].deathAge;
            (newObject.GetComponent(typeof(Genetics)) as Genetics).physicalRange = gameData.organisms[i].physicalRange;

            (newObject.GetComponent(typeof(Brain)) as Brain).neuronLayers = gameData.organisms[i].neuronLayers;

            UnityEngine.Debug.Log("organismSave loaded: " + (newObject.GetComponent(typeof(Organism)) as Organism).organismName);
        }



    }

    public void LoadPlants(GameData gameData)
    {
        for (int i = 0; i < gameData.plants.Count; i++)
        {
            GameObject newObject = (GameObject)Instantiate(Resources.Load("Prefabs/plant1_32x32"));
            newObject.transform.position = new Vector3(gameData.plants[i].x, gameData.plants[i].y, 0);
            //newObject.transform.rotation = Quaternion.Euler(0, 0, gameData.plants[i].rotation);
            newObject.transform.rotation.Set(0, 0, gameData.plants[i].rotation, 0);
            (newObject.GetComponent(typeof(Plant)) as Plant).condition = gameData.plants[i].condition;
            (newObject.GetComponent(typeof(Plant)) as Plant).nutreance = gameData.plants[i].nutreance;
            (newObject.GetComponent(typeof(Plant)) as Plant).age = gameData.plants[i].age;

        }
    }

    public void LoadStats(GameData gameData) 
    {
        List<GameObject> rootObjects = new List<GameObject>();
        Scene scene = SceneManager.GetActiveScene();
        scene.GetRootGameObjects(rootObjects);
        for (int i = 0; i < rootObjects.Count; i++)
        {
            if ((rootObjects[i].gameObject.GetComponent("Statistics") as Statistics)) 
            {
                ((rootObjects[i].gameObject.GetComponent(typeof(Statistics)) as Statistics)).numOfOrganisms = gameData.statisticsSave.numOfOrganisms;
                ((rootObjects[i].gameObject.GetComponent(typeof(Statistics)) as Statistics)).numOfPlants = gameData.statisticsSave.numOfPlants;
                ((rootObjects[i].gameObject.GetComponent(typeof(Statistics)) as Statistics)).maxnumOfOrganisms = gameData.statisticsSave.maxnumOfOrganisms;
                ((rootObjects[i].gameObject.GetComponent(typeof(Statistics)) as Statistics)).maxNumOfPlants = gameData.statisticsSave.maxNumOfPlants;
                ((rootObjects[i].gameObject.GetComponent(typeof(Statistics)) as Statistics)).longestLastingGenNum = gameData.statisticsSave.longestLastingGenNum;
                ((rootObjects[i].gameObject.GetComponent(typeof(Statistics)) as Statistics)).numberOfChildren = gameData.statisticsSave.numberOfChildren;
                ((rootObjects[i].gameObject.GetComponent(typeof(Statistics)) as Statistics)).simulationTime = gameData.statisticsSave.simulationTime;
                ((rootObjects[i].gameObject.GetComponent(typeof(Statistics)) as Statistics)).dataOverTime = gameData.statisticsSave.dataOverTime;
                ((rootObjects[i].gameObject.GetComponent(typeof(Statistics)) as Statistics)).numberOfOverallOrganisms = gameData.statisticsSave.numberOfOverallOrganisms;

            }



        }

            //gameData.statisticsSave



        }
    public void LoadFamilyTree()
    {


    }


    public void MakeSaveFileDirectory()
    {
        try
        {

            string path = Directory.GetCurrentDirectory() + @"\GameSave_files";
            //UnityEngine.Debug.Log(path);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                //UnityEngine.Debug.Log("Created \\GameSave_files path");
            }

        }
        catch (Exception e)
        {
            Console.WriteLine("Failed to make file path", e.ToString());
            //UnityEngine.Debug.Log("Failed to make file path");
            //AddToUnityEngine.Debug("Failed to make file path");
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
        UnityEngine.Debug.Log(filePath);
        //AddToUnityEngine.Debug(filePath);
    }

}
