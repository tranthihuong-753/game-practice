using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Kéo Prefab Enemy (hoặc Variant) vào ô này trong Inspector
    public GameObject enemyPrefab;

    void Update()
    {
        // Kiểm tra nếu người dùng nhấn phím Space (Dấu cách)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Hàm Instantiate dùng để tạo ra một bản sao của Prefab
            // Tham số: (Đối tượng mẫu, Vị trí tạo, Góc quay)
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            Debug.Log("Đã triệu hồi một Enemy!");
        }
    }
}