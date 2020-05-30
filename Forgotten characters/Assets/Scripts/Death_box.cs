using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_box : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.CompareTag("Player"))
        {
            col.transform.position = spawnPoint.position;
        }
    }

}
