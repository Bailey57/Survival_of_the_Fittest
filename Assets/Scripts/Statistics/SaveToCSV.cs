using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;
using TMPro;

public class SaveToCSV : MonoBehaviour
{
    //links:
    //https://www.makeuseof.com/csv-file-c-sharp-save-data/
    //https://docs.unity3d.com/ScriptReference/Hash128.html


    [SerializeField] GameObject statistics;

    public TMP_Text textMeshTxt;

    private int worldNumber = 0;

    private string fileName = "";

    public string debugStr = "Debug:\n\n";




    // Start is called before the first frame update
    void Start()
    {
        worldNumber = UnityEngine.Random.Range(-10000000, 10000000);

        //generate world name hash
        //GenerateWorldNameHash();

        MakeCSVFileDirectory();
        MakeFileName();
        MakeCSVFile();

        StartCoroutine(SaveToCSVFileAuto());
    }



    // Update is called once per frame
    void Update()
    {
        textMeshTxt.text = debugStr;


    }


    public void AddToDebug(string input) 
    {
        debugStr += input + "\n\n";


    }


    public void MakeCSVFile() 
    {
        File.AppendText(fileName);

    }

    public void MakeFileName() 
    {
        //(statistics.gameObject.GetComponent("Statistics") as Statistics).GetGameTimeSimpleToString();
        //make names from hash
        var dt = DateTime.Now;
        string dateAndTimeStr = dt.ToLongDateString() + "_" + dt.ToLongTimeString();
        //worldNumber
        //dateAndTimeStr
        
        fileName = Directory.GetCurrentDirectory() + @"\CSV_files\world_" + DateTime.Now.ToString("yyyy-MM-dd_hh.mm.ss") + ".csv";
        Debug.Log(fileName);
        AddToDebug(fileName);

    }


    public void MakeCSVFileDirectory() 
    {
        try
        {
     
            string path = Directory.GetCurrentDirectory() + @"\CSV_files";
            Debug.Log(path);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

        }
        catch (Exception e)
        {
            Console.WriteLine("Failed to make file path", e.ToString());
            Debug.Log("Failed to make file path");
            AddToDebug("Failed to make file path");
        }
        




    }

    public void SaveToCSVFile() 
    {
        string outStr = "";

        outStr += "simulationTime,numOfOrganisms,numOfPlants,maxNumOfOrganisms,maxNumOfPlants,longestLastingGenNum,numberOfChildren\n";


        for (int i = 0; i < (statistics.gameObject.GetComponent("Statistics") as Statistics).dataOverTime.Count; i++) 
        {
            outStr += (statistics.gameObject.GetComponent("Statistics") as Statistics).dataOverTime[i].simulationTime + ",";

            outStr += (statistics.gameObject.GetComponent("Statistics") as Statistics).dataOverTime[i].numOfOrganisms + ",";
            outStr += (statistics.gameObject.GetComponent("Statistics") as Statistics).dataOverTime[i].numOfPlants + ",";
            outStr += (statistics.gameObject.GetComponent("Statistics") as Statistics).dataOverTime[i].maxnumOfOrganisms + ",";
            outStr += (statistics.gameObject.GetComponent("Statistics") as Statistics).dataOverTime[i].maxNumOfPlants + ",";
            outStr += (statistics.gameObject.GetComponent("Statistics") as Statistics).dataOverTime[i].longestLastingGenNum + ",";
            outStr += (statistics.gameObject.GetComponent("Statistics") as Statistics).dataOverTime[i].numberOfChildren + ",";
            
            outStr += "\n";
        }

        Debug.Log(outStr);
        AddToDebug(outStr);
        try 
        {
            //File.AppendAllText(fileName, outStr);
            File.WriteAllText(fileName, outStr);
            Debug.Log("Wrote to file");
            AddToDebug("Wrote to file");
        }
        catch(Exception ex) 
        {
            Debug.Log("Couldnt Write to file");
            AddToDebug("Couldnt Write to file");
            return;
        }

    }




