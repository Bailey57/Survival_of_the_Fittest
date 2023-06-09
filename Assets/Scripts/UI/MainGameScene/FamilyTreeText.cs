using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FamilyTreeText : MonoBehaviour
{

    public Text text;

    public TMP_Text textMeshTxt;

    public GameObject familyTree;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textMeshTxt.text = (familyTree.gameObject.GetComponent("FamilyTree") as FamilyTree).FamilyTreeToString();
    }
}
