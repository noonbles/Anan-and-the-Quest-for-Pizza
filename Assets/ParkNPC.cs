using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ParkNPC : MonoBehaviour
{
    public NavMeshAgent agent;

    private Animator animationController;
    private Vector3[] parkDestinations = {
        new Vector3(-350.85f, 69.66f, 29f),
        new Vector3(-350.85f, 69.66f, 35f),
        new Vector3(-348.85f, 69.66f, 33f),
        new Vector3(-354.85f, 69.66f, 21f),
        new Vector3(-343.85f, 69.66f, 26f),
        new Vector3(-356.85f, 69.66f, 43f),
        new Vector3(-342.85f, 69.66f, 35f),
        new Vector3(-370.85f, 69.86f, 23f),
        new Vector3(-370.85f, 69.66f, 39f),
    };
    private Vector3 prevDest;
    
    // Start is called before the first frame update
    void Start()
    {
        prevDest = Vector3.zero;
        agent.SetDestination(new Vector3(-354.85f, 69.66f, 39f));
        animationController = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= 0.05f)
            {
                animationController.SetBool("isStopped", true);
                StartCoroutine(wait());
            }
            else
            {
                animationController.SetBool("isStopped", false);
            }
        }
    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(3);
        if (agent.hasPath) yield break;

        System.Random rand = new System.Random();
        int pos = rand.Next(parkDestinations.Length);
        // make sure he doesn't stay in place
        while (prevDest == parkDestinations[pos])
        {
            pos = rand.Next(parkDestinations.Length);
        }
        prevDest = agent.destination;
        agent.SetDestination(parkDestinations[pos]);
    }
}
