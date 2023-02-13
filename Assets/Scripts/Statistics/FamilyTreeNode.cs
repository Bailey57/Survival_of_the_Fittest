using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilyTreeNode : MonoBehaviour
{
    public string organismName;
    public Genetics genetics;
    public Brain brain;
    public List<BodyPart> bodyParts;
    public List<FamilyTreeNode> children;

    public FamilyTreeNode(string organismName, Genetics genetics, Brain brain, 
        List<BodyPart> bodyParts, List<FamilyTreeNode> children) 
    {
        this.organismName = organismName;   
        this.genetics = genetics;
        this.brain = brain;
        this.bodyParts = bodyParts;
        this.children = children;
    
    
    }


}
