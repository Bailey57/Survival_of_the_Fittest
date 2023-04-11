using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClick : MonoBehaviour
{
    [SerializeField] public GameObject selectedObject;
    [SerializeField] private Camera cam;

    [SerializeField] public LayerMask clickable;
    [SerializeField] public LayerMask ground;


    public void SelectObject()
    {

        if (Input.GetMouseButtonDown(0))
        {


            RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            if (rayHit.transform != null && rayHit.transform.gameObject != null && (rayHit.transform.gameObject.GetComponent("Organism") as Organism) && !(rayHit.collider is BoxCollider2D))
            {

                Debug.Log("Hit " + rayHit.transform.gameObject.name);
                selectedObject = rayHit.transform.gameObject;
               
            
            }
            else
            {
                Debug.Log("Hit Nothing");
                selectedObject = null;



            }


        }
        else if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
        {
            selectedObject = null;

        }
    }




    public void FollowSelected() 
    {
        if (selectedObject != null)
        {
            cam.transform.position = new Vector3(selectedObject.transform.position.x, selectedObject.transform.position.y, cam.transform.position.z);


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
        SelectObject();
        FollowSelected();




    }

}
