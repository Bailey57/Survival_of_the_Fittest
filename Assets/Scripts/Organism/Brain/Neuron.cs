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
    public List<Synapse> enteringSynapseConnections = new List<Synapse>();
    public List<Synapse> leavingSynapseConnections = new List<Synapse>();


    public Neuron(int type, string neuronName, double weight) 
    {
        this.type = type;
        this.neuronName = neuronName;
        this.weight = weight;
    
    
    }

    public void AddEnteringSynapseConnection(Synapse synapse) 
    {
        enteringSynapseConnections.Add(synapse);


    }


    void Start()
    {
        //GetSigmoid(1);


    }

    // Update is called once per frame
    void Update()
    {
        
    }





}
