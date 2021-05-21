using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bountyAIController : Enemy
{
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileDelay = 2f;
    private float timePassed;
    // Start is called before the first frame update
    void Start()
    {
        timePassed = projectileDelay;
    }

    // Update is called once per frame
    void Update()
    {
        checkForViewPoint();
        if (enemyState == EnemyStates.patroling)
        {
            moveTowardsDestination();
            flipSprite();
            timePassed = projectileDelay;
        }
        else if (enemyState == EnemyStates.alerted)
        {
            timePassed += Time.deltaTime;
            if (timePassed >= projectileDelay)
            {
                timePassed = 0f;
                fireTowardsPlayer();
            }
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
