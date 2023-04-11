using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsText : MonoBehaviour
{
    public GameObject stats;

    public Text text;

    public TMP_Text textMeshTxt;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (stats != null)
        {

            textMeshTxt.text = (stats.gameObject.GetComponent("Statistics") as Statistics).StatsToString();
            


        }

        //text.text = "lol";


    }
}
