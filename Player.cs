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

        //Reset Position
        if(rigid.position.x < -4.5f){
            transform.Translate(Vector2.right * 0.2f * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform") {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) 
    {
        if(collision.gameObject.tag == "Platform") {
            isJumping = true;
        }    
    }
}
