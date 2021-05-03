using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniTwixAIController : twixAIController
{
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        movementSpeed = 350f;
        moveTowardsPlayer();
    }
}
