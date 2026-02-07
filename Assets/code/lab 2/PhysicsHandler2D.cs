using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsHandler2D : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("PLAYER touch : " + collision.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("PLAYER fall through (TRIGGER): " + other.gameObject.name);
    }
}