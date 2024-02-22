using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent pathfinder;
    private Transform target;
    public float detectionRadius = 5f; // Adjust this according to your needs

    void Start()
    {
        pathfinder = GetComponent<NavMeshAgent>(); 
        target = GameObject.Find("Player").transform; //Looks for the Player in the game scenario
    }

    void Update()
    {
        pathfinder.SetDestination(target.position); // Fixates the enemy destination based on the location of the player

        // Check if the player is within the detection radius
        if (Vector3.Distance(transform.position, target.position) <= detectionRadius)
        {
            // Trigger blinking in the player
            target.GetComponent<PlayerController>().TriggerBlink();
        }
        else
        {
            // Stop blinking if the player is out of range
            target.GetComponent<PlayerController>().StopBlink();
        }
    }
}

