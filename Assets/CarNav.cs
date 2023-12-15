using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarNav : MonoBehaviour
{
    public NavMeshAgent CarAgent;
    public string Movement;

    public int cpos = 0;
    public int ccpos = 0;
    private Vector3[] ClockwiseOuterDriveDest = {
        new Vector3(-321.85f, 69.66f, 46f),
        new Vector3(-300.85f, 69.66f, 51f),
        new Vector3(-253.85f, 69.66f, 62f),
        new Vector3(-209.85f, 69.66f, 52f),
        new Vector3(-209.85f, 69.66f, 26f),
        new Vector3(-239.02f, 69.66f, 14f),
        new Vector3(-288.90f, 69.66f, 14f),
        new Vector3(-321.85f, 69.66f, 22f),
    };
    private Vector3[] CCOuterDriveDest = {
        new Vector3(-334.85f, 69.66f, 6f),
        new Vector3(-325.85f, 69.66f, 34f),
        new Vector3(-349.85f, 69.66f, 54f),
        new Vector3(-389.85f, 69.66f, 54f),
        new Vector3(-405.85f, 69.66f, 28f),
        new Vector3(-369.85f, 69.66f, 6f),
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

    void OnTriggerEnter(Collider collider){
        Player p = collider.gameObject.GetComponent<Player>();
        if(p){
            p.isAlive = false;
        }
    }
}
