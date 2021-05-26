using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    int health = 100;

    [SerializeField]
    GameObject deathEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getHit(int Damage)
    {
        health -= Damage;

        if (health <= 0)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
            if (gameObject.GetComponent<twixAIController>() && !gameObject.GetComponent<ferreroAIController>())
                gameObject.GetComponent<twixAIController>().isKilled();
            Destroy(gameObject);
        }
    }
}
