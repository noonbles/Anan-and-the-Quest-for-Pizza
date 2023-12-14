using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaPowerUp : MonoBehaviour
{
    private Vector3 originalPosition;
    void Start()
    {
        originalPosition = transform.position;
    }

    void Update(){
        transform.Rotate(Vector3.up * 30f * Time.deltaTime, Space.World);
        float yOffset = Mathf.Sin(Time.time * 3f) * 0.2f;
        transform.position = new Vector3(transform.position.x, originalPosition.y + yOffset, transform.position.z);
    }

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