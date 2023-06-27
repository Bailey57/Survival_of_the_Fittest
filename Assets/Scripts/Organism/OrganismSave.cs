using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OrganismSave
{

    //game object
    public float x, y;
    public float rotation;

    //body parts


    //organism
    public string organismName;

    public float health;

    public float energy;

    public float age;


    //Genetics
    public int generationNum;

    public float agility;

    public float metabolism;

    public float eggLayingAge;

    public float visualDistance;

    public float visualAngle;

    public float maxHealth;

    public float deathAge;

    public float physicalRange;


    //brain
    public List<List<Neuron>> neuronLayers = new List<List<Neuron>>();





    
    public OrganismSave MakeOrganismSave(GameObject inGameOrganism) 
    {
        OrganismSave organismSave = new OrganismSave();


        //game object
        organismSave.x = inGameOrganism.gameObject.transform.position.x;
        organismSave.y = inGameOrganism.gameObject.transform.position.y;
        organismSave.rotation = inGameOrganism.gameObject.transform.rotation.z;

        //Organism
        organismSave.organismName = (inGameOrganism.gameObject.GetComponent("Organism") as Organism).organismName;
        organismSave.health = (inGameOrganism.gameObject.GetComponent("Organism") as Organism).health;
        organismSave.energy = (inGameOrganism.gameObject.GetComponent("Organism") as Organism).energy;
        organismSave.age = (inGameOrganism.gameObject.GetComponent("Organism") as Organism).age;



        //Genetics
        organismSave.generationNum = (inGameOrganism.gameObject.GetComponent("Genetics") as Genetics).generationNum;
        organismSave.agility = (inGameOrganism.gameObject.GetComponent("Genetics") as Genetics).agility;
        organismSave.metabolism = (inGameOrganism.gameObject.GetComponent("Genetics") as Genetics).metabolism;
        organismSave.eggLayingAge = (inGameOrganism.gameObject.GetComponent("Genetics") as Genetics).eggLayingAge;
        organismSave.visualDistance = (inGameOrganism.gameObject.GetComponent("Genetics") as Genetics).visualDistance;
        organismSave.visualAngle = (inGameOrganism.gameObject.GetComponent("Genetics") as Genetics).visualAngle;
        organismSave.maxHealth = (inGameOrganism.gameObject.GetComponent("Genetics") as Genetics).maxHealth;
        organismSave.deathAge = (inGameOrganism.gameObject.GetComponent("Genetics") as Genetics).deathAge;
        organismSave.physicalRange = (inGameOrganism.gameObject.GetComponent("Genetics") as Genetics).physicalRange;



 

        //Brain
        organismSave.neuronLayers = (inGameOrganism.gameObject.GetComponent("Brain") as Brain).neuronLayers;


        Debug.Log("organismSave: " + organismSave);
        return organismSave;
    }





    public void LoadSaveOrganism(GameObject inGameOrganism)
    {



        //game object
        inGameOrganism.transform.position = new Vector3(this.x, this.y, 0);
        inGameOrganism.transform.rotation = Quaternion.Euler(0, 0, this.rotation);
        /*
        //Organism
        organismSave.organismName = (inGameOrganism.gameObject.GetComponent("Organism") as Organism).organismName;
        organismSave.health = (inGameOrganism.gameObject.GetComponent("Organism") as Organism).health;
        organismSave.energy = (inGameOrganism.gameObject.GetComponent("Organism") as Organism).energy;
        organismSave.age = (inGameOrganism.gameObject.GetComponent("Organism") as Organism).age;



        //Genetics
        organismSave.generationNum = (inGameOrganism.gameObject.GetComponent("Genetics") as Genetics).generationNum;
        organismSave.agility = (inGameOrganism.gameObject.GetComponent("Genetics") as Genetics).agility;
        organismSave.metabolism = (inGameOrganism.gameObject.GetComponent("Genetics") as Genetics).metabolism;
        organismSave.eggLayingAge = (inGameOrganism.gameObject.GetComponent("Genetics") as Genetics).eggLayingAge;
        organismSave.visualDistance = (inGameOrganism.gameObject.GetComponent("Genetics") as Genetics).visualDistance;
        organismSave.visualAngle = (inGameOrganism.gameObject.GetComponent("Genetics") as Genetics).visualAngle;
        organismSave.maxHealth = (inGameOrganism.gameObject.GetComponent("Genetics") as Genetics).maxHealth;
        organismSave.deathAge = (inGameOrganism.gameObject.GetComponent("Genetics") as Genetics).deathAge;
        organismSave.physicalRange = (inGameOrganism.gameObject.GetComponent("Genetics") as Genetics).physicalRange;





        //Brain
        organismSave.neuronLayers = (inGameOrganism.gameObject.GetComponent("Brain") as Brain).neuronLayers;
        */


      
    }
}
