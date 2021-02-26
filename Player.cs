using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int jumpPower;
    public bool isJumping;

    Rigidbody2D rigid;

    void Awake() 
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update() 
    {
        //Jump
        if(Input.GetButtonDown("Jump") && !isJumping){
            rigid.AddForce(Vector2.up *jumpPower, ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform"){
            isJumping = false;
        }
    }
}
