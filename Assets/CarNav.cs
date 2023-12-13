using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarNav : MonoBehaviour
{
    public NavMeshAgent CarAgent;

    private Vector3[] ToDriveDest = {
        new Vector3(-389.85f, 69.66f, 14f),
    };
    // Start is called before the first frame update
    void Start()
    {
        CarAgent.SetDestination(new Vector3(-389.85f, 69.66f, 14f));
    }

    // Update is called once per frame
    void Update()
    {
        if(CarAgent.remainingDistance <= 0.05f)
        {
            CarAgent.SetDestination(new Vector3(-397.85f, 69.66f, 46f));
        }
    }
}
