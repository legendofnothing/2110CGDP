using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Summary: Separate Dodge function to be added to Player Controller
//Created by: Ocill

public class PlayerDodge : MonoBehaviour
{
    Rigidbody2D rb;
    public float playerDodgePower;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
 
    private void Update() {
        Dodge();
    }

    void Dodge()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //Debug.Log("Dodging");
            rb.AddRelativeForce(transform.right * playerDodgePower);
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.A))
        {
            rb.AddRelativeForce(-transform.right * playerDodgePower);
        }
    }
}