    public string GetOutputForCSVFile()
    {
        string outStr = "";

        outStr += "simulationTime,numOfOrganisms,numOfPlants,maxNumOfOrganisms,maxNumOfPlants,longestLastingGenNum,numberOfChildren\n";


        for (int i = 0; i < (statistics.gameObject.GetComponent("Statistics") as Statistics).dataOverTime.Count; i++)
        {
            outStr += (statistics.gameObject.GetComponent("Statistics") as Statistics).dataOverTime[i].simulationTime + ",";

            outStr += (statistics.gameObject.GetComponent("Statistics") as Statistics).dataOverTime[i].numOfOrganisms + ",";
            outStr += (statistics.gameObject.GetComponent("Statistics") as Statistics).dataOverTime[i].numOfPlants + ",";
            outStr += (statistics.gameObject.GetComponent("Statistics") as Statistics).dataOverTime[i].maxnumOfOrganisms + ",";
            outStr += (statistics.gameObject.GetComponent("Statistics") as Statistics).dataOverTime[i].maxNumOfPlants + ",";
            outStr += (statistics.gameObject.GetComponent("Statistics") as Statistics).dataOverTime[i].longestLastingGenNum + ",";
            outStr += (statistics.gameObject.GetComponent("Statistics") as Statistics).dataOverTime[i].numberOfChildren + ",";

            outStr += "\n";
        }

        return outStr;

    }

    public string GetOutputForCSVFileWithFamilyTree()
    {
        string outStr = "";

        outStr += "simulationTime,numOfOrganisms,numOfPlants,maxNumOfOrganisms,maxNumOfPlants,longestLastingGenNum,numberOfChildren\n";


        for (int i = 0; i < (statistics.gameObject.GetComponent("Statistics") as Statistics).dataOverTime.Count; i++)
        {
            outStr += (statistics.gameObject.GetComponent("Statistics") as Statistics).dataOverTime[i].simulationTime + ",";

            outStr += (statistics.gameObject.GetComponent("Statistics") as Statistics).dataOverTime[i].numOfOrganisms + ",";
            outStr += (statistics.gameObject.GetComponent("Statistics") as Statistics).dataOverTime[i].numOfPlants + ",";
            outStr += (statistics.gameObject.GetComponent("Statistics") as Statistics).dataOverTime[i].maxnumOfOrganisms + ",";
            outStr += (statistics.gameObject.GetComponent("Statistics") as Statistics).dataOverTime[i].maxNumOfPlants + ",";
            outStr += (statistics.gameObject.GetComponent("Statistics") as Statistics).dataOverTime[i].longestLastingGenNum + ",";
            outStr += (statistics.gameObject.GetComponent("Statistics") as Statistics).dataOverTime[i].numberOfChildren + ",";

            outStr += "\n";
        }

        return outStr;

    }






    public void SaveToFile(string outStr) 
    {
        Debug.Log(outStr);
        AddToDebug(outStr);
        try
        {
            //File.AppendAllText(fileName, outStr);
            File.WriteAllText(fileName, outStr);
            Debug.Log("Wrote to file");
            AddToDebug("Wrote to file");
        }
        catch (Exception ex)
        {
            Debug.Log("Couldnt Write to file");
            AddToDebug("Couldnt Write to file");
            return;
        }
    }

    IEnumerator SaveToCSVFileAuto()
    {
        while (true) 
        {
            //(statistics.gameObject.GetComponent("Statistics") as Statistics).

            yield return new WaitForSeconds(600);//600 sec = 10 min
            //yield return new WaitForSeconds(10);//10 sec for testing
            //SaveToCSVFile();
            //SaveToCSVFileWithFamilyTree();

            //GetOutputForCSVFileWithFamilyTree
            string outStr = GetOutputForCSVFile();

            SaveToFile(outStr);


        }
        
    }

}
