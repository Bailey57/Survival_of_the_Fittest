using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update

    //organism1_32x32
    //GameObject newObject = (GameObject)Instantiate(Resources.Load("organism1_32x32"));

    [SerializeField] GameObject statistics;


    void Start()
    {
        
            
        StartCoroutine(SpawnPlant());
        StartCoroutine(SpawnOrganism());
        //SpawnOrganism()


    }

    // Update is called once per frame
    void Update()
    {
        

    }

    IEnumerator SpawnPlant() 
    {
        while (true) 
        {
            //Debug.Log("waited for 20 sec");
            yield return new WaitForSeconds(40);


            GameObject newObject = (GameObject)Instantiate(Resources.Load("Prefabs/plant1_32x32"));
            float randX = Random.Range(-15, 15);
            float randY = Random.Range(-15, 15);


            newObject.transform.position = new Vector3(randX, randY, 0);


        }
        
    }


    IEnumerator SpawnOrganism()
    {
        while (true)
        {
            yield return new WaitForSeconds(20);
            //if less than 5 organisms, a new one spawns
            if ((statistics.gameObject.GetComponent("Statistics") as Statistics).numOfOrganisms < 10) 
            {
                //Debug.Log("waited for 20 sec");
                


                GameObject newObject = (GameObject)Instantiate(Resources.Load("Prefabs/organism1_32x32"));
                (newObject.GetComponent(typeof(Organism)) as Organism).energy = 100;
                (newObject.GetComponent(typeof(Genetics)) as Genetics).deathAge = 1000;
                float randX = Random.Range(-15, 15);
                float randY = Random.Range(-15, 15);
                newObject.transform.position = new Vector3(randX, randY, 0);


            }
            


        }

    }



}
