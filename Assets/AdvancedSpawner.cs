using UnityEngine;
public class AdvancedSpawner : MonoBehaviour
{
    public GameObject[] enemyVariants; // Kéo các Variant vào đây
    public float spawnRate = 2f;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnRate);
    }

    void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, enemyVariants.Length);
        Instantiate(enemyVariants[randomIndex], transform.position, Quaternion.identity);
    }
}