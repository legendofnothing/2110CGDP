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
    public float playerDodgePower;

    [Header("Other Configs")]
    public LayerMask groundLayer;

    Rigidbody2D rb;

    private void Start() {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update() {
        Jump();

        Dodge();
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

        //Handle Flipping
        if (horizontalInput < 0) transform.eulerAngles = new Vector3(0, 180, 0); //Left 

        if (horizontalInput > 0) transform.eulerAngles = new Vector3(0, 0, 0); //Right

        else transform.eulerAngles = gameObject.transform.eulerAngles;
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

    //Handles dodging 
    private void Dodge()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            rb.AddRelativeForce(transform.right * playerDodgePower);
        }
    }
}