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
    public float jumpHeight = 6.0f;
    public float speed = 1.0f;
    private float moveX = 0;
    private bool jumpActive = true;

    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        bc2d = gameObject.GetComponent<BoxCollider2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            bc2d.isTrigger = false;
            jumpActive = true;
        }
        else if(collision.gameObject.tag == "Wall")
        {
            moveX = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation.z = 0;
        moveInput();
    }

    

    void moveInput()
    {
        moveX = 0;
        if (Input.GetKeyDown(KeyCode.Space) && jumpActive)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpHeight);
            jumpActive = false;
            bc2d.isTrigger = true;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
            moveX = -1;
        else if (Input.GetKey(KeyCode.RightArrow))
            moveX = 1;
        transform.Translate(new Vector3(moveX, 0f, 0f)*0.1f);
    }

    void dash()
    {

    }
}
