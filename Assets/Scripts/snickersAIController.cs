using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snickersAIController : Enemy
{
    [SerializeField] GameObject[] GFX;
    [SerializeField] float timePassed1;
    float timePassed2 = 3f;
    int currSprite = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameObject.GetComponent<bountyAIController>().enabled = true;
        gameObject.GetComponents<BoxCollider2D>()[0].enabled = true;
        instantiateGFX();
    }

    // Update is called once per frame
    void Update()
    {
        timePassed2 += Time.deltaTime;

        if (timePassed2 >= timePassed1)
        {
            currSprite = (currSprite + 1) % GFX.Length;
            timePassed2 = 0f;
            disableAll();
            switch (currSprite)
            {
                case 0:
                    gameObject.GetComponent<bountyAIController>().enabled = true;
                    gameObject.GetComponents<BoxCollider2D>()[0].enabled = true;
                    break;
                case 1:
                    gameObject.GetComponents<BoxCollider2D>()[1].enabled = true;
                    gameObject.GetComponent<twixAIController>().enabled = true;
                    break;
                case 2:
                    gameObject.GetComponent<CircleCollider2D>().enabled = true;
                    gameObject.GetComponent<ferreroAIController>().enabled = true;
                    break;
            }
            instantiateGFX();
        }
    }

    void disableAll()
    {
        gameObject.GetComponent<bountyAIController>().enabled = false;
        gameObject.GetComponent<twixAIController>().enabled = false;
        gameObject.GetComponent<ferreroAIController>().enabled = false;

        gameObject.GetComponents<BoxCollider2D>()[0].enabled = false;
        gameObject.GetComponents<BoxCollider2D>()[1].enabled = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;

        Destroy(gameObject.transform.GetChild(0).gameObject);
    }

    void instantiateGFX()
    {
        Instantiate(GFX[currSprite], transform.position, GFX[currSprite].transform.rotation, transform);
    }
}
