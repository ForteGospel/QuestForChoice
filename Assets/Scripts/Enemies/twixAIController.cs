using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twixAIController : Enemy
{
    [SerializeField] GameObject child;
    [SerializeField] bool isKilledBool = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isKilledBool)
        {
            isKilled();
        }
        else
        {
            if (enemyState == EnemyStates.patroling)
            {
                movementSpeed = 150f;
                moveTowardsDestination();
                flipSprite();
            }
            else
            {
                movementSpeed = 250f;
                moveTowardsPlayer();
            }
            
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
