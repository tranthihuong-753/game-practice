using UnityEngine;
using System.Collections;

public class PlayerVisualEffects : MonoBehaviour
{
    [Header("Hiệu ứng nháy trắng khi dính đạn")]
    public Renderer playerRenderer;
    public Color flashColor = Color.white;
    private Color originalColor;
    private Coroutine flashRoutine;

    [Header("Hiệu ứng chết")]
    public GameObject explosionPrefab;

    void Start()
    {
        // Lưu lại màu gốc của Player (ví dụ màu xanh)
        if (playerRenderer == null) playerRenderer = GetComponent<Renderer>();
        originalColor = playerRenderer.material.color;
    }

    // Hàm 1: Nháy trắng khi dính đạn
    public void HieuUngNhayDam(int currentHealth)
    {
        // Nếu đang nháy dở thì dừng lại để nháy cái mới
        if (flashRoutine != null) StopCoroutine(flashRoutine);
        flashRoutine = StartCoroutine(FlashRoutine());
    }

    IEnumerator FlashRoutine()
    {
        // Đổi sang màu trắng
        playerRenderer.material.color = flashColor;
        
        // Chờ 0.1 giây
        yield return new WaitForSeconds(0.1f);
        
        // Trả về màu cũ
        playerRenderer.material.color = originalColor;
    }

    // Hàm 2: Nổ và biến mất
    public void HieuUngChet()
    {
        // 1. Tạo hiệu ứng nổ tại vị trí Player
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }

        // 2. Hủy object Player (Biến mất khỏi thế giới)
        Destroy(gameObject);
        
        // Lưu ý: Khi destroy Player, Camera có thể bị lỗi vì mất Target. 
        // Nhưng trong Mini Project thì kệ cũng được, hoặc Camera sẽ đứng yên chỗ cũ.
    }
}