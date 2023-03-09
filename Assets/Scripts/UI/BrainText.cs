using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrainText : MonoBehaviour
{
    public GameObject inGameOrganism;

    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (inGameOrganism != null) 
        {

            
            text.text = (inGameOrganism.gameObject.GetComponent("Brain") as Brain).BrainToString();


        }
        //text.text = "lol";


    }
}
