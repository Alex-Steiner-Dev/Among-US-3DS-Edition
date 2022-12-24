using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float speed;

    private Vector2 movement;
    private Vector2 input;

    private void Start()
    {
        AssignComponents();
    }

    private void Update()
    {
        Inputs();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void AssignComponents()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Move()
    {
        movement = input * speed;

        rb.AddForce(movement * speed);
    }

    private void Inputs()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        input = new Vector2(horizontal, vertical);
    }

    private void AnimationHandler()
    {
        if(input.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
