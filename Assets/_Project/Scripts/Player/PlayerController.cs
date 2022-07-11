using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Summary: Handles player control
//Created by: leg

public class PlayerController : MonoBehaviour
{
    [Header("Player Configs")]
    public float playerSpeed;   
    public float playerJumpPower;

    [Header("Other Configs")]
    public LayerMask groundLayer;

    Rigidbody2D rb;

    private void Start() {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update() {
        Jump();
    }

    private void FixedUpdate() {
        Movement();
    }

    //Handles Movement
    private void Movement() {
        //Get horiztonal Input
        var horizontalInput = Input.GetAxis("Horizontal");

        //Move by using rigidBody2D.velocity
        rb.velocity = new Vector2(horizontalInput * playerSpeed, rb.velocity.y);
    }

    //Handles Jumping 
    private void Jump() {
        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) {

            rb.AddForce(transform.up * playerJumpPower, ForceMode2D.Impulse);
        }
    }

    //Return true if player is hitting ground, else return false
    private bool IsGrounded() {
        //Cast a ray straight down
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, groundLayer);

        if (hit.collider == null) return false; else return true;
    }
}