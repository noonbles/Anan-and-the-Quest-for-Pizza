using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaPowerUp : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("FUCK");
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