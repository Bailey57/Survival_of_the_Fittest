using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilyTreeNode
{
    public string organismName;
    public Genetics genetics;
    public Brain brain;




    public int birthTime;//at what time it was born
    public List<BodyPart> bodyParts;
    public List<FamilyTreeNode> children;
    public int numOfOrganisms; //the number of organisms who have same genes, brain, and physical stats

    public FamilyTreeNode(string organismName, Genetics genetics, Brain brain, 
        List<BodyPart> bodyParts, List<FamilyTreeNode> children) 
    {
        this.organismName = organismName;   
        this.genetics = genetics;
        this.brain = brain;
        this.bodyParts = bodyParts;
        this.children = children;
        numOfOrganisms = 1;


    }


    /*
     * New Family Tree Node with no children
     * 
     */
    public FamilyTreeNode(string organismName, Genetics genetics, Brain brain)
    {
        this.organismName = organismName;
        this.genetics = genetics;
        this.brain = brain;
        this.bodyParts = new List<BodyPart>();
        this.children = new List<FamilyTreeNode>();
        numOfOrganisms = 1;


    }






    /*
     * Prints a string version of the FamilyTreeNode without the children
     */
    public string FamilyTreeNodeToStringWithoutChildren() 
    {
        //later add bodyparts
        string outputString = "";

        outputString += "organismName: \n" + organismName + "\n";

        outputString += "genetics: \n" + genetics.GeneticsToString() + "\n";
        outputString += "brain: \n" + brain.BrainToString() + "\n";
        outputString += "birthTime: \n" + birthTime + "\n";

        return outputString;
    }


    /*
     * Get a string used to hash a node
     */
    public string FamilyTreeNodeHashString()
    {
        //later add bodyparts
        string outputString = "";
        outputString += "genetics: \n" + genetics.GeneticsToString() + "\n";
        //outputString += "brain: \n" + brain.BrainToString() + "\n";
        //outputString += "birthTime: \n" + birthTime + "\n";
        return outputString;
    }


}
