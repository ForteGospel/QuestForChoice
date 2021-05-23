using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ferreroAIController : twixAIController
{

    [SerializeField]
    float distanceToActivate = 13f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < distanceToActivate)
            moveTowardsPlayer();
    }

    private new void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, distanceToActivate);
    }
}
