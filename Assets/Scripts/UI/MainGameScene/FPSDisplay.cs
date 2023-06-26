using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class FPSDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetFPSDisplay());
    }



    [SerializeField] public Slider slider;
    [SerializeField] public TextMeshProUGUI text;

    public float GetFPS() 
    {
        return 1f / Time.deltaTime * slider.value;
    
    }

    public int GetFPSSimple() 
    {

        return (int)GetFPS();
    }

    IEnumerator SetFPSDisplay()
    {
        while (true)
        {
            text.text = "FPS: " + GetFPSSimple().ToString();

            yield return new WaitForSeconds(1);
        }
    }

}
