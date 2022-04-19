using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float move;
    [SerializeField] float MoveSpeed = 35f;
    [SerializeField] float jumpSpeed = 15f;
    [SerializeField] Rigidbody2D RB;
    [SerializeField] Collider2D Coll;
    bool ground;
    [SerializeField] float DashSpeed = 1500;
    [SerializeField] LayerMask Ground;
    void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        Coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");
        ground = Coll.IsTouchingLayers(Ground);
    }
    void FixedUpdate()
    {
        //dash();
        transform.Translate(move * MoveSpeed * Time.deltaTime, 0, 0);
        if(Input.GetKeyDown(KeyCode.Space) && ground == true)
        {
            RB.velocity = new Vector2(0, jumpSpeed);
            ground = false;
        }
    }
    /*
    void dash()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            RB.velocity = new Vector2(DashSpeed, 0);
        }
    }
    */
}
