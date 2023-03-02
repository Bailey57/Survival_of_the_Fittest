using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{
    //list all input and output values

    public GameObject inGameOrganism;
    public OrganismActions organismActions;


    




    //inputs
    public double targetAngle;
    public double targetDistance;
    public double energy;
    public double health;




    //outputs

    public double turnRate;
    public double speed;
    //for bool: [- input = false], [+ input = true]
    public bool layingEgg;
    public bool attacking;

    //public void getTarget



    List<List<Neuron>> neuronLayers = new List<List<Neuron>>();

    //Add a finished neuron to a specified layer
    public void AddNeuronToLayer(int layer, Neuron neuron)
    {
        if (layer < this.neuronLayers[layer].Count)
        {
            this.neuronLayers[layer].Add(neuron);

        }
        //List<Neurons> newList = new List<Neurons>();
        //this.neuronLayers.Add(newList);



    }


    public void AddConnections(Neuron parent, Neuron child, Synapse synapse)
    {
        parent.childrenNeurons.Add(child);
        parent.childrenSynapses.Add(synapse);

    }

    public void RemoveConnections()
    {


    }


    //input get
    public double GetTargetAngle() 
    {
        if (organismActions.travelTarget == null) 
        {
            return 0;
        }


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
        GetTanH(1);
        GetSigmoid(1);
        
    }

    // Update is called once per frame
    void Update()
    {
        GetTargetAngle();

    }


    public void UpdateAllBrainNeurons()
    {

    
    
    }

    private void UpdateSingleNeuron() 
    {
    
    
    }

    private void CalculateMultipleSynapseInputs(List<Synapse> enteringSynapseConnections)
    {


    }

    private void CalculateNeuronAndSynapseOutput(float neuronWeight, float synapseWeight) 
    {

        //GetTanH

    }

    public double GetSigmoid(double inputNum)
    {
        //double tstIpt = 1.8372;
        //double tstIpt = .2;
        //double tst = 1.0 / (1.0 + Math.Exp(-tstIpt));
        double tst = 1.0 / (1.0 + Math.Exp(-inputNum));
        Debug.Log("tst sigmoid: " + tst);

        return tst;
    }


    //https://keisan.casio.com/exec/system/15411343653769
    public double GetTanH(double inputNum)
    {
        //double tstIpt = 1.8372;
        //double tstIpt = .2;
        //double tst = 1.0 / (1.0 + Math.Exp(-tstIpt));

        double tst = Math.Tanh(inputNum);
        //double tst = 1.0 / (1.0 + Math.Exp(-inputNum));
        //Debug.Log("tst sigmoid: " + tst + ", should be 0.86261721971");
        Debug.Log("tst tanH: " + tst);
        //return MathF.Tanh(inputNum);
        return tst;
    }

    public void CreateInputLayer()
    {
        //Neuron targetAngle = new Neuron(1, "targetAngle", .5);
    }
   
    public void MakeBrain1Tst()
    {
        Neuron targetAngle = new Neuron("input", "targetAngle", 0);
        Neuron targetDistance = new Neuron("input", "targetDistance", 0);
        Neuron energy = new Neuron("input", "energy", 0);
        Neuron health = new Neuron("input", "health", 0);


        Neuron turnRate = new Neuron("output", "turnRate", 0);
        Neuron speed = new Neuron("output", "speed", 0);


        Neuron hidden1 = new Neuron("output", "hidden1", .1);
        Neuron hidden2 = new Neuron("output", "hidden2", .2);
        Neuron hidden3 = new Neuron("output", "hidden3", .3);

        Synapse synapse1 = new Synapse(0.1);
        Synapse synapse2 = new Synapse(0.2);
        Synapse synapse3 = new Synapse(0.3);
        Synapse synapse4 = new Synapse(0.4);
        Synapse synapse5 = new Synapse(0.5);



        targetAngle.childrenSynapses.Add(synapse1);
        targetAngle.childrenNeurons.Add(hidden1);


        hidden1.childrenSynapses.Add(synapse2);
        hidden1.childrenNeurons.Add(hidden2);
        hidden1.childrenSynapses.Add(synapse3);
        hidden1.childrenNeurons.Add(hidden3);

        hidden2.childrenSynapses.Add(synapse5);
        hidden2.childrenNeurons.Add(turnRate);


        hidden3.childrenSynapses.Add(synapse4);
        hidden3.childrenNeurons.Add(turnRate);







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
