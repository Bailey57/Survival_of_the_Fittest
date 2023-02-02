using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Organism : MonoBehaviour
{

    public float health;

    //public float 

    public float energy;

    public float age;





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SecondPassed();

    }


    void SecondPassed() 
    {
        WaitASecond();
        //this.energy--;
        this.age++;
    }



    IEnumerator WaitASecond()
    {
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        yield return new WaitForSeconds(1);
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

    

}
