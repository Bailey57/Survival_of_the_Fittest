using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeResetButton : MonoBehaviour
{


    [SerializeField] public Slider slider;


    public void ResetTime()
    {
        slider.value = 1;
        Time.timeScale = slider.value;

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}