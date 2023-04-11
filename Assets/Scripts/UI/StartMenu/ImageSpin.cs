using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageSpin : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] public GameObject gameObject;
    private bool rare = false;
    private int spinRate = 0;

    void Start()
    {
        spinRate = Random.Range(0, 1000);
        if (Random.Range(0, 1000) == 1) 
        {
            rare = true;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rare)
        {
            gameObject.transform.Rotate(0f, spinRate * Time.deltaTime, 0f, Space.Self);
        }
        else 
        {
            gameObject.transform.Rotate(0f, 0f, spinRate * Time.deltaTime, Space.Self);
            //use acceleration

        }



    }
}
