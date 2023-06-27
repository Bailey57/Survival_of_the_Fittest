using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class Settings : MonoBehaviour
{
    public float geneticChangeChance;

    public float neuralChangeChance;

    public bool fullScrene = false;

    // Start is called before the first frame update
    void Start()
    {
        Screen.fullScreen = fullScrene;

    }

    // Update is called once per frame
    void Update()
    {

        
    }


    public void ToggleFullScrene() 
    {
        fullScrene = !fullScrene;
        Screen.fullScreen = fullScrene;


    }
}
