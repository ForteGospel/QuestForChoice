using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIController : MonoBehaviour
{
    [SerializeField] float movementSpeed = 10;
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileDelay = 2f;
    private GameObject player;
    private float timePassed;
    private EnemyStates enemyState = EnemyStates.patroling;
    private Vector3 startingPoint;
    private Vector3 endPoint;
    private Vector3 destinationPoint;
    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        startingPoint = transform.position;
        endPoint = gameObject.transform.GetChild(0).position;
        timePassed = projectileDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyState == EnemyStates.patroling)
        {
            moveTowardsDestination();
            flipSprite();
        }
        else
        {
            timePassed += Time.deltaTime;
            if (timePassed >= projectileDelay)
            {
                timePassed = 0f;
                fireTowardsPlayer();
            }
        }
    }

    private void moveTowardsDestination()
    {
        if (Vector2.Distance(transform.position, startingPoint) < 0.5f)
        {
            destinationPoint = endPoint;
        }
        if (Vector2.Distance(transform.position, endPoint) < 0.5f)
        {
            destinationPoint = startingPoint;
        }

        direction = new Vector2(transform.position.x <= destinationPoint.x ? 1f : -1f, 0f);

        gameObject.GetComponent<Rigidbody2D>().velocity = direction * movementSpeed * Time.deltaTime;
    }

    private void flipSprite()
    {
        if (direction.x == 1f)
            transform.localScale = new Vector3(1f, 1f, 1f);
        else
            transform.localScale = new Vector3(-1f, 1f, 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            enemyState = EnemyStates.alerted;
            player = collision.gameObject;
        }     
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            enemyState = EnemyStates.patroling;
            timePassed = projectileDelay;
        }
    }

    private void fireTowardsPlayer()
    {
        GameObject newProjectile = Instantiate(projectile, transform.position, rotationToPlayer());
        newProjectile.GetComponent<Rigidbody2D>().AddForce(newProjectile.transform.right * 100);
    }

    private Quaternion rotationToPlayer()
    {
        Vector3 playerDirection = player.transform.position - transform.position;
        float angle = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg;
        return Quaternion.Euler(0f, 0f, angle);
    }
}
