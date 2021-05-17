using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopMovingPlatform : Platform
{
    [SerializeField]
    Transform[] childPoints;
    Vector2 nextDestination;
    int currChild = 1;

    [SerializeField]
    float platformSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        nextDestination = childPoints[1].position;
    }

    // Update is called once per frame
    void Update()
    {
        moveTowardsDestination();
    }

    void moveTowardsDestination()
    {
        if (Vector2.Distance(transform.position, nextDestination) < 0.5f)
        {
            currChild = (currChild + 1) % childPoints.Length;
            nextDestination = childPoints[currChild].position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextDestination, platformSpeed / 100);
    }

    private void OnDrawGizmos()
    {
        for (int i = 1; i < childPoints.Length; i++)
            Gizmos.DrawLine(childPoints[i - 1].position, childPoints[i].position);

        Gizmos.DrawLine(childPoints[0].position, childPoints[childPoints.Length - 1].position);
    }
}
