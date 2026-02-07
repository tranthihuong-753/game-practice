using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PhysicsDebugger2D : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<SurfaceEffector2D>() != null)
        {
            Debug.Log("<color=green>Start:</color> Touch platform: " + collision.gameObject.name);
        }
        else if (collision.gameObject.GetComponent<PlatformEffector2D>() != null)
        {
            Debug.Log("<color=blue>Start:</color> Touch 1-side platform: " + collision.gameObject.name);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            Debug.Log("Player velocity: " + GetComponent<Rigidbody2D>().velocity.x);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("<color=red>End:</color> Leave: " + collision.gameObject.name);
    }
}