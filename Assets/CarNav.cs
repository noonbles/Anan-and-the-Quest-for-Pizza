using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarNav : MonoBehaviour
{
    public NavMeshAgent CarAgent;

    private int pos = 0;
    private Vector3[] ToDriveDest = {
        new Vector3(-389.85f, 69.66f, 14f),
        new Vector3(-397.85f, 69.66f, 46f),
        new Vector3(-329.85f, 69.66f, 50f),
        new Vector3(-289.85f, 69.66f, 54f),
        new Vector3(-253.85f, 69.66f, 62f),
        new Vector3(-213.85f, 69.66f, 62f),
        new Vector3(-209.85f, 69.66f, 18f),
        new Vector3(-313.85f, 69.66f, 14f),
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
            pos = (pos + 1) % 8;
            CarAgent.SetDestination(ToDriveDest[pos]);
        }
    }
}
