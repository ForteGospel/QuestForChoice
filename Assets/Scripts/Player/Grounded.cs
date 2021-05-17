using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    GameObject Player;
    [SerializeField]
    LayerMask layerMask;



    // Start is called before the first frame update
    void Start()
    {
        Player = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((layerMask.value & (1 << collision.gameObject.layer)) > 0)
        {
            Player.GetComponent<Playermovment>().Grounded = true;
            if (LayerMask.LayerToName(collision.gameObject.layer) == "Platform")
            {
                Player.transform.SetParent(collision.gameObject.transform);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((layerMask.value & (1 << collision.gameObject.layer)) > 0)
        {
            Player.GetComponent<Playermovment>().Grounded = false;
            if (LayerMask.LayerToName(collision.gameObject.layer) == "Platform")
            {
                Player.transform.parent = null;
            }
        }
    }
}
