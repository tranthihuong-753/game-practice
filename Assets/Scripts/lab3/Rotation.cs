using UnityEngine;

public class Rotation : MonoBehaviour
{
    public Transform target;       // Kéo vật thể mục tiêu vào đây
    public float rotationSpeed = 5f; // Tốc độ xoay (dùng cho chế độ Smooth)
    
    // Biến để chuyển đổi chế độ (Tích vào là xoay mượt, bỏ tích là xoay ngay lập tức)
    public bool useSmoothRotation = true;

    void Update()
    {
        // Kiểm tra xem có mục tiêu không, nếu không có thì không làm gì cả
        if (target == null) return;

        // Xử lý chuyển chế độ bằng phím Space cho tiện quay video
        if (Input.GetKeyDown(KeyCode.Space))
        {
            useSmoothRotation = !useSmoothRotation;
            Debug.Log("Đã đổi chế độ xoay: " + (useSmoothRotation ? "Mượt (Smooth)" : "Ngay lập tức (Instant)"));
        }

        if (useSmoothRotation)
        {
            // --- CÁCH 1: XOAY MƯỢT (Dùng Quaternion.Slerp) ---
            
            // B1: Tính vector hướng từ ta đến mục tiêu
            Vector3 direction = target.position - transform.position;
            
            // (Mẹo) Khóa trục Y của vector hướng để tháp pháo không bị ngửa lên trời/cắm xuống đất
            direction.y = 0; 

            // B2: Tạo một góc quay ảo (Quaternion) nhìn về hướng đó
            // Kiểm tra direction khác 0 để tránh lỗi
            if (direction != Vector3.zero) 
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);

                // B3: Xoay từ từ góc hiện tại sang góc đích
                // Slerp (Spherical Linear Interpolation): Nội suy cầu
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
        else
        {
            // --- CÁCH 2: XOAY NGAY LẬP TỨC (Dùng LookAt) ---
            
            // Hàm này bắt object nhìn thẳng vào mục tiêu ngay lập tức (không có độ trễ)
            // Lưu ý: LookAt mặc định sẽ nhìn cả trục Y (ngửa lên/xuống)
            transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        }
    }
    
    // Vẽ đường line nối tới mục tiêu để dễ debug
    void OnDrawGizmos()
    {
        if (target != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, target.position);
        }
    }
}