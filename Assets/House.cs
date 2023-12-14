using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Player p = other.gameObject.GetComponent<Player>();
        if (p && p.isHoldingPizza)
        {
            string selfName = gameObject.name;
            if(selfName.Equals(p.heldPizzaName))
                p.correctDeliveries++;
            else
                p.wrongDeliveries++;
            p.isHoldingPizza = false;
        }
    }
}
