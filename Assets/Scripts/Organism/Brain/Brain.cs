using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Brain : MonoBehaviour
{
    //list all input and output values

    public GameObject inGameOrganism;
    public OrganismActions organismActions;
    public Organism organism;

    public BrainInputs brainInputs;


    

    //inputs
    public double targetAngle = 0;
    public double targetDistance = 0;
    public double energy = 100;
    public double health = 100;

    //outputs

    public double turnRate = 0;
    public double speed = 0;
    //for bool: [- output = false], [+ output = true]
    public double layingEgg = 0;
    public double attacking = 0;

    //public void getTarget



    public List<List<Neuron>> neuronLayers = new List<List<Neuron>>();




    // Start is called before the first frame update
    void Start()
    {
        GetTanH(1);
        GetSigmoid(1);

        //base brain that can function
        MakeBrain2Tst();

        //complete random starts
        //MakeBaseBrain1Random();

        //Debug.Log("BrainToStringParents:\n" + this.BrainToStringParents());
        

    }

    // Update is called once per frame
    void Update()
    {
        UpdateInputs();
       
        UpdateBrain();

        UpdateOutputs();

    }
    private void LateUpdate()
    {
        
    }





    public void UpdateInputs() 
    {
        this.targetAngle = brainInputs.GetTargetAngle2();
        this.targetDistance = brainInputs.GetTargetDistance();
        this.energy = organism.energy;
        this.health = organism.health;

        //targetAngle
        this.neuronLayers[0][0].weight = targetAngle;
        this.neuronLayers[0][1].weight = targetDistance;
        this.neuronLayers[0][2].weight = energy;
        this.neuronLayers[0][3].weight = health;
        //this.neuronLayers[0][4].weight = health;




    }



    public void UpdateOutputs() 
    {
        //turnRate = neuronLayers.Count - 1;
        turnRate = this.neuronLayers[neuronLayers.Count - 1][0].weight;

        speed = this.neuronLayers[neuronLayers.Count - 1][1].weight;
        layingEgg = this.neuronLayers[neuronLayers.Count - 1][2].weight;
        //for bool: [- input = false], [+ input = true]
        attacking = this.neuronLayers[neuronLayers.Count - 1][3].weight;
        //turnRate = this.neuronLayers[neuronLayers.Count - 1][4].weight;


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

 



    public void TestBrains() 
    {
        Brain brain1 = new Brain();
        brain1.MakeBrain1Tst();
        //Console.WriteLine(brain1.BrainToString());
        Debug.Log(brain1.BrainToString());
        //Console.WriteLine(brain1.BrainToStringParents());

        brain1.UpdateBrain();
        //Console.WriteLine("\n Updated: \n");
        //Console.WriteLine(brain1.BrainToString());
        Debug.Log("\n Updated: \n");
        Debug.Log(brain1.BrainToString());
        //Console.WriteLine(brain1.BrainToStringParents());

        //Console.WriteLine("\n Brain2 Test: \n");
        Debug.Log("\n Brain2 Test: \n");
        Brain brain2 = new Brain();
        brain2.MakeBrain2Tst();
        //Console.WriteLine(brain2.BrainToString());
        Debug.Log(brain2.BrainToString());
        brain2.UpdateBrain();
        //Console.WriteLine("\n Updated: \n");
        Debug.Log("\n Updated: \n");
        //Console.WriteLine(brain2.BrainToString());
        Debug.Log(brain2.BrainToString());
        //Console.WriteLine(brain2.BrainToStringParents());
        Debug.Log(brain2.BrainToStringParents());


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
                outputStr += "C: " + i + " R: " + j;

                //Mathf.Round();
                outputStr += "[ " + neuronLayers[i][j].neuronName + " " + Math.Round((Double)neuronLayers[i][j].weight, 3) + " ";
                //outputStr += "[ " + neuronLayers[i][j].neuronName + " " + MathF.Round(neuronLayers[i][j].weight, 3)) + " ";
                //outputStr += "[ " + neuronLayers[i][j].neuronName + " " + neuronLayers[i][j].weight + " ";
                //float num = MathF.Round(3.54634);


                for (int l = 0; l < neuronLayers[i][j].childrenNeurons.Count; l++)
                {
                    outputStr += "\n             -- " + Decimal.Round((Decimal)neuronLayers[i][j].childrenSynapses[l].bias, 3) + " --> ";


                    //outputStr += neuronLayers[i][j].childrenNeurons[l].neuronName + " " + neuronLayers[i][j].childrenNeurons[l].weight;
                    outputStr += neuronLayers[i][j].childrenNeurons[l].neuronName + " " + Decimal.Round((Decimal)neuronLayers[i][j].childrenNeurons[l].weight, 3);

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
                outputStr += "[ " + neuronLayers[i][j].neuronName + " " + Decimal.Round((Decimal)neuronLayers[i][j].weight, 3) + " ";
                for (int l = 0; l < neuronLayers[i][j].parentNeurons.Count; l++)
                {
                    outputStr += "\n             <-- " + neuronLayers[i][j].parentSynapses[l].bias + " -- ";
                    outputStr += neuronLayers[i][j].parentNeurons[l].neuronName + " " + Decimal.Round((Decimal)neuronLayers[i][j].parentNeurons[l].weight, 3);

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
                        //choose what type of function 
                        //average += GetTanH(neuronLayers[i][j].parentNeurons[l].weight) * neuronLayers[i][j].parentSynapses[l].bias;
                        average += GetSquareRootSigned(neuronLayers[i][j].parentNeurons[l].weight) * neuronLayers[i][j].parentSynapses[l].bias;
                        //double tst = GetSquareRootSigned(neuronLayers[i][j].parentNeurons[l].weight) * neuronLayers[i][j].parentSynapses[l].bias;



                        //neuronLayers[i][j].weight += GetTanH(neuronLayers[i][j].parentNeurons[l].weight * neuronLayers[i][j].parentSynapses[l].bias);
                        //Console.WriteLine("\n num: " + average);

                    }
                    average = average / neuronLayers[i][j].parentNeurons.Count;

                    neuronLayers[i][j].weight = average / neuronLayers[i][j].parentNeurons.Count;
                    //Console.WriteLine("\n name: " + neuronLayers[i][j].neuronName);
                    //Console.WriteLine("\n average: " + average);
                    //Console.WriteLine("\n count: " + neuronLayers[i][j].parentNeurons.Count);
                    //Console.WriteLine("\n weight: " + neuronLayers[i][j].weight);
                    average = 0;



                }






            }


        }




    }



    //https://keisan.casio.com/exec/system/15411343653769
    public double GetTanH(double inputNum)
    {


        double tanH = Math.Tanh(inputNum);
        //Debug.Log("tst tanH: " + tst);
        //Console.WriteLine("");
        return tanH;
    }



    public double GetLinear(double inputNum)
    {
        double tanH = Math.Tanh(inputNum);
        //Debug.Log("tst tanH: " + tst);
        //Console.WriteLine("");
        return tanH;
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
    public void AddHiddenNeuronToNeuronList(Neuron hiddenNeuron, int hiddenLayerIdx)
    {
        this.neuronLayers[hiddenLayerIdx].Add(hiddenNeuron);
        //return [newParentNode, newChildNode]
    }


    /**
    *
    */
    public void AddHiddenNeuronRand()
    {


    }


    /**
    * adds HiddenNeuronBetweenNeurons and adds to list 
    */
    public void AddHiddenNeuronBetweenNeuronsAndList(ref Neuron hiddenNeuron, int parentLayerNum, int childLayerNum, ref Neuron parent, ref Neuron child, double synapseBias1, double synapseBias2)
    {
        //Debug.Log("Added in brain");
        int hiddenLayerIdx = parentLayerNum + 1;
        ConnectNeurons(ref parent, ref hiddenNeuron, synapseBias1);
        ConnectNeurons(ref hiddenNeuron, ref child, synapseBias2);
        this.neuronLayers[hiddenLayerIdx].Add(hiddenNeuron);
    }

    /**
    * adds HiddenNeuronBetweenNeurons and adds to list 
    */
    public void AddHiddenNeuronBetweenNeuronsAndList(ref Neuron hiddenNeuron, int parentLayerNum, int childLayerNum, int parentLayerPosition, int childLayerPosition, double synapseBias)
    {
        //int hiddenLayerIdx = parentLayerNum + 1;
        //this.neuronLayers[hiddenLayerIdx][parentLayerPosition]
        //this.neuronLayers[hiddenLayerIdx][childLayerPosition]

        //ConnectNeurons(ref parent, ref hiddenNeuron, synapseBias);
        //ConnectNeurons(ref hiddenNeuron, ref child, synapseBias);
        //this.neuronLayers[hiddenLayerIdx].Add(hiddenNeuron);
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


    public void InitializeNeuronLayerList()
    {


        //Input List
        List<Neuron> NList1 = new List<Neuron>();
        //Hidden List
        List<Neuron> NList2 = new List<Neuron>();
        //Output List
        List<Neuron> NList3 = new List<Neuron>();


        this.neuronLayers.Add(NList1);
        this.neuronLayers.Add(NList2);
        this.neuronLayers.Add(NList3);

        //this.neuronLayers[0].Add(targetAngle);

        //this.neuronLayers[2].Add(turnRate);
    }

    public void AddNewLayerToNeuronLayerList(int indexPosition)
    {
        List<Neuron> NList1 = new List<Neuron>();
        this.neuronLayers.Insert(indexPosition, NList1);

    }


    public void MakeBaseBrain1Random()
    {

        MakeBaseBrain1();

        //randomized parts
        AddRandomNeuronNoNewLayer();
        //AddRandomNeuronNewLayer();
        AddRandomNeuronNoNewLayer();
        AddRandomNeuronNoNewLayer();
    }

    public void MakeBaseBrain1()
    {
        Neuron targetAngle = new Neuron("input", "targetAngle", 3);
        Neuron targetDistance = new Neuron("input", "targetDistance", 0);
        Neuron energy = new Neuron("input", "energy", 100);
        Neuron health = new Neuron("input", "health", 100);

        //outputs doubles
        Neuron turnRate = new Neuron("output", "turnRate", 0);
        Neuron speed = new Neuron("output", "speed", 0);
        //outputs bool
        Neuron layingEgg = new Neuron("output", "layingEgg", 0);
        Neuron attacking = new Neuron("output", "attacking", 0);

        InitializeNeuronLayerList();

        this.neuronLayers[0].Add(targetAngle);
        this.neuronLayers[0].Add(targetDistance);
        this.neuronLayers[0].Add(energy);
        this.neuronLayers[0].Add(health);


        this.neuronLayers[2].Add(turnRate);
        this.neuronLayers[2].Add(speed);
        this.neuronLayers[2].Add(layingEgg);
        this.neuronLayers[2].Add(attacking);

    }

    public void MakeBrain2Tst()
    {
        //inputs
        Neuron targetAngle = new Neuron("input", "targetAngle", 30);
        Neuron targetDistance = new Neuron("input", "targetDistance", 5);
        Neuron energy = new Neuron("input", "energy", 110);
        Neuron health = new Neuron("input", "health", 100);

        //outputs doubles
        Neuron turnRate = new Neuron("output", "turnRate", 0);
        Neuron speed = new Neuron("output", "speed", 0);
        //outputs bool
        Neuron layingEgg = new Neuron("output", "layingEgg", 0);
        Neuron attacking = new Neuron("output", "attacking", 0);


        Neuron hidden1 = new Neuron("output", "hidden1", -1.1);
        Neuron hidden2 = new Neuron("output", "hidden2", .28);
        Neuron hidden3 = new Neuron("output", "hidden3", .39);



        InitializeNeuronLayerList();

        this.neuronLayers[0].Add(targetAngle);
        this.neuronLayers[0].Add(targetDistance);
        this.neuronLayers[0].Add(energy);
        this.neuronLayers[0].Add(health);


        this.neuronLayers[2].Add(turnRate);
        this.neuronLayers[2].Add(speed);
        this.neuronLayers[2].Add(layingEgg);
        this.neuronLayers[2].Add(attacking);


        
        int parentLayerNum = 0;
        int childLayerNum = this.neuronLayers.Count - 1;

        double syn1Num = 3;
        double syn2Num = 3.1;
        this.AddHiddenNeuronBetweenNeuronsAndList(ref hidden1, parentLayerNum, childLayerNum, ref targetAngle, ref turnRate, syn1Num, syn2Num);

        syn1Num = .2;
        syn2Num = .21;
        childLayerNum = this.neuronLayers.Count - 1;
        this.AddHiddenNeuronBetweenNeuronsAndList(ref hidden2, parentLayerNum, childLayerNum, ref targetDistance, ref speed, syn1Num, syn2Num);

        syn1Num = .3;
        syn2Num = .24;
        childLayerNum = this.neuronLayers.Count - 1;
        this.AddHiddenNeuronBetweenNeuronsAndList(ref hidden3, parentLayerNum, childLayerNum, ref energy, ref layingEgg, syn1Num, syn2Num);
        
        

        AddRandomNeuronNoNewLayer();
        AddRandomNeuronNewLayer();

    }

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

    /**
    * Adds a random neuron into a random spot in the brain 
    */
    public void AddRandomNeuronNoNewLayer()
    {


        double synapse1Value = this.GetRandomDouble(-5, 5);
        double synapse2Value = this.GetRandomDouble(-5, 5);

        double newNeuronValue = this.GetRandomDouble(-5, 5);

        //Debug.Log("syn1: " + synapse1Value + " syn2: " + synapse2Value);

        int newNeuronLayerNum = this.GetRandomInt(1, this.neuronLayers.Count - 1);

        int newNeuronParentLayer = newNeuronLayerNum - 1;
        int newNeuronChildLayer = newNeuronLayerNum + 1;
        //newNeuronParentLayer = this.GetRandomInt(0, this.neuronLayers.Count - 1);

        //newNeuronChildLayer = this.GetRandomInt(1, this.neuronLayers.Count - 1);



        int newNeuronParentPosition = this.GetRandomInt(0, this.neuronLayers[newNeuronParentLayer].Count);

        int newNeuronChildPosition = this.GetRandomInt(0, this.neuronLayers[newNeuronChildLayer].Count);



        Neuron newHidden = new Neuron("hidden", "newHidden", newNeuronValue);

        Synapse synapse1 = new Synapse(synapse1Value);




        //get parent neuron

        //get child neuron
        //Console.WriteLine("NeuronTOStr: " + NeuronToString(this.neuronLayers[newNeuronParentLayer][newNeuronParentPosition]));

        //ref Neuron parentNeuron = ref this.neuronLayers[newNeuronParentLayer][newNeuronParentPosition];
        Neuron parentNeuron = this.neuronLayers[newNeuronParentLayer][newNeuronParentPosition];
        Neuron childNeuron = this.neuronLayers[newNeuronChildLayer][newNeuronChildPosition];


        //AddHiddenNeuronBetweenNeuronsAndList(ref newHidden, newNeuronParentLayer, newNeuronChildLayer, ref this.neuronLayers[newNeuronParentLayer][newNeuronParentPosition], ref this.neuronLayers[newNeuronChildLayer][newNeuronChildPosition], synapse1Value);
        AddHiddenNeuronBetweenNeuronsAndList(ref newHidden, newNeuronParentLayer, newNeuronChildLayer, ref parentNeuron, ref childNeuron, synapse1Value, synapse2Value);


    }

    /**
    * Adds a random neuron into a random spot in the brain 
    */
    public void AddRandomNeuronNewLayer()
    {


        double synapse1Value = this.GetRandomDouble(-5, 5);
        double synapse2Value = this.GetRandomDouble(-5, 5);

        double newNeuronValue = this.GetRandomDouble(-5, 5);




        int newNeuronLayerNum = this.GetRandomInt(1, this.neuronLayers.Count);
        //Console.WriteLine("newNeuronLayerNum: " + newNeuronLayerNum);

        int newNeuronParentLayer = newNeuronLayerNum - 1;
        int newNeuronChildLayer = newNeuronLayerNum + 1;
        //newNeuronParentLayer = this.GetRandomInt(0, this.neuronLayers.Count - 1);

        //newNeuronChildLayer = this.GetRandomInt(1, this.neuronLayers.Count - 1);

        AddNewLayerToNeuronLayerList(newNeuronLayerNum);

        //Console.WriteLine("Added new layer: \n" + BrainToString());

        int newNeuronParentPosition = this.GetRandomInt(0, this.neuronLayers[newNeuronParentLayer].Count);

        int newNeuronChildPosition = this.GetRandomInt(0, this.neuronLayers[newNeuronChildLayer].Count);



        Neuron newHidden = new Neuron("hidden", "newHidden", newNeuronValue);

        Synapse synapse1 = new Synapse(synapse1Value);






        //get parent neuron

        //get child neuron
        //Console.WriteLine("NeuronTOStr: " + NeuronToString(this.neuronLayers[newNeuronParentLayer][newNeuronParentPosition]));

        //ref Neuron parentNeuron = ref this.neuronLayers[newNeuronParentLayer][newNeuronParentPosition];
        Neuron parentNeuron = this.neuronLayers[newNeuronParentLayer][newNeuronParentPosition];
        Neuron childNeuron = this.neuronLayers[newNeuronChildLayer][newNeuronChildPosition];
        //Console.WriteLine("newNeuronLayerNum: " + newNeuronLayerNum + " newNeuronParentLayer: " + newNeuronParentLayer + " newNeuronChildLayer: " + newNeuronChildLayer);

        //Console.WriteLine("parentNeuron: " + parentNeuron.neuronName + " childNeuron: " + childNeuron.neuronName);

        //AddHiddenNeuronBetweenNeuronsAndList(ref newHidden, newNeuronParentLayer, newNeuronChildLayer, ref this.neuronLayers[newNeuronParentLayer][newNeuronParentPosition], ref this.neuronLayers[newNeuronChildLayer][newNeuronChildPosition], synapse1Value);
        AddHiddenNeuronBetweenNeuronsAndList(ref newHidden, newNeuronParentLayer, newNeuronChildLayer, ref parentNeuron, ref childNeuron, synapse1Value, synapse2Value);


    }


    public string NeuronToString(Neuron neuron)
    {
        string outputStr = "";


        outputStr += "[ " + neuron.neuronName + " " + neuron.weight + " ";
        for (int l = 0; l < neuron.childrenNeurons.Count; l++)
        {
            outputStr += "\n             -- " + neuron.childrenSynapses[l].bias + " --> ";
            //outputStr += neuron.childrenNeurons[l].neuronName + " " + neuron.childrenNeurons[l].weight;
            outputStr += neuron.childrenNeurons[l].neuronName + " " + Decimal.Round((Decimal)neuron.childrenNeurons[l].weight, 3);

            //outputStr += "\n";
        }

        outputStr += " ]\n";

        return outputStr;


    }



    public void AddRandomSynapse()
    {
        //choose 2 neurons to add between randomly 

    }

    public double GetRandomDouble(double minimum, double maximum)
    {
        //System.Random random = new System.Random();
        
        //return random.NextDouble() * (maximum - minimum) + minimum;

        return (double)UnityEngine.Random.Range((float)minimum, (float)maximum);
    }

    public int GetRandomInt(int minimum, int maximum)
    {
        //System.Random random = new System.Random();
        //return random.Next(minimum, maximum);


        return (int)UnityEngine.Random.Range(minimum, maximum);
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
        //Debug.Log("tst sigmoid: " + tst);

        return tst;
    }

    public double GetSquareRootSigned(double inputNum) 
    {
        double signed = -1;
        if (inputNum > 0) 
        {
            signed = 1;

        }
        double outputNum = Math.Sqrt(inputNum * signed) * signed;
        //Debug.Log("signed out: " + outputNum);
        return outputNum;

    }

    public double GetSquared(double inputNum)
    {
     
        return inputNum * inputNum;

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




    //https://stackoverflow.com/questions/19396346/how-to-iterate-through-linked-list



}
