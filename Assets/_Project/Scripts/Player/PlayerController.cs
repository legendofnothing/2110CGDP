using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Summary: Handles player control
//Created by: leg

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;

    Rigidbody2D rb;

    private void Start() {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        Movement();
    }

    //Handles Movement
    private void Movement() {
        //Get horiztonal Input
        var horizontalInput = Input.GetAxisRaw("Horizontal");

        //Move by using rigidBody2D.velocity
        rb.velocity = new Vector2(horizontalInput * playerSpeed, rb.velocity.y);
    }

}