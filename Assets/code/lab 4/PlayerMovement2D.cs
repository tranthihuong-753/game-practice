using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float jumpForce = 12f;
    private Rigidbody2D rb;
    private float moveInput;
    private bool shouldJump;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            shouldJump = true;
        }
    }

    void FixedUpdate()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");

        if (Mathf.Abs(moveInput) > 0.01f)
        {
            float targetSpeed = moveInput * moveSpeed;

            float speedDiff = targetSpeed - rb.velocity.x;

            rb.AddForce(new Vector2(speedDiff * rb.mass / Time.fixedDeltaTime, 0));
        }

        if (shouldJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);

            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            shouldJump = false;
            isGrounded = false;
        }
    }


    private void OnCollisionStay2D(Collision2D collision) => isGrounded = true;
    private void OnCollisionExit2D(Collision2D collision) => isGrounded = false;
}