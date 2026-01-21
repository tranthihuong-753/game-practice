using UnityEngine;

public class RotateToTarget : MonoBehaviour
{
    public Transform target;
    public float rotateSpeed = 5f;
    public float angle;

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        dir.y = 0;

        if (dir.sqrMagnitude < 0.0001f) return;

        // SignedAngle trên XZ
        angle = Vector3.SignedAngle(Vector3.forward, dir, Vector3.up);

        // Quaternion đích (xoay tuyệt đối)
        Quaternion targetRot = Quaternion.Euler(0, angle, 0);

        // Xoay mượt, KHÔNG GIẬT
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRot,
            rotateSpeed * Time.deltaTime
        );
    }
}
