using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class heartManager : MonoBehaviour
{
    [SerializeField]
    Image[] heartsContainers;

    [SerializeField]
    intVariableObject healthObject;

    private Color semiTransparent = new Color(1, 1, 1, 0.25f);


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(healthObject.Value);
        for (int i = 0; i < heartsContainers.Length; i++)
        {
            if (i < healthObject.Value)
                heartsContainers[i].color = Color.white;
            else
                heartsContainers[i].color = semiTransparent;
        }
    }
}
