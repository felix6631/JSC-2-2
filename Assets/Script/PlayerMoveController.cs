using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerMoveController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    float horizontal; //¹æÇâ°ª
    public Animator animator;
    public SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        animator.SetBool("jump", true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetBool("jump", false);
    }

    void Move()
    {
        animator.SetBool("walk", false);
        horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
        {
            animator.SetBool("walk", true);
            if (horizontal > 0)
                rend.flipX = false;
            else
                rend.flipX = true;
        }
        else
            animator.SetBool("walk", false);
     
        Vector3 dir = horizontal * Vector3.right;
        this.transform.Translate(dir * moveSpeed * Time.deltaTime);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}