using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Statistics : MonoBehaviour
{
    // Start is called before the first frame update

    //lists stats of current sim:
    //num of organisms
    //num of plants
    public int numOfOrganisms;

    public int numOfPlants;


    public int maxnumOfOrganisms;

    public int maxNumOfPlants;


    public int longestLastingGenNum;

    public int simulationTime;//in seconds


    public List<(int numOfOrganisms, int numOfPlants, int maxnumOfOrganisms, int maxNumOfPlants, int longestLastingGenNum, int simulationTime)> dataOverTime = new List<(int numOfOrganisms, int numOfPlants, int maxnumOfOrganisms, int maxNumOfPlants, int longestLastingGenNum, int simulationTime)>();


    public FamilyTree familyTree;



    public string StatsToString() 
    {
        string output = "";
        output += "numOfOrganisms: " + numOfOrganisms + "\n\n";
        output += "numOfPlants: " + numOfPlants + "\n\n";
        output += "maxnumOfOrganisms: " + maxnumOfOrganisms + "\n\n";
        output += "maxNumOfPlants: " + maxNumOfPlants + "\n\n";
        output += "longestLastingGenNum: " + longestLastingGenNum + "\n\n";

        output += TimeToString(simulationTime) + "\n\n";

        return output;
    }


    void Start()
    {
        //StartCoroutine(UpdateStatistics());
        StartCoroutine(UpdateTimePassed());
        StartCoroutine(AppendTODataOverTime());

       
    }
    
    // Update is called once per frame
    void Update()
    {
        //updateMaxNumOfOrganisms();
        UpdateStats();
    }

    IEnumerator AppendTODataOverTime() 
    {
        while (true) 
        {
            yield return new WaitForSeconds(1);
            dataOverTime.Add((numOfOrganisms, numOfPlants, maxnumOfOrganisms, maxNumOfPlants, longestLastingGenNum, simulationTime));
            Debug.Log("Num Of Organisms: " + dataOverTime[dataOverTime.Count - 1].numOfOrganisms);

        }
        

    }


    IEnumerator UpdateTimePassed()
    {
        while (true) 
        {
            yield return new WaitForSeconds(1);
            simulationTime += 1;

        }
        
    }

    public string TimeToString(int seconds) 
    {

        int minuets = seconds / 60;
        int remainderSeconds = seconds % 60;

        int hours = minuets / 60;
        int remainderMin = minuets % 60;

        int days = hours / 24;
        int remainderHrs = hours % 24;

        int weeks = days / 7;
        int remainderDays = days % 7;


        return "Days: " + days + " Hours: " + remainderHrs  + " Minutes: " + remainderMin  + " Seconds: " + remainderSeconds;


    }

    IEnumerator UpdateStatistics() 
    {
        while (true) 
        {
            yield return new WaitForSeconds(1);
            GetNumOfOrganisms();
            GetNumOfPlants();

        }
    

    }

    public void UpdateMaxNumOfOrganisms() 
    {
        int numOfOrganisms = GetNumOfOrganisms();
        if (maxnumOfOrganisms < numOfOrganisms) 
        {
            maxnumOfOrganisms = numOfOrganisms;


        }
    
    
    
    
    }



    public int GetNumOfOrganisms() 
    {
        numOfOrganisms = 0;
        List<GameObject> rootObjects = new List<GameObject>();
        Scene scene = SceneManager.GetActiveScene();
        scene.GetRootGameObjects(rootObjects);

        for (int i = 0; i < rootObjects.Count; ++i)
        {
            if ((rootObjects[i].gameObject.GetComponent("Organism") as Organism)) 
            {

                numOfOrganisms += 1;
                if (numOfOrganisms > maxnumOfOrganisms) 
                {
                    maxnumOfOrganisms = numOfOrganisms;

                }


            }
            
            
        }


        return numOfOrganisms;
    }

    public int GetNumOfPlants() 
    {
        return 0;
    }


    public int UpdateStats()
    {
        numOfOrganisms = 0;
        numOfPlants = 0;
        List<GameObject> rootObjects = new List<GameObject>();
        Scene scene = SceneManager.GetActiveScene();
        scene.GetRootGameObjects(rootObjects);

        for (int i = 0; i < rootObjects.Count; ++i)
        {
            if ((rootObjects[i].gameObject.GetComponent("Organism") as Organism))
            {

                if ((rootObjects[i].gameObject.GetComponent("Genetics") as Genetics).generationNum > longestLastingGenNum) 
                {
                    longestLastingGenNum = (rootObjects[i].gameObject.GetComponent("Genetics") as Genetics).generationNum;


                }



                numOfOrganisms += 1;
                if (numOfOrganisms > maxnumOfOrganisms)
                {
                    maxnumOfOrganisms = numOfOrganisms;

                }


            }
            else if ((rootObjects[i].gameObject.GetComponent("Plant") as Plant)) 
            {
                numOfPlants += 1;
                if (numOfPlants > maxNumOfPlants)
                {
                    maxNumOfPlants = numOfPlants;

                }

            }


        }


        return 0;
    }
}
