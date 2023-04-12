using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveToCSV : MonoBehaviour
{
    //links:
    //https://www.makeuseof.com/csv-file-c-sharp-save-data/
    //https://docs.unity3d.com/ScriptReference/Hash128.html


    [SerializeField] GameObject statistics;

    private int worldNumber = 0;


    // Start is called before the first frame update
    void Start()
    {
        worldNumber = UnityEngine.Random.Range(-10000000, 10000000);

     
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SaveToCSVFile() 
    {
        //(statistics.gameObject.GetComponent("Statistics") as Statistics).


    }

    IEnumerator SaveToCSVFileAuto()
    {
        //(statistics.gameObject.GetComponent("Statistics") as Statistics).

        yield return new WaitForSeconds(600);//600 sec = 10 min
        SaveToCSVFile();
    }

}
