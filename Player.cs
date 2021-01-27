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

    void FixedUpdate() {        
        if(rigid.velocity.y < 0){
            Debug.DrawRay(rigid.position, Vector3.down * 2, new Color(0, 1, 0));

            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down * 2, 1, LayerMask.GetMask("Platform"));

            if(rayHit.collider != null){
                if(rayHit.distance < 1){
                    Debug.Log(rayHit.collider);
                    isJumping = false;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Platform")
        {
            isJumping = false;
        }
    }
}
