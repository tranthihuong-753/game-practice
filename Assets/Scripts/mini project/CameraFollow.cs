using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;        // Kéo Player vào đây
    public Vector3 offset = new Vector3(0, 5, -7); // Vị trí lệch (Cao 5m, Lùi 7m)
    public float smoothSpeed = 5f; // Độ mượt khi camera chạy theo

    // Dùng LateUpdate để đảm bảo Player đã di chuyển xong thì Camera mới đi theo (tránh rung lắc)
    void LateUpdate()
    {
        if (target == null) return;

        // Tính vị trí mong muốn
        Vector3 desiredPosition = target.position + offset;
        
        // Dùng Lerp để camera trôi từ từ đến vị trí đó (mượt hơn gán trực tiếp)
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        
        transform.position = smoothedPosition;

        // Camera luôn nhìn vào Player
        transform.LookAt(target.position);
    }
}