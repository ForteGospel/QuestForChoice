using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovment : MonoBehaviour
{

    public float movespeed = 5f;

    public bool Grounded = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Jump();
        Vector3 movment = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movment * Time.deltaTime * movespeed;
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump")&& Grounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        }
        
    }




}
