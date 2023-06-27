using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class GameData
{



    //public Statistics statistics;
    public List<OrganismSave> organisms = new List<OrganismSave>();
    public List<PlantSave> plants = new List<PlantSave>();


    private OrganismSave organismSave = new OrganismSave();
    private PlantSave plantSave = new PlantSave();


    public void UpdateGameData()
    {
        organisms = new List<OrganismSave>();
        List<GameObject> rootObjects = new List<GameObject>();
        Scene scene = SceneManager.GetActiveScene();
        scene.GetRootGameObjects(rootObjects);

        for (int i = 0; i < rootObjects.Count; i++)
        {
            if ((rootObjects[i].gameObject.GetComponent("Organism") as Organism))
            {
                Debug.Log("saving: " + (rootObjects[i].gameObject.GetComponent("Organism") as Organism).organismName);
                organisms.Add(organismSave.MakeOrganismSave(rootObjects[i].gameObject));
            }
            else if ((rootObjects[i].gameObject.GetComponent("Plant") as Plant))
            {

                plants.Add(plantSave.MakePlantSave(rootObjects[i].gameObject));
               
            }
        }
    }



    

}
