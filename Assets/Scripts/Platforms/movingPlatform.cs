using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : Platform
{
    private Vector2 startingPoint;
    private Vector2 destinationPoint;
    private Vector2 nextDestinationPoint;

    [SerializeField]
    float platformSpeed = 1;

    [SerializeField]
    [Range(-1, 1)]
    float xDirection = 1;

    [SerializeField]
    [Range(-1, 1)]
    float yDirection = 0;

    [SerializeField]
    float multiplaier = 2;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 direction = new Vector2(xDirection, yDirection);
        startingPoint = transform.position;
        destinationPoint = startingPoint + direction * multiplaier;
    }

    // Update is called once per frame
    void Update()
    {
        moveTowardsDestination();
    }

    protected virtual void moveTowardsDestination()
    {
        if (Vector2.Distance(transform.position, startingPoint) < 0.5f)
        {
            nextDestinationPoint = destinationPoint;
        }
        if (Vector2.Distance(transform.position, destinationPoint) < 0.5f)
        {
            nextDestinationPoint = startingPoint;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextDestinationPoint, platformSpeed / 100);
    }

    private void OnDrawGizmos()
    {
        Vector3 direction = new Vector3(xDirection, yDirection);
        Gizmos.DrawLine(transform.position, transform.position + direction * multiplaier);
    }
}
