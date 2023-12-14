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
        // StartCoroutine(HuntPlayer());
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
    }

    float first_positive_solution_of_quadratic_equation(float a, float b, float c)
    {
        float discriminant = b*b - 4.0f*a*c;
        if (discriminant < 0.0f)
            return -1.0f;
        // Indicate there is no solution
        float s = (float) Math.Sqrt(discriminant);
        float x1 = (-b-s) / (2.0f*a);
        if (x1 > 0.0f) return x1;
        float x2 = (-b+s) / (2.0f*a);
        if (x2 > 0.0f) return x2;
        // Indicate there is no positive solution
        return -1.0f;
    }

    Vector3 direct_solution(Vector3 target_position, Vector3 target_velocity, float projectile_speed)
    {
        // get claire's position relative to the apple's launch position
        float a = Vector3.Dot(target_velocity, target_velocity) - projectile_speed * projectile_speed;
        float b = 2.0f * Vector3.Dot(target_position, target_velocity);
        float c = Vector3.Dot(target_position,target_position);
        float t = first_positive_solution_of_quadratic_equation(a, b, c);
        if (t <= 0.0f) return Vector3.zero;
        // Indicate we failed to find a solution
        return target_position + t * target_velocity;
    }

    private IEnumerator HuntPlayer()
    {
        while (true)
        {
            Vector3 playerVelocity = player.GetComponent<Player>().moveDirection * player.GetComponent<Player>().speed;
            Vector3 target = direct_solution(player.transform.position, playerVelocity, agent.speed);
            agent.SetDestination(target);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
