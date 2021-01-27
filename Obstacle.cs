﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int moveSpeed;

    Rigidbody2D rigid;

    void Awake() 
    {
        rigid = GetComponent<Rigidbody2D>();

        rigid.velocity = Vector2.left * moveSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Border"){
            Debug.Log(collision.gameObject.tag);
            Destroy(gameObject);
        }
    }
}
