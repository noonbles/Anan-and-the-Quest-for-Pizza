using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ParkNPC : MonoBehaviour
{
    public NavMeshAgent agent;

    private Animator animationController;
    
    // Start is called before the first frame update
    void Start()
    {
        agent.SetDestination(new Vector3(-354.9f, 69.86f, 38.905f));
        animationController = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(agent.velocity);
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= 0.1f)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    animationController.SetBool("isStopped", true);
                }
            }
            else
            {
                animationController.SetBool("isStopped", false);
            }
        }
    }
}
