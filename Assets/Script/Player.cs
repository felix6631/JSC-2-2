using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
require methods
1. jump
2. move
3. mid air jump
4. dash (left and right)
5. shoot

additional
- melee
 *  */


public class Player : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private BoxCollider2D bc2d;
    private Transform tf;
    public float jumpHeight = 6.0f;
    public float speed = 0.1f;
    private float moveX = 0;
    private bool jumpActive = true;
    private bool dashActive = true;

    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        bc2d = gameObject.GetComponent<BoxCollider2D>();
        tf = gameObject.GetComponent<Transform>();
    }
    // Start is called before the first frame update
    void Start()
    {
    
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bc2d.isTrigger = true;
    }
    

    private void OnTriggerExit2D(Collider2D collision)
    {
        bc2d.isTrigger = false;
        jumpActive = true;
        dashActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput();
    }

    void moveInput()
    {
        moveX = 0; speed = 0.1f;
        if (Input.GetKeyDown(KeyCode.Space) && jumpActive) //jump
        {
            rb2d.velocity = new Vector2(0, jumpHeight);
            jumpActive = false;
            bc2d.isTrigger = true;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        { //moveing left and right
            moveX = -1;
            
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            moveX = 1;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashActive)
        {
            speed = 2.0f;
            dashActive = false;
        }

        transform.Translate(new Vector3(moveX, 0f, 0f)*speed);
    }

    void dash()
    {
        
    }
}
