using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twixAIController : Enemy
{
    [SerializeField] GameObject child;
    float alertedMovementSpeed;
    float originalMovementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        originalMovementSpeed = movementSpeed;
        alertedMovementSpeed = movementSpeed + 100f;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyState == EnemyStates.patroling)
        {
            movementSpeed = originalMovementSpeed;
            moveTowardsDestination();
            flipSprite();
        }
        else
        {
            movementSpeed = alertedMovementSpeed;
            moveTowardsPlayer();
        }
    }

    public void isKilled()
    {
        GameObject child1 = Instantiate(child, transform.position + (Vector3.right), transform.rotation);
        GameObject child2 = Instantiate(child, transform.position - (Vector3.right), transform.rotation);

        child2.GetComponent<Enemy>().enemyState = EnemyStates.alerted;
        child1.GetComponent<Enemy>().enemyState = EnemyStates.alerted;

        Destroy(gameObject);
    }

    protected void moveTowardsPlayer()
    {
        direction = transform.position.x <= player.transform.position.x ? 1f : -1f;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (direction * movementSpeed * Time.deltaTime, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }
}
