using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class heartManager : MonoBehaviour
{
    [SerializeField]
    Image[] heartsContainers;

    [SerializeField]
    playerStats playerStats;

    private Color semiTransparent = new Color(1, 1, 1, 0.25f);


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < heartsContainers.Length; i++)
        {
            if (i < playerStats.health)
                heartsContainers[i].color = Color.white;
            else
                heartsContainers[i].color = semiTransparent;
        }
    }
}
