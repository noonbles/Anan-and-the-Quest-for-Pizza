using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private int assignHouse;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("YAAAAAAAAA");
        Player p = other.gameObject.GetComponent<Player>();
        System.Random r = new System.Random();
        if (p)
        {
            GameObject[] GOList = GameObject.FindGameObjectsWithTag("House");
            assignHouse = r.Next(0, GOList.Length);
            p.isHoldingPizza = true;
            p.heldPizzaName = GOList[assignHouse].name;
            Debug.Log(p.heldPizzaName);
        }
    }
}

