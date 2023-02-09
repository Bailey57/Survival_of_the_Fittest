using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update



    //organism1_32x32
    //GameObject newObject = (GameObject)Instantiate(Resources.Load("organism1_32x32"));



    void Start()
    {
        StartCoroutine(SpawnPlant());
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
            Debug.Log("waited for 20 sec");
            yield return new WaitForSeconds(40);


            GameObject newObject = (GameObject)Instantiate(Resources.Load("Prefabs/plant1_32x32"));



        }
        
    }


    IEnumerator SpawnOrganism()
    {
        while (true)
        {
            Debug.Log("waited for 20 sec");
            yield return new WaitForSeconds(20);


            GameObject newObject = (GameObject)Instantiate(Resources.Load("Prefabs/organism1_32x32"));
            (newObject.GetComponent(typeof(Organism)) as Organism).energy = 100;
            (newObject.GetComponent(typeof(Genetics)) as Genetics).deathAge = 1000;


        }

    }



}
