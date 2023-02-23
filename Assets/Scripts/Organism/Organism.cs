using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Organism : MonoBehaviour
{

    

    public float health;

    //public float fatStorage;

    public float energy;

    public float age;





    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnergyDrain());
        StartCoroutine(AgeIncease());
        
        

    }

    // Update is called once per frame
    void Update()
    {
        //tmp solution
        //energy -= .00001f;
        //age += .00001f;
        //SecondPassed();

    }




    IEnumerator EnergyDrain()
    {
        while (true)
        {
            Debug.Log("waited for 20 sec");
            yield return new WaitForSeconds(1);
            energy -= .01f;


        }

    }

    IEnumerator AgeIncease()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            age += 1;


        }

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
