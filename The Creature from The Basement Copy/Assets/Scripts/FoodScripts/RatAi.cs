using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RatAi : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGound, whatIsPlayer;

    //interact
    [SerializeField] string playerTag = "Player"; // interactible tagged object
    [SerializeField] float distanceToPickUp; // makes a float to be used to see if the player if close enough
    GameObject gameManager;


    //patroling
    public Vector3 walkpont;
    bool walkPointSet;
    public float walkPointRange;

    //states
    public float sightRange, runRange;
    public bool playerInSightRange, playerInRunRange;

    // Start is called before the first frame update


    void Start()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        gameManager = GameObject.FindGameObjectWithTag("gamemanager");
    }

    private void Update()
    {
        //check if player is in attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInRunRange = Physics.CheckSphere(transform.position, runRange, whatIsPlayer);

        if (playerInSightRange && !playerInRunRange) Romming();
        if (playerInSightRange && playerInRunRange) RunFromPlayer();
        if (!playerInSightRange && !playerInRunRange) Idle();

        if (Input.GetKeyDown(KeyCode.E) && RatCanInteract())// sees if object is able to be interacted with
        {

            gameManager.GetComponent<MainManager>().totalMeat += 5;
            Destroy(gameObject);//distroys self


        }
    }

    private void Romming()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkpont);

        Vector3 distanceToWalkPoint = (transform.position - walkpont);

        if (distanceToWalkPoint.magnitude <= 1f)
        {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        //caculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkpont = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkpont, -transform.up, 2f, whatIsGound))
            walkPointSet = true;
    }

    private void RunFromPlayer()
    {
        agent.SetDestination(walkpont - player.position*3);
    }

    private void Idle()
    {
        //make enemy not move
        agent.SetDestination(transform.position);

        transform.LookAt(player);
    }

    public bool RatCanInteract()
    {
        GameObject[] InteractibleObject = GameObject.FindGameObjectsWithTag(playerTag); //adds the player object to the player tag in script

        foreach (GameObject tempInteractibleObject in InteractibleObject)
        {
            float distance = Vector3.Distance(transform.position, tempInteractibleObject.transform.position); // gets the distance between the player object and food object

            if (distance < distanceToPickUp) // if statment to see if the player is close enough and presses space
            {

                return true;

            }
        }
        return false;
    }
}
