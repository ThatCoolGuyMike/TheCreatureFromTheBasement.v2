using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class RatAi : MonoBehaviour, IInteractable
{
    public NavMeshAgent agent;

    public Transform playerTransform;

    GameObject player;

    public LayerMask whatIsGound, whatIsPlayer;
    public GameObject Lights;

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
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        gameManager = GameObject.FindGameObjectWithTag("gamemanager");
    }

    public void Interact()
    {

        gameManager.GetComponent<MainManager>().totalMeat += 5;
        Destroy(gameObject);//distroys self
    }
    public void interactAble()
    {
        this.GetComponent<SkinnedMeshRenderer>().enabled = false;
        Lights.SetActive(true);

    }

    private void Update()
    {
        if (player.GetComponent<InteracterScript>().notInteracting)
        {
            this.GetComponent<SkinnedMeshRenderer>().enabled = true;
            Lights.SetActive(false);
        }
        //check if player is in attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInRunRange = Physics.CheckSphere(transform.position, runRange, whatIsPlayer);

        if (playerInSightRange && !playerInRunRange) Romming();
        if (playerInSightRange && playerInRunRange) RunFromPlayer();
        if (!playerInSightRange && !playerInRunRange) Idle();
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
        agent.SetDestination(walkpont - playerTransform.position*3);
    }

    private void Idle()
    {
        //make enemy not move
        agent.SetDestination(transform.position);

        transform.LookAt(playerTransform);
    }
}
