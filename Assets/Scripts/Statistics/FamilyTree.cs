using System;
using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
public class FamilyTree : MonoBehaviour
{
    // Start is called before the first frame update

    //made of a linked list of organisms and decendents

    //public List<FamilyTreeNode> FamilyTreeNode;
    public Hashtable familyTreeNodes;

    void Start()
    {
        familyTreeNodes = new Hashtable();  

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public FamilyTree() 
    {
    
    }


    public string FamilyTreeToString() 
    {
        string outputStr = "";
        outputStr += "FamilyTreeNodes: " + familyTreeNodes.Count + "\n";

        
        foreach (DictionaryEntry entry in familyTreeNodes)
        {
            //outputStr += "Entry: " +  ((FamilyTreeNode)entry.Value).brain.BrainToString() + "\n";

            //outputStr += "Entry: " + ((FamilyTreeNode)entry.Value).numOfOrganisms + "\n";
            outputStr += "Entry: " + ((FamilyTreeNode)entry.Value).organismName + "\n";
            
        }
        



        return outputStr;

    }



    public void GetNode(FamilyTreeNode node)
    {
        //FamilyTreeNode newNode = 


    }

    /*
     * Hashes a key generated from the node to string and adds it to the familyTreeNodes hash table
     */
    public void AddNode(FamilyTreeNode newNode) 
    {
        //generate key
        string nodeString = newNode.FamilyTreeNodeHashString();

        //if alreay hashed, add to the numOfOrganisms at the hash 

        //else add it to hash 

        string hash = ComputeSha256Hash(nodeString);
        //Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(nodeString)));
        Debug.Log(!familyTreeNodes.ContainsKey(hash));
        Debug.Log(FamilyTreeToString());
        if (!familyTreeNodes.ContainsKey(hash)) 
        {
            familyTreeNodes.Add(hash, newNode);
        }
        else
        {
            ((FamilyTreeNode)familyTreeNodes[hash]).numOfOrganisms += 1;
        }
        
        return;
    }



    public void GenerateAndAddNodeFromGameOrganism(GameObject organism) 
    {
        FamilyTreeNode newNode = new FamilyTreeNode((organism.GetComponent(typeof(Organism)) as Organism).organismName, (organism.GetComponent(typeof(Genetics)) as Genetics), (organism.GetComponent(typeof(Brain)) as Brain));

        Debug.Log("Generating famTreeNode for : \n\n" + (organism.GetComponent(typeof(Genetics)) as Genetics).ToString());

        AddNode(newNode);

        Debug.Log("Added:\n " + GetGameOrganismTreeNodeFromHash(organism).FamilyTreeNodeHashString() + "\n\nTo family tree.");
    }

    public FamilyTreeNode GetGameOrganismTreeNodeFromHash(GameObject organism) 
    {
        FamilyTreeNode newNode = new FamilyTreeNode((organism.GetComponent(typeof(Organism)) as Organism).organismName, (organism.GetComponent(typeof(Genetics)) as Genetics), (organism.GetComponent(typeof(Brain)) as Brain));
        string nodeString = newNode.FamilyTreeNodeHashString();
        string hash = ComputeSha256Hash(nodeString);

        if (familyTreeNodes.Contains(hash) == true)
        {
            return (FamilyTreeNode)familyTreeNodes[hash];

        }

            return null;
    }

    public void GenerateAndAddChildToFamilyTree(GameObject parent, GameObject child) 
    {


        



        //TODO: USE HASH INSTEAD OF LOOKING THROUGH ALL 
        bool inAlready = false;
        foreach (DictionaryEntry entry in familyTreeNodes)
        {
           


            if (((FamilyTreeNode) entry.Value).organismName == (parent.GetComponent(typeof(Organism)) as Organism).organismName)
            {
                inAlready = true;
            }
            //outputStr += "Entry: " + ((FamilyTreeNode)entry.Value).organismName + "\n";

        }
        if (!inAlready) 
        {
            GenerateAndAddNodeFromGameOrganism(parent);
        }
        //




        GenerateAndAddNodeFromGameOrganism(child);

        //null issues
        GetGameOrganismTreeNodeFromHash(parent).children.Add(GetGameOrganismTreeNodeFromHash(child));

        Debug.Log("Added C:\n " + GetGameOrganismTreeNodeFromHash(child).FamilyTreeNodeToStringWithoutChildren() + "\n\nTO:\n" + GetGameOrganismTreeNodeFromHash(parent).FamilyTreeNodeToStringWithoutChildren());
    }



    //public void AddChild()





    /*
     * https://www.c-sharpcorner.com/article/compute-sha256-hash-in-c-sharp/
     */
    static string ComputeSha256Hash(string rawData)
    {
        // Create a SHA256   
        using (SHA256 sha256Hash = SHA256.Create())
        {
            // ComputeHash - returns byte array  
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

            // Convert byte array to a string   
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }




    //public FamilyTreeNode GetNode(key) 
    //{

    //}



}
