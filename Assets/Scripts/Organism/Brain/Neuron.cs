using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Neuron
{
    //have neuron types: t1 = input neuron, t2 = hidden layer, t3 = output neuron
    // Start is called before the first frame update

    public string type;
    public string neuronName;
    public double weight;
    public List<Synapse> parentSynapses = new List<Synapse>();
    public List<Neuron> parentNeurons = new List<Neuron>();

    public List<Synapse> childrenSynapses = new List<Synapse>();
    public List<Neuron> childrenNeurons = new List<Neuron>();


    public Neuron(string type, string neuronName, double weight)
    {

        this.type = type;
        this.neuronName = neuronName;
        this.weight = weight;
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
