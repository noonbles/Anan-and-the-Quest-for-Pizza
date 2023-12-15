using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class IRS : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
    }

    void OnTriggerEnter(Collider e)
    {
        if (e.name == "Player")
            e.GetComponent<Player>().isAlive = false;
    }
}
