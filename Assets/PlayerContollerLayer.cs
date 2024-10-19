using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is the script that to be attached to main player sprite via monobeahvior... All player movemovent is defined here
/// </summary>

public class PlayerControllerLayer : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movement;
    private float move;
    public float speed;
    public bool isInDialogue = false; // Track if the player is in dialogue
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");

        // Face the direction of movement
        transform.localScale = new Vector3(move >= 0 ? 4 : -4, 4, 1);

        animator.SetFloat("Speed", Mathf.Abs(move)); // Set Speed parameter based on movement
    }

    void FixedUpdate()
    {
        if (!isInDialogue)
        {
            rb.velocity = new Vector2(move * speed, rb.velocity.y); // Control player's velocity/speed
        }


       
    }
}
