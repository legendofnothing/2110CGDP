using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlip : MonoBehaviour
{
    //prime did this
    private bool _facingRight;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Flip();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Flip();
        }
    }
    void Flip()
    {
        _facingRight = !_facingRight;
        Vector2 playerScale = this.transform.localScale;
        playerScale.x = playerScale.x * -1;
        this.transform.localScale = playerScale;
    }
}
