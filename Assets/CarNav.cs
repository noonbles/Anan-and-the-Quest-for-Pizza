using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarNav : MonoBehaviour
{
    public NavMeshAgent CarAgent;
    public string Movement;

    private int cpos = 0;
    private int ccpos = 0;
    private Vector3[] ClockwiseOuterDriveDest = {
        new Vector3(-389.85f, 69.66f, 14f),
        new Vector3(-397.85f, 69.66f, 46f),
        new Vector3(-329.85f, 69.66f, 50f),
        new Vector3(-289.85f, 69.66f, 54f),
        new Vector3(-253.85f, 69.66f, 62f),
        new Vector3(-213.85f, 69.66f, 62f),
        new Vector3(-209.85f, 69.66f, 18f),
        new Vector3(-313.85f, 69.66f, 14f),
    };
    private Vector3[] CCOuterDriveDest = {
        new Vector3(-205.85f, 69.66f, 22f),
        new Vector3(-205.85f, 69.66f, 58f),
        new Vector3(-285.85f, 69.66f, 54f),
        new Vector3(-313.85f, 69.66f, 54f),
        new Vector3(-389.85f, 69.66f, 54f),
        new Vector3(-405.85f, 69.66f, 42f),
        new Vector3(-405.85f, 69.66f, 18f),
        new Vector3(-385.85f, 69.66f, 6f),
        new Vector3(-313.85f, 69.66f, 6f),
        new Vector3(-217.85f, 69.66f, 6f),
    };
    // Start is called before the first frame update
    void Start()
    {
        if (Movement.Equals("C"))
        {
            CarAgent.SetDestination(ClockwiseOuterDriveDest[cpos]);
        }
        else if (Movement.Equals("CC"))
        {
            CarAgent.SetDestination(CCOuterDriveDest[ccpos]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(CarAgent.remainingDistance <= 0.05f)
        {
            
            if (Movement.Equals("C"))
            {
                cpos = (cpos + 1) % ClockwiseOuterDriveDest.Length;
                CarAgent.SetDestination(ClockwiseOuterDriveDest[cpos]);
            }
            else if (Movement.Equals("CC"))
            {
                ccpos = (ccpos + 1) % (CCOuterDriveDest.Length);
                CarAgent.SetDestination(CCOuterDriveDest[ccpos]);
            }
        }
    }
}
