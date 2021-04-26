using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twixController : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] GameObject newGameObject;
    int currSprite = 0;
    float timePassed1;
    float timePassed2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timePassed1 += Time.deltaTime;
        timePassed2 += Time.deltaTime;

        if (timePassed1 >= 0.2f)
        {
            timePassed1 = 0f;
            currSprite = (currSprite + 1) % sprites.Length;
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[currSprite];
        }

        if(timePassed2 >= 5f)
        {
            Instantiate(newGameObject, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
