using UnityEngine;
public class Miniproject : MonoBehaviour
{
    [Header("Cấu hình Spawner")]
    // Kéo các Prefab Variant (EnemyFast, EnemyStrong) vào danh sách này
    public GameObject[] enemyVariants;

    // Khoảng thời gian giữa mỗi lần spawn (giây)
    public float spawnInterval = 3.0f;

    void Start()
    {
        // Gọi hàm "SpawnRandomEnemy" lặp lại: bắt đầu ngay (0s), mỗi 'spawnInterval' giây
        InvokeRepeating("SpawnRandomEnemy", 0f, spawnInterval);
    }

    void SpawnRandomEnemy()
    {
        if (enemyVariants.Length == 0)
        {
            Debug.LogWarning("Chưa gán Prefab vào mảng enemyVariants!");
            return;
        }

        // Chọn ngẫu nhiên một loại Enemy trong danh sách
        int randomIndex = Random.Range(0, enemyVariants.Length);
        GameObject selectedPrefab = enemyVariants[randomIndex];

        // Tạo Enemy tại vị trí của Spawner
        Instantiate(selectedPrefab, transform.position, Quaternion.identity);

        Debug.Log("Đã spawn: " + selectedPrefab.name);
    }
}