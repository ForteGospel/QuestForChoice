using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(HealthController))]
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float movementSpeed = 150;
    protected GameObject player;
    public EnemyStates enemyState = EnemyStates.patroling;
    [SerializeField]protected Vector3[] patrolingPoints;
    protected Vector3 nextDestinationPoint;
    protected float direction;
    protected int currentPoint = 0;
    protected bool goingForwards = true;

    // Start is called before the first frame update
    void Start()
    {
        nextDestinationPoint = patrolingPoints[1];
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected virtual void moveTowardsDestination()
    {
        if (Vector2.Distance(transform.position, patrolingPoints[0]) < 0.5f)
        {
            nextDestinationPoint = patrolingPoints[1];
        }
        if (Vector2.Distance(transform.position, patrolingPoints[1]) < 0.5f)
        {
            nextDestinationPoint = patrolingPoints[0];
        }

        direction = transform.position.x <= nextDestinationPoint.x ? 1f : -1f;

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(direction * movementSpeed * Time.deltaTime, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    protected void flipSprite()
    {
        if (direction == 1f)
            transform.localScale = new Vector3(1f, 1f, 1f);
        else
            transform.localScale = new Vector3(-1f, 1f, 1f);
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            enemyState = EnemyStates.alerted;
            player = collision.gameObject;
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            enemyState = EnemyStates.patroling;
        }
    }

    protected void OnDrawGizmos()
    {
        if(patrolingPoints.Length != 0)
            Gizmos.DrawLine(patrolingPoints[0], patrolingPoints[1]);
    }
}
