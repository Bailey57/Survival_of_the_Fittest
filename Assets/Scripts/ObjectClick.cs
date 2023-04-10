using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClick : MonoBehaviour
{
    [SerializeField] public GameObject selectedObject;
    [SerializeField] private Camera cam;

    [SerializeField] public LayerMask clickable;
    [SerializeField] public LayerMask ground;







    /**
     * Sets the current selected units
     */
    public void SelectUnits()
    {

        if (Input.GetMouseButtonDown(0))
        {

            //RaycastHit hit;
            //Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            //Debug.Log();
            //RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            //TODO: Make it by faction and not just Blue for multiplayer
            if (rayHit.transform != null && rayHit.transform.gameObject != null && (rayHit.transform.gameObject.GetComponent("Organism") as Organism))
            {

                Debug.Log("Hit " + rayHit.transform.gameObject.name);

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    //UnitSelections.Instance.ShiftClickSelect(rayHit.transform.gameObject);
                }
                else
                {
                    //UnitSelections.Instance.ClickSelect(rayHit.transform.gameObject);
                }
                //Debug.Log("Casting ray!");
            }
            else
            {
                Debug.Log("Hit Nothing");

                if (!Input.GetKey(KeyCode.LeftShift))
                {
                    //UnitSelections.Instance.DeSelectAll();
                }
                //Debug.Log("Not casting ray!");
            }


        }
    }



    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

    }


    // Update is called once per frame
    void Update()
    {
        SelectUnits();
  


    }

}
