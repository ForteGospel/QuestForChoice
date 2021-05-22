using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tokenController : MonoBehaviour
{
    [SerializeField]
    intVariableObject score;

    [SerializeField]
    int tokenValue = 100;

    [SerializeField]
    GameObject destroyEffect;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getToken()
    {
        score.Value += tokenValue;
        Instantiate(destroyEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
