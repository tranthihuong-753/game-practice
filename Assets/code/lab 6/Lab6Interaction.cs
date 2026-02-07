using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab6Interaction : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Cubee")
        {
            Debug.Log("<color=red>COLLISION:</color> Đâm vào tường cứng! Nhân vật bị chặn lại.");
            Renderer rend = GetComponent<Renderer>();
            if (rend != null)
            {
                rend.material.color = Color.red;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Cubeee")
        {
            Debug.Log("<color=green>Đã vào Zone</color>");

            // Kiểm tra an toàn trước khi đổi màu
            Renderer rend = GetComponent<Renderer>();
            if (rend != null)
            {
                rend.material.color = Color.green;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Cubeee")
        {
            Debug.Log("<color=yellow>Đã rời Zone</color>");

            Renderer rend = GetComponent<Renderer>();
            if (rend != null)
            {
                rend.material.color = Color.yellow;
            }
        }
    }
}
