using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class TimescaleSlider : MonoBehaviour
{
    [SerializeField] public Slider slider;
    [SerializeField] public TextMeshProUGUI text;


    // Start is called before the first frame update
    void Start()
    {

        slider.value = 1;

    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = slider.value;
        text.text = slider.value.ToString("0.00");
    }
}