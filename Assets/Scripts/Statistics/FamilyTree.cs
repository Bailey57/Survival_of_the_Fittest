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

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public FamilyTree() 
    {
    
    }



    public void GetNode(FamilyTreeNode newNode)
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
        string hash = ComputeSha256Hash(nodeString);
        //Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(nodeString)));
        
        familyTreeNodes.Add(hash, newNode);
        return;
    }




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
