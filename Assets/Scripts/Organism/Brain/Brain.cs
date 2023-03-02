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

    public string BrainToString()
    {
        string outputStr = "";
        for (int i = 0; i < neuronLayers.Count; i++)
        {
            for (int j = 0; j < neuronLayers[i].Count; j++)
            {
                outputStr += "[ " + neuronLayers[i][j].neuronName + " " + neuronLayers[i][j].weight + " ";
                for (int l = 0; l < neuronLayers[i][j].childrenNeurons.Count; l++)
                {
                    outputStr += "\n             -- " + neuronLayers[i][j].childrenSynapses[l].bias + " --> ";
                    outputStr += neuronLayers[i][j].childrenNeurons[l].neuronName + " " + neuronLayers[i][j].childrenNeurons[l].weight;

                    //outputStr += "\n";
                }

                outputStr += " ]\n";
            }
            outputStr += "\n";

        }
        return outputStr;

    }


    public string BrainToStringParents()
    {
        string outputStr = "Parents: \n";
        for (int i = 0; i < neuronLayers.Count; i++)
        {
            for (int j = 0; j < neuronLayers[i].Count; j++)
            {
                outputStr += "[ " + neuronLayers[i][j].neuronName + " " + neuronLayers[i][j].weight + " ";
                for (int l = 0; l < neuronLayers[i][j].parentNeurons.Count; l++)
                {
                    outputStr += "\n             -- " + neuronLayers[i][j].parentSynapses[l].bias + " --> ";
                    outputStr += neuronLayers[i][j].parentNeurons[l].neuronName + " " + neuronLayers[i][j].parentNeurons[l].weight;

                    //outputStr += "\n";
                }

                outputStr += " ]\n";
            }
            outputStr += "\n";

        }
        return outputStr;

    }


    public void UpdateBrain()
    {
        double average = 0.0;
        string outputStr = "";
        for (int i = 0; i < neuronLayers.Count; i++)
        {
            for (int j = 0; j < neuronLayers[i].Count; j++)
            {
                outputStr += neuronLayers[i][j].neuronName;

                if (i > 0)
                {
                    for (int l = 0; l < neuronLayers[i][j].parentNeurons.Count; l++)
                    {
                        //https://keisan.casio.com/exec/system/15411343087697
                        average += GetTanH(neuronLayers[i][j].parentNeurons[l].weight) * neuronLayers[i][j].parentSynapses[l].bias;


                        //neuronLayers[i][j].weight += GetTanH(neuronLayers[i][j].parentNeurons[l].weight * neuronLayers[i][j].parentSynapses[l].bias);
                        Console.WriteLine("\n num: " + average);

                    }
                    average = average / neuronLayers[i][j].parentNeurons.Count;

                    neuronLayers[i][j].weight = average / neuronLayers[i][j].parentNeurons.Count;
                    Console.WriteLine("\n average: " + average);
                    Console.WriteLine("\n count: " + neuronLayers[i][j].parentNeurons.Count);
                    Console.WriteLine("\n weight: " + neuronLayers[i][j].weight);
                    average = 0;



                }






            }


        }




    }







    //insert a hidden layer between two neurons
    public void AddInputNeuronToNeuronList(Neuron inputNeuron)
    {
        this.neuronLayers[0].Add(inputNeuron);
        //return [newParentNode, newChildNode]
    }

    //insert a hidden layer between two neurons
    public void AddOutputNeuronToNeuronList(Neuron outputNeuron)
    {
        this.neuronLayers[neuronLayers.Count].Add(outputNeuron);
        //return [newParentNode, newChildNode]
    }

    //insert a hidden layer between two neurons
    public void AddHiddenNeuronToNeuronList(Neuron hiddenNeuron)
    {
        int hiddenLayerIdx = 1;
        this.neuronLayers[hiddenLayerIdx].Add(hiddenNeuron);
        //return [newParentNode, newChildNode]
    }






    /**
    * connects 2 neurons by adding a synapse between them and putting them in each others neuron lists
    */
    public void ConnectNeurons(ref Neuron parent, ref Neuron child, double synapseBias)
    {
        Synapse synapse = new Synapse(synapseBias);

        parent.childrenSynapses.Add(synapse);
        parent.childrenNeurons.Add(child);
        child.parentNeurons.Add(parent);
        child.parentSynapses.Add(synapse);

    }


    /**
    * insert a synapse between two neurons
    */
    private void ConnectSynapse(Neuron parent, Neuron child, double synapseBias)
    {

        //return [newParentNode, newChildNode]
    }


    public void AddConnections(Neuron parent, Neuron child, Synapse synapse)
    {
        parent.childrenNeurons.Add(child);
        parent.childrenSynapses.Add(synapse);

    }







    public void RemoveConnections()
    {


    }


    //https://stackoverflow.com/questions/19396346/how-to-iterate-through-linked-list



    public void MakeBrain1Tst()
    {
        //Brian brain1 = new Brain();


        Neuron targetAngle = new Neuron("input", "targetAngle", 3);
        Neuron targetDistance = new Neuron("input", "targetDistance", 0);
        Neuron energy = new Neuron("input", "energy", 0);
        Neuron health = new Neuron("input", "health", 0);


        Neuron turnRate = new Neuron("output", "turnRate", 0);
        Neuron speed = new Neuron("output", "speed", 0);


        Neuron hidden1 = new Neuron("output", "hidden1", 1.1);
        Neuron hidden2 = new Neuron("output", "hidden2", .28);
        Neuron hidden3 = new Neuron("output", "hidden3", .39);

        Synapse synapse1 = new Synapse(1.1);
        Synapse synapse2 = new Synapse(1.2);
        Synapse synapse3 = new Synapse(1.3);
        Synapse synapse4 = new Synapse(1.4);
        Synapse synapse5 = new Synapse(1.5);



        //targetAngle.childrenSynapses.Add(synapse1);
        //targetAngle.childrenNeurons.Add(hidden1);
        //hidden1.parentNeurons.Add(targetAngle);
        //hidden1.parentSynapses.Add(synapse1);
        ConnectNeurons(ref targetAngle, ref hidden1, synapse1.bias);


        //hidden1.childrenSynapses.Add(synapse2);
        //hidden1.childrenNeurons.Add(hidden2);
        //hidden2.parentNeurons.Add(hidden1);
        //hidden2.parentSynapses.Add(synapse2);
        ConnectNeurons(ref hidden1, ref hidden2, synapse2.bias);


        //hidden1.childrenSynapses.Add(synapse3);
        //hidden1.childrenNeurons.Add(hidden3);
        //hidden3.parentNeurons.Add(hidden1);
        //hidden3.parentSynapses.Add(synapse3);
        ConnectNeurons(ref hidden1, ref hidden3, synapse3.bias);


        //hidden2.childrenSynapses.Add(synapse5);
        //hidden2.childrenNeurons.Add(turnRate);
        //turnRate.parentNeurons.Add(hidden2);
        //turnRate.parentSynapses.Add(synapse5);
        ConnectNeurons(ref hidden2, ref turnRate, synapse5.bias);


        //hidden3.childrenSynapses.Add(synapse4);
        //hidden3.childrenNeurons.Add(turnRate);
        //turnRate.parentNeurons.Add(hidden3);
        //turnRate.parentSynapses.Add(synapse4);
        ConnectNeurons(ref hidden3, ref turnRate, synapse4.bias);

        //Input List
        List<Neuron> NList1 = new List<Neuron>();
        //Hidden List
        List<Neuron> NList2 = new List<Neuron>();
        //Output List
        List<Neuron> NList3 = new List<Neuron>();


        this.neuronLayers.Add(NList1);
        this.neuronLayers.Add(NList2);
        this.neuronLayers.Add(NList3);

        this.neuronLayers[0].Add(targetAngle);

        this.neuronLayers[1].Add(hidden1);
        this.neuronLayers[1].Add(hidden2);
        this.neuronLayers[1].Add(hidden3);


        this.neuronLayers[2].Add(turnRate);

        //this.AddHiddenNeuron(hidden1);
        //this.AddHiddenNeuron(hidden2);
        //this.AddHiddenNeuron(hidden3);

        //this.AddOutputNeuron(turnRate);





    }


    public void Start_()
    {
        //create initial neurons

        //link neurons to each other: use MakeBrain1Tst() as example
        //use the Connect functions

        //add neurons to their respective neuronLayers: use MakeBrain1Tst()  as example
        //use the add functions



    }

    public void Update_()
    {
        //update inputs from in game

        //UpdateBrain();



    }
}
