using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{
    //list all input and output values

    public GameObject inGameOrganism;
    public OrganismActions organismActions;

    public List<Neuron> inputNeurons = new List<Neuron>();


    public double targetAngle;

    public double targetDistance;





    //outputs

    public double turnRate;
    public double speed;
    public bool attacking;

    //public void getTarget




    // Update is called once per frame




    //input get
    public double GetTargetAngle() 
    {
        Vector2 organismVector2 = new Vector2(inGameOrganism.transform.position.x, inGameOrganism.transform.position.y);
        Vector2 targetVector2 = new Vector2(organismActions.travelTarget.transform.position.x, organismActions.travelTarget.transform.position.y);
        this.targetAngle = Vector2.Angle(organismVector2, targetVector2);
        Debug.Log("organismVector2 x: " + inGameOrganism.transform.position.x + " organismVector2 y: " + inGameOrganism.transform.position.y 
            + "\ntargetVector2 x: " + organismActions.travelTarget.transform.position.x + " targetVector2 x: " + organismActions.travelTarget.transform.position.y
            + "\nangle: " + this.targetAngle);
        //Vector2.Angle();


        
        return this.targetAngle;
    }



    //output get
    public double GetTurnRate() 
    {
        return 1;
    }

    public double GetCurrentSpeed() 
    {
        return 1;
    }



    public bool GetAttacking() 
    {
        return false;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetTargetAngle();

    }




    public void CreateInputLayer()
    {
        Neuron targetAngle = new Neuron(1, "targetAngle", .5);
    }
    public void CreateBrain1()
    {
        //make input neurons
        //CreateInputLayer()
        Neuron targetAngle = new Neuron(1, "targetAngle", 0);

        //create synapses 
        Synapse syn1 = new Synapse();

        //attach synapses to the input layer neurons
        targetAngle.synapseConnections.Add(syn1);
        
        
        //create output layer
        Neuron turnRate = new Neuron(3, "turnRate", .5);
    }


    public void UpdateBrain() 
    {
        //update the input neurons 

        //traverse all input neurons and update sub neurons

        //then data gets used in OrganismActions based on the value of the output neurons
    }


    /**
     * Adds a hidden layer in the brain at a random point between two nodes
     */
    public void AddHiddenLayerRandom()
    {


    }

    /*
     * Add a hidden layer into the brain at a specified point 
     */
    public void AddHiddenLayer() 
    {
    
    
    }

    /*
     * Add a synapse into the brain at a random point 
     */
    public void AddSynapseRandom()
    {


    }

    /*
     * Add a synapse into the brain at a specified point 
     */
    public void AddSynapse()
    {


    }
}
