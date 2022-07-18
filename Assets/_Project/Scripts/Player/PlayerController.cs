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

    private bool _isMoving;
    private bool _isDodging;

    private bool _canDodge = true;

    Rigidbody2D rb;

    private void Start() {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (!_isDodging) Jump();

        if (_isMoving) Dodge();
    }

    private void FixedUpdate() {
        if (!_isDodging) Movement();
    }

    //Handles Movement
    private void Movement() {
        //Get horiztonal Input
        var horizontalInput = Input.GetAxis("Horizontal");

        CanMove();

        if (CanMove())
        {
            //Move by using rigidBody2D.velocity
            rb.velocity = new Vector2(horizontalInput * playerSpeed, rb.velocity.y);

            //Handle Flipping
            if (horizontalInput < 0) transform.eulerAngles = new Vector3(0, 180, 0); //Left 

            if (horizontalInput > 0) transform.eulerAngles = new Vector3(0, 0, 0); //Right

            else transform.eulerAngles = gameObject.transform.eulerAngles;


            //Handle isMoving Condition
            if (horizontalInput > 0 || horizontalInput < 0) _isMoving = true; else _isMoving = false;
        }
    }

    //Handles Jumping 
    private void Jump() {
        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) {

            rb.AddForce(transform.up * playerJumpPower, ForceMode2D.Impulse);
        }
    }

    //Handles dodging 
    private void Dodge()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && _canDodge)
        {
            var horizontalInput = Input.GetAxisRaw("Horizontal");

            if (horizontalInput > 0) StartCoroutine(Dodging(1)); else StartCoroutine(Dodging(-1));
        }
    }

    //Return true if player is hitting ground, else return false
    private bool IsGrounded() {
        var offset = new Vector2(transform.position.x, transform.position.y - 0.05f); //Overlap Box Offset
        var size = new Vector2(transform.localScale.x - 0.02f, transform.localScale.y + 0.05f); //Overlap Box Size

        //Cast a ray straight down
        var checkOnGround = Physics2D.OverlapBox(offset, size, 0, groundLayer);

        if (checkOnGround == null) return false; else return true;
    }

    private bool CanMove()
    {
        if (!IsGrounded())
        {
            var checkColliding = Physics2D.OverlapBox(transform.position, new Vector2(transform.localScale.x + 0.1f, transform.localScale.y), 0, groundLayer);

            if (checkColliding == null) return true; 
            
            else
            {
                if (_isDodging) StopCoroutine(Dodging(0));

                return false;
            }
        }

        return true;
    }


    //Coroutine for dodging
    private IEnumerator Dodging(float dir) {
        //Store old Gravity Scale Value
        var oldGravityScale = rb.gravityScale;

        _isDodging = true;
        _canDodge = false;

        rb.gravityScale = 0;
        rb.velocity = new Vector2(rb.velocity.x, 0f);

        rb.AddForce(new Vector2(playerDodgePower * dir, 0f), ForceMode2D.Impulse); //Dogding Part

        yield return new WaitForSeconds(0.4f); //Dodging Duration (can turn this into a variable)

        rb.gravityScale = oldGravityScale;
        rb.velocity = Vector2.zero;

        _isDodging = false;

        yield return new WaitForSeconds(0.4f); //Dodging Cooldown (can turn this into a variable)

        _canDodge = true;
    }

    //Debug Only
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(new Vector2(transform.position.x, transform.position.y - 0.05f), new Vector2(transform.localScale.x - 0.02f, transform.localScale.y + 0.05f));
    }
}