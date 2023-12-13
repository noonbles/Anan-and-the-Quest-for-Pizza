using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePowerUp : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Player p = collision.GetComponent<Player>();
        if(p){
            if(p.stamina < 13.0f){
                p.stamina = 13.0f;
                Destroy(gameObject);
            }
        }
    }
}