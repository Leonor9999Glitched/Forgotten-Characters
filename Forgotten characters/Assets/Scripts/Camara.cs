﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform fellowCharacter;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = fellowCharacter.position;
        pos.z = transform.position.z;
        transform.position = pos;
    }
}
