using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatisticsSave 
{
    public int numOfOrganisms;

    public int numOfPlants;


    public int maxnumOfOrganisms;

    public int maxNumOfPlants;


    public int longestLastingGenNum;

    public int numberOfChildren;

    public int simulationTime;//in seconds


    public List<(int numOfOrganisms, int numOfPlants, int maxnumOfOrganisms, int maxNumOfPlants, int longestLastingGenNum, int numberOfChildren, int simulationTime)> dataOverTime = new List<(int numOfOrganisms, int numOfPlants, int maxnumOfOrganisms, int maxNumOfPlants, int longestLastingGenNum, int numberOfChildren, int simulationTime)>();


    public int numberOfOverallOrganisms;

    //public Hashtable familyTreeNodes;

    public StatisticsSave MakeStatisticsSave(GameObject statistics)
    {
        StatisticsSave statisticsSave = new StatisticsSave();



        statisticsSave.numOfOrganisms = (statistics.gameObject.GetComponent("Statistics") as Statistics).numOfOrganisms;
        statisticsSave.numOfPlants = (statistics.gameObject.GetComponent("Statistics") as Statistics).numOfPlants;
        statisticsSave.maxnumOfOrganisms = (statistics.gameObject.GetComponent("Statistics") as Statistics).maxnumOfOrganisms;
        statisticsSave.maxNumOfPlants = (statistics.gameObject.GetComponent("Statistics") as Statistics).maxNumOfPlants;
        statisticsSave.longestLastingGenNum = (statistics.gameObject.GetComponent("Statistics") as Statistics).longestLastingGenNum;
        statisticsSave.numberOfChildren = (statistics.gameObject.GetComponent("Statistics") as Statistics).numberOfChildren;
        statisticsSave.simulationTime = (statistics.gameObject.GetComponent("Statistics") as Statistics).simulationTime;
        statisticsSave.dataOverTime = (statistics.gameObject.GetComponent("Statistics") as Statistics).dataOverTime;
        statisticsSave.numberOfOverallOrganisms = (statistics.gameObject.GetComponent("Statistics") as Statistics).numberOfOverallOrganisms;
        return statisticsSave;
    }

}
