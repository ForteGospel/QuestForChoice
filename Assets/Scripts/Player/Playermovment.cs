﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovment : MonoBehaviour
{

    public float movespeed = 5f;

    public bool Grounded = false;

    Vector3 m_velocity = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump") && Grounded == true)
            Jump();

        if (Input.GetAxis("Horizontal") != 0f)
            Move();
    }

    void Jump()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 10f), ForceMode2D.Impulse);
    }

    void Move()
    {
        flipSprite();
        Vector3 movment = new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * movespeed, gameObject.GetComponent<Rigidbody2D>().velocity.y, 0f);
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.SmoothDamp(gameObject.GetComponent<Rigidbody2D>().velocity, movment, ref m_velocity, 0.05f);
    }

    protected void flipSprite()
    {
        if (Input.GetAxis("Horizontal") > 0f)
            transform.localScale = new Vector3(1f, 1f, 1f);
        else
            transform.localScale = new Vector3(-1f, 1f, 1f);
    }


}
