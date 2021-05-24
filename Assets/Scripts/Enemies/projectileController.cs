using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour
{
    [SerializeField]
    float timeToLive = 3f;
    float timePassed = 0f;

    [SerializeField]
    float speed;

    [SerializeField]
    int damage;

    public int Damage
    {
        get { return damage; }
    }

    [SerializeField]
    LayerMask whatToCollideWith;
    [SerializeField]
    GameObject destroyEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        if (timePassed > timeToLive)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((whatToCollideWith.value & (1 << collision.gameObject.layer)) > 0)
        {
            Instantiate(destroyEffect, transform.position, transform.rotation);
            collision.gameObject.GetComponent<HealthController>().getHit(damage);
            Destroy(gameObject);
        }
    }
}
