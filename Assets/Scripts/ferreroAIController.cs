﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ferreroAIController : twixAIController
{
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        moveTowardsPlayer();
    }

    private new void OnDrawGizmos()
    {
        
    }
}
