using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float moveSpeed;

    Rigidbody2D rigid;
    BoxCollider2D boxCol;

    void Awake() 
    {
        rigid = GetComponent<Rigidbody2D>();
        boxCol = GetComponent<BoxCollider2D>();
    }

    void Update() 
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        offCollider();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Border"){
            Debug.Log(collision.gameObject.tag);
            Destroy(gameObject);
        }
    }

    void offCollider(){
        Player player = GameObject.Find("Player").GetComponent<Player>();
        Rigidbody2D playerRigid = player.GetComponent<Rigidbody2D>();

        if (player.isJumping && playerRigid.velocity.y > 0){
            boxCol.enabled = false;
        }
        else {
            boxCol.enabled = true;
        }
    }
}
