using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;            // Speed of the player movement
    public Rigidbody2D rb;

    Vector2 moveDirection;

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // Get horizontal input
        float moveY = Input.GetAxis("Vertical");   // Get vertical input



        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);




    }


}

