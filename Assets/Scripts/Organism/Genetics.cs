using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Genetics : MonoBehaviour
{

    public int generationNum;

    public float agility;

    //public float maxSpeed;
    //public float cruiseSpeed;


    public float metabolism;

    public float eggLayingAge;

    public float visualDistance;

    public float visualAngle;

    public float maxHealth;

    public float deathAge;

    public float physicalRange;



    public string GeneticsToString() 
    {
        string outputStr = "\ngenerationNum: " + generationNum + "\n\n";
        outputStr += "agility: " + agility + "\n\n";
        outputStr += "deathAge: " + deathAge + "\n\n";
        outputStr += "physicalRange: " + physicalRange + "\n\n";

      

        return outputStr;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
