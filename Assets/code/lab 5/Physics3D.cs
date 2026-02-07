using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physics3D : MonoBehaviour
{
    public float forceAmount = 1000f;
    public float jumpForce = 5f;
    private Rigidbody rb;
    private bool shouldJump = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shouldJump = true;
        }
    }

    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward * forceAmount * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.back * forceAmount * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * forceAmount * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * forceAmount * Time.fixedDeltaTime);
        }

        if (shouldJump)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            shouldJump = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Va chạm với: " + collision.gameObject.name);
    }
}