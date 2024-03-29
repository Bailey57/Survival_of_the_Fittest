using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Organism : MonoBehaviour
{

    public string organismName;

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

    public string OrganismToString() 
    {
        string outputStr = "\n";
        outputStr += "name:" + organismName + "\n\n";
        outputStr += "health: " + health + "\n\n";
        outputStr += "energy: " + energy + "\n\n";
        outputStr += "age: " + age + "\n\n";



        return outputStr;


    }


    IEnumerator EnergyDrain()
    {
        while (true)
        {
            //Debug.Log("waited for 1 sec");
            yield return new WaitForSeconds(1);
            energy -= .15f;


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
