using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public AudioClip source;
    private void OnTriggerEnter(Collider other)
    {
        Player p = other.gameObject.GetComponent<Player>();
        if (p && p.isHoldingPizza)
        {
            AudioSource audioSource = p.GetComponent<AudioSource>();
            audioSource.clip = source;
            audioSource.Play();
            string selfName = gameObject.name;
            if(selfName.Equals(p.heldPizzaName))
                p.correctDeliveries++;
            else
                p.wrongDeliveries++;
            p.isHoldingPizza = false;
        }
    }
}
