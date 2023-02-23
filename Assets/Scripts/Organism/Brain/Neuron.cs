using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Neuron : MonoBehaviour
{
    //have neuron types: t1 = input neuron, t2 = hidden layer, t3 = output neuron
    // Start is called before the first frame update

    public int type;
    public string neuronName;
    public double weight;
    public List<Synapse> synapseConnections = new List<Synapse>();


    public Neuron(int type, string neuronName, double weight) 
    {
        this.type = type;
        this.neuronName = neuronName;
        this.weight = weight;
    
    
    }


    void Start()
    {
        GetSigmoid(1);


    }

    // Update is called once per frame
    void Update()
    {
        
    }





    public double GetSigmoid(double inputNum) 
    {
        double tstIpt = 1.8372;
        //double tstIpt = .2;
        double tst = 1.0 / (1.0 + Math.Exp(-tstIpt));

        Debug.Log("tst sigmoid: " + tst + ", should be 0.86261721971");

        return 1.0;
    }

    

    public double GetTanH(double inputNum)
    {
        double tstIpt = 1.8372;
        //double tstIpt = .2;
        double tst = 1.0 / (1.0 + Math.Exp(-tstIpt));

        //Debug.Log("tst sigmoid: " + tst + ", should be 0.86261721971");

        //return MathF.Tanh(inputNum);
        return 1;
    }
}
