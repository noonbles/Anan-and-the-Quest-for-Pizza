using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Player p = other.gameObject.GetComponent<Player>();
        if (p)
        {
            string selfName = gameObject.name;
            if (selfName.Equals(p.heldPizzaName))
            {
                Debug.Log("Do thingy here");
            }
            else
            {
                Debug.Log("Do some other thingy here");
            }
        }
    }
}
