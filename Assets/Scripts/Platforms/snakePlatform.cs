using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakePlatform : Platform
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
            chooseNextDestination();
            if (currChild == 3)
                duplicatePlatform();
        }
        transform.position = Vector3.MoveTowards(transform.position, nextDestination, platformSpeed / 100);
    }

    void chooseNextDestination()
    {
        currChild = (currChild + 1);

        if (currChild < childPoints.Length)
            nextDestination = childPoints[currChild].position;
        else
            Destroy(gameObject);
    }

    void duplicatePlatform()
    {
        GameObject newPlatform = Instantiate(gameObject, childPoints[0].position, transform.rotation, gameObject.transform.parent);
        if (newPlatform.transform.childCount != 0)
        {
            foreach (Transform child in newPlatform.transform)
                Destroy(child.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        for (int i = 1; i < childPoints.Length; i++)
            Gizmos.DrawLine(childPoints[i - 1].position, childPoints[i].position);
    }
}
