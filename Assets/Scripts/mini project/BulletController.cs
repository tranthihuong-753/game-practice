using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 10;
    public float lifeTime = 3f; // Tự hủy sau 3 giây nếu bắn trượt

    void Start()
    {
        // Tự hủy sau 3s để đỡ nặng máy
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // Đạn luôn bay về phía trước mặt nó
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // Kiểm tra nếu chạm vào Player (tìm component PlayerHealthEvent)
        PlayerHealthEvent playerHealth = other.GetComponent<PlayerHealthEvent>();

        if (playerHealth != null)
        {
            // Trừ máu
            playerHealth.TakeDamage(damage);
            
            // Hủy viên đạn ngay lập tức
            Destroy(gameObject);
        }
    }
}