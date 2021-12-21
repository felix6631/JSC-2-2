using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private SpriteRenderer sprd;
    private Transform pos;
    public float jumpHeight = 6.0f;
    public float speed = 0.1f;
    public float moveX = 0;
    public bool jumpActive = true;
    public int dashActive = 2;
    public float dashTime = 1.0f;
    private float dashTimer;
    public float dashSpeed = 50000.0f;

    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        bc2d = gameObject.GetComponent<BoxCollider2D>();
        tf = gameObject.GetComponent<Transform>();
        sprd = gameObject.GetComponent<SpriteRenderer>();
        pos = gameObject.GetComponent<Transform>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Block" || collision.gameObject.tag == "ClrCnt")
        {
            jumpActive = true;
            dashActive = 2;
        }
        if (collision.gameObject.tag == "Damage")
        {
            Debug.Log("Dead");
            pos.position = Vector3.zero;
            rb2d.velocity = Vector2.zero;
            SceneManager.LoadScene(0);
        }
        if (collision.gameObject.tag == "BigJump")
        {
            rb2d.velocity = Vector2.zero;
            rb2d.velocity = Vector2.up * dashSpeed*2; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        //frb2d.velocity = Vector2.zero;

        if (Input.GetKeyDown(KeyCode.C) && dashActive > 0)
        {
            Dash(VectorInput());
        }
        else
            move(VectorInput());
    }


    void move(Vector2 vector)
    {
        speed = 0.05f;
        if (Input.GetKeyDown(KeyCode.Z) && jumpActive) //jump
        {
            rb2d.velocity = new Vector2(0, jumpHeight);
            jumpActive = false;
        }
        
        vector.y = 0f;
        
        transform.Translate(new Vector3(vector.x, vector.y, 0f) * speed);
    }

    void Dash(Vector2 vector)
    {
        rb2d.velocity = Vector2.zero;
        rb2d.velocity = (vector * dashSpeed);
        dashActive -= 1;
        //transform.Translate(new Vector3(vector.x, vector.y, 0f) * dashSpeed * Time.deltaTime);
    }

    Vector2 VectorInput()
    {
        Vector2 vector = new Vector2();
        if (Input.GetKey(KeyCode.LeftArrow))
            vector.x = -1f;
        else if (Input.GetKey(KeyCode.RightArrow))
            vector.x = 1f;
        if (Input.GetKey(KeyCode.UpArrow))
            vector.y = 1f;
        else if (Input.GetKey(KeyCode.DownArrow))
            vector.y = -1f;

        return vector;
    }

}