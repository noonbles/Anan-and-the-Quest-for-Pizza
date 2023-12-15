using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericNPC : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public bool reverse;
    public int pathNum;
    public int startPos;

    // inner city block loop
    private Vector3[] pathOne = {
        new Vector3(-212.85f, 69.66f, 17.00f),
        new Vector3(-212.85f, 69.66f, 59.00f),
        new Vector3(-254.85f, 69.66f, 59.00f),
        new Vector3(-254.85f, 69.66f, 51.00f),
        new Vector3(-286.85f, 69.66f, 51.00f),
        new Vector3(-286.85f, 69.66f, 49.00f),
        new Vector3(-318.85f, 69.66f, 49.00f),
        new Vector3(-318.85f, 69.66f, 17.00f)
    };
    // apartment building loop
    private Vector3[] pathTwo = {
        new Vector3(-494.85f, 69.66f, 65.00f),
        new Vector3(-494.85f, 69.66f, 57.00f),
        new Vector3(-376.85f, 69.66f, 57.00f),
        new Vector3(-376.85f, 69.66f, 79.00f),
        new Vector3(-492.85f, 69.76f, 81.00f)
    };
    // hotel loop
    private Vector3[] pathThree = {
        new Vector3(-361.28f, 69.66f, 74.06f),
        new Vector3(-370.85f, 69.66f, 73.00f),
        new Vector3(-370.85f, 69.66f, 57.00f),
        new Vector3(-326.85f, 69.66f, 59.00f),
        new Vector3(-319.78f, 69.66f, 77.04f),
        new Vector3(-336.85f, 69.66f, 95.00f),
        new Vector3(-338.85f, 69.66f, 77.00f),
    };
    // house/fire department loop
    private Vector3[] pathFour = {
        new Vector3(-268.85f, 69.56f, 69.00f),
        new Vector3(-268.85f, 69.56f, 57.04f),
        new Vector3(-302.85f, 69.66f, 57.00f),
        new Vector3(-302.85f, 69.66f, 81.00f),
        new Vector3(-319.78f, 69.66f, 77.04f),
        new Vector3(-297.85f, 69.66f, 94.00f),
        new Vector3(-280.30f, 69.66f, 95.44f),
        new Vector3(-278.53f, 69.76f, 58.72f),
        new Vector3(-268.85f, 69.56f, 57.04f)
    };
    // hospital loop
    private Vector3[] pathFive = {
        new Vector3(-397.35f, 69.66f, -24.00f),
        new Vector3(-398.85f, 69.66f, 3.00f),
        new Vector3(-328.85f, 69.66f, 3.00f),
        new Vector3(-214.85f, 69.66f, 3.00f),
        new Vector3(-328.85f, 69.66f, 3.00f),
        new Vector3(-398.85f, 69.66f, 3.00f)
    };

    private int currDestination;
    private Vector3[] path;

    // Start is called before the first frame update
    void Start()
    {
        switch(pathNum)
        {
            case 1:
                path = pathOne;
                break;
            case 2:
                path = pathTwo;
                break;
            case 3:
                path = pathThree;
                break;
            case 4:
                path = pathFour;
                break;
            case 5:
                path = pathFive;
                break;
        }
        if (reverse)
            System.Array.Reverse(path);
        currDestination = startPos;
        agent.SetDestination(path[(++currDestination) % path.Length]);
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= 0.05f)
            {
                agent.SetDestination(path[(++currDestination) % path.Length]);
            }
        }
    }
}
