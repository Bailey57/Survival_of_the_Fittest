using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelection : MonoBehaviour
{
    public List<GameObject> unitList = new List<GameObject>();
    public List<GameObject> objectsSelected = new List<GameObject>();

    private static ObjectSelection _instance;

    public static ObjectSelection Instance { get { return _instance; } }


    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void ClickSelect(GameObject unitToAdd)
    {
        DeSelectAll();
        objectsSelected.Add(unitToAdd);
    }

    public void ShiftClickSelect(GameObject unitToAdd)
    {
        if (!objectsSelected.Contains(unitToAdd))
        {
            objectsSelected.Add(unitToAdd);

        }
        else
        {
            objectsSelected.Remove(unitToAdd);
        }
    }

    public void DragSelect(GameObject unitToAdd)
    {
        //TODO: Add a drag select to select all units in a drawn box
    }

    public void DeSelectAll()
    {
        objectsSelected.Clear();
    }


    public void DeSelect(GameObject unitToAdd)
    {
        objectsSelected.Remove(unitToAdd);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
