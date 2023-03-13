using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainInputs : MonoBehaviour
{
    public GameObject inGameOrganism;
    public OrganismActions organismActions;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Angle: " + GetTargetAngle2());
        
    }

    //public double targetAngle;
    //public double targetDistance;
    //public double energy;
    //public double health;

    //outputs
    //public double turnRate;
    //public double speed;
    //for bool: [- input = false], [+ input = true]
    //public bool layingEgg;
    //public bool attacking;


    //Get inputs methods
   
    public double GetTargetAngle()
    {
        double targetAngle = 0;
        if (organismActions.travelTarget == null)
        {
            return 0;
        }


        Vector2 organismVector2 = new Vector2(inGameOrganism.transform.position.x, inGameOrganism.transform.position.y);
        Vector2 targetVector2 = new Vector2(organismActions.travelTarget.transform.position.x, organismActions.travelTarget.transform.position.y);
        targetAngle = Vector2.Angle(organismVector2, targetVector2);
        //Debug.Log("organismVector2 x: " + inGameOrganism.transform.position.x + " organismVector2 y: " + inGameOrganism.transform.position.y
            //+ "\ntargetVector2 x: " + organismActions.travelTarget.transform.position.x + " targetVector2 x: " + organismActions.travelTarget.transform.position.y
            //+ "\nangle: " + targetAngle);
        //Vector2.Angle();



        return targetAngle;
    }

    public double GetTargetAngle2() 
    {
        if (organismActions.travelTarget != null) 
        {
        
        }



        return 0.0;
    }





    public Vector2 GetTravelTargetDirection()
    {
        return (organismActions.travelTarget.transform.position - transform.position);
    }
    public double GetTargetDistance() 
    {

        if (organismActions.travelTarget == null)
        {
            return -1;
        }
        //Debug.Log("Distance to target: " + Vector2.Distance(transform.position, travelTarget.transform.position));
        return Vector2.Distance(transform.position, organismActions.travelTarget.transform.position);

    }


 







    //getTargetDistance()
    //getEnergy()
    //getHealth()
}
