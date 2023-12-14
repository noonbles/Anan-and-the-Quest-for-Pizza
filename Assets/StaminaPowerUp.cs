using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaPowerUp : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        Player p = collision.gameObject.GetComponent<Player>();
        if (p)
        {
            if (p.stamina < 13.0f)
            {
                p.stamina = 13.0f;
                Destroy(gameObject);
            }
        }
    }
}