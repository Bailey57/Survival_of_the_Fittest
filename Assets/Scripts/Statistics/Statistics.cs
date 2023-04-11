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

    public float simulationTime;


    public FamilyTree familyTree;



    public string StatsToString() 
    {
        string output = "";
        output += "numOfOrganisms: " + numOfOrganisms + "\n\n";
        output += "numOfPlants: " + numOfPlants + "\n\n";
        output += "maxnumOfOrganisms: " + maxnumOfOrganisms + "\n\n";
        output += "maxNumOfPlants: " + maxNumOfPlants + "\n\n";
        output += "longestLastingGenNum: " + longestLastingGenNum + "\n\n";


        return output;
    }


    void Start()
    {
        //StartCoroutine(UpdateStatistics());
    }
    
    // Update is called once per frame
    void Update()
    {
        //updateMaxNumOfOrganisms();
        UpdateStats();
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
