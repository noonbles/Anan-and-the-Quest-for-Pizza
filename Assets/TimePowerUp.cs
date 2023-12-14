using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePowerUp : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Player p = collision.gameObject.GetComponent<Player>();
        if (p)
        {
            p.currentTime += 5f;
            Destroy(gameObject);
        }
    }
}