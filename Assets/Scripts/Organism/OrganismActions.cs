using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganismActions : MonoBehaviour
{
    public GameObject inGameOrganism;

    public Organism organism;

    public Brain brain;

    public Genetics genetics;

    public Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {

        rb.velocity = new Vector2(genetics.agility, rb.velocity.y);

            

    }

    // Update is called once per frame
    void Update()
    {
        Swim();
        Turn();
        LayEgg();

    }


    void Turn() 
    {
        //change the angle of the organism
        //inGameOrganism.transform.rotation

    }


    void Swim()
    {
        //inGameOrganism.transform.rotation
        rb.velocity = new Vector2(genetics.agility, rb.velocity.y);
        //move forward


    }

    void LayEgg() 
    {
        if (organism.age > 300 && organism.energy > 100) 
        {
            //GameObject newOrganism = inGameOrganism;
            //add atributes
            //newOrganism


            //newOrganism.SetActive(true);

            GameObject newOrganism = Instantiate(inGameOrganism) as GameObject;

            (newOrganism.GetComponent(typeof(Organism)) as Organism).energy = 0;


            //loose energy after laying egg
            organism.energy = organism.energy / 3;


        }
    
    
    }
}
