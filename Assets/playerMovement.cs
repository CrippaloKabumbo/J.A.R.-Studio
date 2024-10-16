using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movement;
    private float move;
    public float speed;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");

        if (move > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Face right
        }
        else if (move < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Face left
        }
        animator.SetFloat("Speed", Mathf.Abs(move)); // Set Speed parameter based on movement
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
    }
}
