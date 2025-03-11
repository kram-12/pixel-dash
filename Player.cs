using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float acceleration = 0.1f;
    private Rigidbody2D rb;
    private Animator animator;

    public float jumpHeight = 7f;
    private bool isGround = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        speed += acceleration * Time.deltaTime;
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if(Input.GetKey(KeyCode.Space) && isGround) 
        {
            Jump();
            animator.SetBool("jump", true);
            isGround = false;
        }
    }

    void Jump() 
    {
        Vector2 velocity = rb.velocity;
        velocity.y = jumpHeight;
        rb.velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground") 
        {
            animator.SetBool("jump", false);
            isGround = true;
            //Console.WriteLine("Grounded");
        }
        if (other.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }
}
