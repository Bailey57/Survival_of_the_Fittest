using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlantSave
{
    

    //game object
    public float x, y;
    public float rotation;

    //Plant
    public float condition;

    public float nutreance;

    public float age;


    public PlantSave MakePlantSave(GameObject inGamePlant)
    {
        PlantSave plantSave = new PlantSave();


        //game object
        plantSave.x = inGamePlant.gameObject.transform.position.x;
        plantSave.y = inGamePlant.gameObject.transform.position.y;
        plantSave.rotation = inGamePlant.gameObject.transform.rotation.z;

        //Plant
        plantSave.condition = (inGamePlant.gameObject.GetComponent("Plant") as Plant).condition;
        plantSave.nutreance = (inGamePlant.gameObject.GetComponent("Plant") as Plant).nutreance;
        plantSave.age = (inGamePlant.gameObject.GetComponent("Plant") as Plant).age;



        Debug.Log("plantSave: " + plantSave);
        return plantSave;
    }




}
