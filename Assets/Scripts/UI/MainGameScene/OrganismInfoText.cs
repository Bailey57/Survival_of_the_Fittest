using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OrganismInfoText : MonoBehaviour
{


    public TMP_Text textMeshTxt;

    public ObjectClick objectClick;


    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (objectClick.selectedObject != null)
        {

            //textMeshTxt.text = (inGameOrganism.gameObject.GetComponent("Brain") as Brain).BrainToString();
            //text.text = (inGameOrganism.gameObject.GetComponent("Brain") as Brain).BrainToString();
            textMeshTxt.text = (objectClick.selectedObject.gameObject.GetComponent("Organism") as Organism).OrganismToString();
            textMeshTxt.text += (objectClick.selectedObject.gameObject.GetComponent("Genetics") as Genetics).GeneticsToString();



        }

    }
}
