using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D),typeof(Animator))]

public class SoyBoyController : MonoBehaviour
{
    public float speed = 14f;
    public float accel = 6f;
    private Vector2 input;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator animator;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        // Assign the value of accel — the public float field — to a private variable named acceleration.
                var acceleration = accel;
        var xVelocity = 0f;
        // If horizontal axis controls are neutral, then xVelocity is set to 0, otherwise xVelocity is set to the current x velocity of the rb(aka Rigidbody2D) component.
        if (input.x == 0)
        {
            xVelocity = 0f;
        }
        else
        {
            xVelocity = rb.velocity.x;
        }
        // Force is added to rb by calculating the current value of the horizontal axis controls multiplied by speed, which is in turn multiplied by acceleration.
        rb.AddForce(new Vector2(((input.x * speed) - rb.velocity.x)
        * acceleration, 0));
        // Velocity is reset on rb so it can stop Super Soy Boy from moving left or right when controls are in a neutral state.
                rb.velocity = new Vector2(xVelocity, rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        // gets X and Y values from the built-in Unity control axes name Horizontal and Jump.
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Jump");
        // If input.x is greater than 0 then the player is facing right, so the sprite gets flipped on the X axis.
        if (input.x > 0f)
        {
            sr.flipX = false;
        }
        else if (input.x < 0f)
        {
            sr.flipX = true;
        }
    }
}
