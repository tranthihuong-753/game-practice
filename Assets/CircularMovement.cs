using UnityEngine;

public class CircularMovement : MonoBehaviour
{
    [Header("Cài đặt quỹ đạo")]
    public float speed = 2.0f;       // Tốc độ quay
    public float radius = 3.0f;      // Bán kính vòng tròn

    private float timer = 0f;
    private Vector3 startPosition;

    void Start()
    {
        // Lưu lại vị trí tâm của vòng tròn (vị trí lúc vừa được spawn)
        startPosition = transform.position;
    }

    void Update()
    {
        // Tăng thời gian dựa trên tốc độ
        timer += Time.deltaTime * speed;

        // Tính toán vị trí X và Y dựa trên hàm Sin và Cos
        float x = Mathf.Cos(timer) * radius;
        float y = Mathf.Sin(timer) * radius;

        // Cập nhật vị trí mới cho Enemy
        transform.position = startPosition + new Vector3(x, y, 0);
    }
}