using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public float movingSpeed;
    [SerializeField] bool isKilled = false;
    [SerializeField] GameObject child;
    float timePassed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * movingSpeed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed >= 1f)
                isKilled = true;
        if (!isKilled)
        {

        }
        else
        {
            GameObject child1 = Instantiate(child, transform.position + (Vector3.right), transform.rotation);
            GameObject child2 = Instantiate(child, transform.position - (Vector3.right), transform.rotation);

            child2.GetComponent<enemyController>().movingSpeed = movingSpeed;
            child1.GetComponent<enemyController>().movingSpeed = -movingSpeed;

            Destroy(gameObject);
        }
    }
}
