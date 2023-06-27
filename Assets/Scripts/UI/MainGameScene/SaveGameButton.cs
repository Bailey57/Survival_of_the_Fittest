using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameButton : MonoBehaviour
{


    public GameObject saveSystem;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SaveGame() 
    {
        (saveSystem.gameObject.GetComponent("SaveSystem") as SaveSystem).SaveGame();



    }
}
