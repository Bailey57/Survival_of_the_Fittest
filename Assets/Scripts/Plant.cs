using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public GameObject inGamePlant;


    public float condition;

    public float nutreance;

    public float age;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (condition <= 0 || nutreance <= 0) 
        {
            inGamePlant.SetActive(false);
            Destroy(inGamePlant);

        }
        
    }
}
