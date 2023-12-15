using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIRS : MonoBehaviour
{
    public GameObject IRS;

    // Start is called before the first frame update
    void Start()
    {
        if (DataWriter.ShouldSpawnIRS())
        {
            IRS.SetActive(true);
        }
    }
}
