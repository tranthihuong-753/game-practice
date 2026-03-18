using UnityEngine;

public class EnemyProperty : MonoBehaviour
{
    [Header("Chỉ số của Enemy")]
    public string enemyName = "Base Enemy";
    public float moveSpeed = 2.0f;
    public int health = 100;
    public Color displayColor = Color.white;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Tự động cập nhật màu sắc khi game bắt đầu
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = displayColor;
        }

        Debug.Log("Spawned: " + enemyName + " | HP: " + health + " | Speed: " + moveSpeed);
    }

    void Update()
    {
        // Di chuyển đơn giản sang trái/phải để kiểm tra tốc độ
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }
}