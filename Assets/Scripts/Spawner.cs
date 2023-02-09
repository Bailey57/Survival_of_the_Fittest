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
        


    }

    // Update is called once per frame
    void Update()
    {
        

    }

    IEnumerator SpawnPlant() 
    {
        while (true) 
        {
            Debug.Log("waited for 3 sec");
            yield return new WaitForSeconds(3);
            


        }
        
    }




}
