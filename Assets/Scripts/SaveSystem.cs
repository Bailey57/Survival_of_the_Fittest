using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

public class SaveSystem : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }



    //(statistics.gameObject.GetComponent("Statistics") as Statistics).GetGameTimeSimpleToString()


    //auto save every once in a while 


    public static void SaveGame() 
    {
        BinaryFormatter bf = new BinaryFormatter();
        string path = ".sotf";

        FileStream stream = new FileStream(path, FileMode.Create);

        GameData gd = new GameData();
        
        //Formatter.Serialize(stream, gd);
        stream.Close();
    }

    public void LoadGame() 
    {
        
    
    
    }


}
