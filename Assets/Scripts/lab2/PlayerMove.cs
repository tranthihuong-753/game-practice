using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;
    Vector3 moveDir;

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        moveDir = new Vector3(h, 0, v);

        if (moveDir.magnitude > 1)
            moveDir = moveDir.normalized;

        transform.position += moveDir * speed * Time.deltaTime;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position,
            transform.position + moveDir);
    }
}
