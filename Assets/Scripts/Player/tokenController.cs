using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tokenController : MonoBehaviour
{
    [SerializeField]
    intVariableObject invVariable;

    [SerializeField]
    int tokenValue = 100;

    [SerializeField]
    GameObject destroyEffect;

    public void getToken()
    {
        invVariable.addValue(tokenValue);
        Instantiate(destroyEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
