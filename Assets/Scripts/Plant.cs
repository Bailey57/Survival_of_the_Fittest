using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public GameObject inGamePlant;


    public float condition;

    public float nutreance;

    public float age;




    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AgeIncease());

    }

    // Update is called once per frame
    void Update()
    {

        DeathCheck();
        

    }

    IEnumerator AgeIncease()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            age += 1;


        }

    }

    public void DeathCheck()
    {
        if (condition <= 0 || nutreance <= 0 || age >= 1000)
        {
            inGamePlant.SetActive(false);
            Destroy(inGamePlant);

        }
    }
}
