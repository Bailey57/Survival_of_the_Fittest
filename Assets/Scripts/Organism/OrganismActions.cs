using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganismActions : MonoBehaviour
{
    public GameObject inGameOrganism;

    public BoxCollider2D visionArea;

    public Organism organism;

    public Brain brain;

    public Genetics genetics;

    public Rigidbody2D rb;


    public GameObject travelTarget;


    public List<GameObject> gameobjectsInSight = new List<GameObject>();

    public GameObject familyTree;


    // Start is called before the first frame update
    void Start()
    {

        //rb.velocity = new Vector2(genetics.agility, rb.velocity.y);
        StartCoroutine(Eat2());
        //StartCoroutine(TurnTwardsTarget());
        
       


    }

    // Update is called once per frame
    void Update()
    {

        DeathCheck();

        
    }


    private void LateUpdate()
    {
        //not using brain
        GetPlantTarget();

        //MoveToTravelTarget();

        //visionArea.
        // Swim();
        //Turn();
        //Eat();

        //LayEgg();
        //Wonder();

        //Spin();


        //using brain
        Turn();
        Swim();
        LayEgg();


        //make genetic 
        if (organism.age > 500) 
        {
            Grow();


        }
            
            
            

    }

    public string OrganismInfoToString() 
    {
        //organism
        //genetics


        return "";
    }

    public void RunActions() 
    {


        //inGameOrganism


        //brain.turnRate;

        //speed;

        //for bool: [- input = false], [+ input = true]

        //layingEgg;

        //attacking;




        //GetDistance();



    }

    public void Turn() 
    {
        
        if (!Double.IsNaN(brain.turnRate)) 
        {
            //brain.turnRate
            float rotateSpeed = -1 * (float)brain.turnRate;
            //rb.AddTorque(rotateSpeed * Time.fixedDeltaTime);
            //Debug.Log("Torque Added" + (float)brain.turnRate);

            inGameOrganism.transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime * -1);


        }


    }
    
    public void Grow() 
    {
        //make more intricate
        inGameOrganism.transform.localScale = new Vector3(1, 1, 1);


    }


    public void TurnTest() 
    {



    
    }



    //if there is no food in sight, then wonder around 
    public void Wonder() 
    {
        if (gameobjectsInSight.Count <= 0 || travelTarget  == null) 
        {

            Spin();
            float moveSpeed = 5f;


            inGameOrganism.transform.Translate(0f, moveSpeed * Time.deltaTime, 0f);


        }

        


    }


    //if there is nothing in sight, spin around to find something
    public void Spin()
    {
        if (gameobjectsInSight.Count <= 0 || travelTarget  == null) 
        {
            float rotateSpeed = 30f;


            inGameOrganism.transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);


        }
        else
        {
            


        }

    }


    public void DeathCheck() 
    {
        if (organism.health <= 0 || organism.age >= genetics.deathAge || organism.energy <= 0)
        {
            inGameOrganism.SetActive(false);
            Destroy(inGameOrganism);

        }
    }

    public void GetPlantTarget()
    {
        if (this == null) 
        {
            return;
        }


        if (this.travelTarget == null && gameobjectsInSight.Count > 0)
        {
            for (int i = 0; i < gameobjectsInSight.Count; i++) 
            {
                if (gameobjectsInSight[i] == null) 
                {
                    gameobjectsInSight.Remove(gameobjectsInSight[i]);


                }
                if (gameobjectsInSight[i] != null && (gameobjectsInSight[i].gameObject.GetComponent("Plant") as Plant))
                {
                    this.travelTarget = gameobjectsInSight[i];
                    return;

                }
                else if (gameobjectsInSight[i] == null) 
                {
                    gameobjectsInSight.Remove(gameobjectsInSight[i]);
                }

            }
            

        }
        else if (gameobjectsInSight.Count <= 0)
        {
            this.travelTarget = null;
        }


    }


    public void UpdateSight()
    {
        if (this == null)
        {
            return;
        }
        if (this.travelTarget == null && gameobjectsInSight.Count > 0)
        {
            for (int i = 0; i < gameobjectsInSight.Count; i++)
            {
                if (gameobjectsInSight[i] == null)
                {
                    gameobjectsInSight.Remove(gameobjectsInSight[i]);


                }
                if (gameobjectsInSight[i] != null && (gameobjectsInSight[i].gameObject.GetComponent("Plant") as Plant))
                {
                    this.travelTarget = gameobjectsInSight[i];
                    return;

                }
                else if (gameobjectsInSight[i] == null)
                {
                    gameobjectsInSight.Remove(gameobjectsInSight[i]);
                }

            }


        }
        else if (gameobjectsInSight.Count <= 0)
        {
            this.travelTarget = null;
        }


    }

    public void BiteTarget() 
    {
    
    
    }


    public bool TargetInRange()
    {
        if (this.travelTarget == null)
        {
            return false;
        }
        if (GetDistance() < this.genetics.physicalRange)
        {
            return true;
        }
        else
        {
            return false;
        }

    }


    public void Eat() 
    {
        if (this.travelTarget == null)
        {
            //Debug.Log("TT = Null");
            return;
        }

        if ((travelTarget.gameObject.GetComponent("Plant") as Plant) != null && TargetInRange()) 
        {
            //Debug.Log("Eating");
            float nutrianceTransferRate = .001f;
            (travelTarget.gameObject.GetComponent("Plant") as Plant).condition -= nutrianceTransferRate;
            (travelTarget.gameObject.GetComponent("Plant") as Plant).nutreance -= nutrianceTransferRate;
            organism.energy += nutrianceTransferRate;

        }


    }


    IEnumerator Eat2() 
    {
        //Debug.Log("Eat2 running");

        while (true)
        {
            yield return new WaitForSeconds(1);
            //Debug.Log("Eat2 waited");
            if (this.travelTarget != null)
            {
                if ((travelTarget.gameObject.GetComponent("Plant") as Plant) != null && TargetInRange())
                {

                    //Debug.Log("Eat2 eating!");
                    //Debug.Log("Eating");
                    float nutrianceTransferRate = 1f;
                    (travelTarget.gameObject.GetComponent("Plant") as Plant).condition -= nutrianceTransferRate;
                    (travelTarget.gameObject.GetComponent("Plant") as Plant).nutreance -= nutrianceTransferRate;
                    organism.energy += nutrianceTransferRate;

                }
            }


        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //add object to in view list
        //Debug.Log("Trigger entered");
        if (gameobjectsInSight.Contains(other.gameObject))
        {
            return;
        }
        gameobjectsInSight.Add(other.gameObject);


        if ((other.gameObject.GetComponent("Organism") as Organism) != null)
        {
            brain.organismsInSightNum += 1;

        }
        else if ((other.gameObject.GetComponent("Plant") as Plant) != null) 
        {
            brain.plantsInSightNum += 1;

        }


    }


    void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("Trigger exited");
        //add object to in view list
        if (!gameobjectsInSight.Contains(other.gameObject))
        {
            return;
        }
        if ((other.gameObject.GetComponent("Organism") as Organism) != null)
        {
            brain.organismsInSightNum -= 1;

        }
        else if ((other.gameObject.GetComponent("Plant") as Plant) != null)
        {
            brain.plantsInSightNum -= 1;

        }
        gameobjectsInSight.Remove(other.gameObject);
        if (this.travelTarget == other.gameObject) 
        {
            this.travelTarget = null;


        }
    }


    void MoveToTravelTarget() 
    {
        if (this.travelTarget == null)
        {
            return;
        }

        //distanceToTarget and direction unused for now 
        float distanceToTarget = GetDistance();
        Vector2 direction = GetTravelTargetDirection();
        transform.position = Vector2.MoveTowards(this.transform.position, travelTarget.transform.position, genetics.agility * Time.deltaTime);


        //temp bandaid code for turning twords target
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);

    }
    public float GetDistance()
    {
        if (this.travelTarget == null)
        {
            return -1;
        }
        //Debug.Log("Distance to target: " + Vector2.Distance(transform.position, travelTarget.transform.position));
        return Vector2.Distance(transform.position, travelTarget.transform.position);
    }
    public Vector2 GetTravelTargetDirection()
    {
        return (travelTarget.transform.position - transform.position);
    }

    public IEnumerator TurnTwardsTarget() 
    {
        Vector2 direction = GetTravelTargetDirection();
        while (true) 
        {
            direction = GetTravelTargetDirection();
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            yield return new WaitForSeconds(1);

        }
        //change the angle of the organism
        //inGameOrganism.transform.rotation

    }


    public void Swim()
    {
        //inGameOrganism.transform.rotation
        if (!Double.IsNaN(brain.speed)) 
        {
            rb.velocity = transform.up * (float)brain.speed;
            //if (rb.velocity.magnitude  

            //rb.velocity = transform.right * (float)brain.speed;
            //rb.velocity = new Vector2((float)brain.speed, rb.velocity.y);
            //move forward

        }



    }

    public void LayEgg() 
    {

        //increase children count


        //change later to get genetics
        float eggLayingAge = 500;
        float energyNeededToLayEgg = 150;

        float energyLossRatioAfterLayingEgg = 2;

        if (organism.age > eggLayingAge && organism.energy > energyNeededToLayEgg)
        {
            //GameObject newOrganism = inGameOrganism;
            //add atributes
            //newOrganism


            //newOrganism.SetActive(true);

            //make new organism and give genes
            float geneChangeChance = 25;
            float maxGeneChangeAmmount = .2f;

            float brainChangeChance = 25;
            //float maxBrainChangeAmmount = 2;


            float changeAmmount = 0;
            GameObject newOrganism = Instantiate(inGameOrganism) as GameObject;
            //increase gen num
            //create linked list of organisms

            float randGeneNum = UnityEngine.Random.Range(0, 100);

            float randBrainNum = UnityEngine.Random.Range(0, 100);

            bool bothCHanged = false;



            if (brainChangeChance >= randBrainNum)
            {

                //(inGameOrganism.gameObject.GetComponent("Brain") as Brain).AddRandomNeuronNoNewLayer();
                //
                //(inGameOrganism.gameObject.GetComponent("Brain") as Brain).AddRandomNeuronNewLayer();
                //(inGameOrganism.gameObject.GetComponent("Brain") as Brain).EditNeuronStrengthRand();
                (newOrganism.gameObject.GetComponent("SpriteRenderer") as SpriteRenderer).color = Color.red;
                float rand = UnityEngine.Random.Range(0, 100);
                if (rand > 75)
                {
                    (inGameOrganism.gameObject.GetComponent("Brain") as Brain).EditNeuronStrengthRand();

                }
                else if (75 > rand && rand > 50)
                {
                    (inGameOrganism.gameObject.GetComponent("Brain") as Brain).AddSynapseConnectionRand();

                }
                else if (50 > rand && rand > 25)
                {
                    (inGameOrganism.gameObject.GetComponent("Brain") as Brain).AddRandomNeuronNewLayer();
                }
                else if (rand < 25)
                {
                    (inGameOrganism.gameObject.GetComponent("Brain") as Brain).AddRandomNeuronNoNewLayer();
                }
                else
                {

                }
                bothCHanged = true;

            }

            //see if by chance the genes change 
            if (geneChangeChance >= randGeneNum)
            {

                //change genes
                (newOrganism.gameObject.GetComponent("SpriteRenderer") as SpriteRenderer).color = Color.blue;
                changeAmmount = UnityEngine.Random.Range(-changeAmmount, maxGeneChangeAmmount);
                (newOrganism.GetComponent(typeof(Genetics)) as Genetics).agility += changeAmmount;
                changeAmmount = UnityEngine.Random.Range(-changeAmmount, maxGeneChangeAmmount);
                (newOrganism.GetComponent(typeof(Genetics)) as Genetics).deathAge += changeAmmount;
                changeAmmount = UnityEngine.Random.Range(-changeAmmount, maxGeneChangeAmmount);
                (newOrganism.GetComponent(typeof(Genetics)) as Genetics).eggLayingAge += changeAmmount;
                changeAmmount = UnityEngine.Random.Range(-changeAmmount, maxGeneChangeAmmount);
                (newOrganism.GetComponent(typeof(Genetics)) as Genetics).maxHealth += changeAmmount;
                changeAmmount = UnityEngine.Random.Range(-changeAmmount, maxGeneChangeAmmount);
                (newOrganism.GetComponent(typeof(Genetics)) as Genetics).visualAngle += changeAmmount;
                changeAmmount = UnityEngine.Random.Range(-changeAmmount, maxGeneChangeAmmount);
                (newOrganism.GetComponent(typeof(Genetics)) as Genetics).physicalRange += changeAmmount;
                changeAmmount = UnityEngine.Random.Range(-changeAmmount, maxGeneChangeAmmount);
                (newOrganism.GetComponent(typeof(Genetics)) as Genetics).visualDistance += changeAmmount;


            }
            else
            {
                bothCHanged = false;

            }



            if (bothCHanged)
            {
                (newOrganism.gameObject.GetComponent("SpriteRenderer") as SpriteRenderer).color = Color.green;

            }


            (newOrganism.GetComponent(typeof(Organism)) as Organism).energy = 100;
            (newOrganism.GetComponent(typeof(Organism)) as Organism).age = 0;

            (newOrganism.GetComponent(typeof(Genetics)) as Genetics).generationNum += 1;

            //make smol
            newOrganism.transform.localScale = new Vector3(.3f, .3f, 1);

            //Color color = new Color(0, 0, 0, 1);
            (newOrganism.gameObject.GetComponent("SpriteRenderer") as SpriteRenderer).color = new Color((newOrganism.gameObject.GetComponent("SpriteRenderer") as SpriteRenderer).color.r, (newOrganism.gameObject.GetComponent("SpriteRenderer") as SpriteRenderer).color.g, ((newOrganism.gameObject.GetComponent("SpriteRenderer") as SpriteRenderer).color.b + 50), (newOrganism.gameObject.GetComponent("SpriteRenderer") as SpriteRenderer).color.a);
            //(newOrganism.gameObject.GetComponent("SpriteRenderer") as SpriteRenderer).color = Color.red;

            Vector2 newV = new Vector2(inGameOrganism.transform.position.x, inGameOrganism.transform.position.y - 2);
            newOrganism.transform.position = newV;
            //loose energy after laying egg
            organism.energy /= energyLossRatioAfterLayingEgg;


            //add the organism to the family tree 
            //null issues
            if (familyTree != null && (familyTree.GetComponent("FamilyTree") as FamilyTree) != null) 
            {
                (familyTree.GetComponent("FamilyTree") as FamilyTree).GenerateAndAddChildToFamilyTree(inGameOrganism, newOrganism);

            }
            


        }
    
    
    }
}
