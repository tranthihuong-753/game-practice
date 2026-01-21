using UnityEngine;
using UnityEngine.Events; // Bắt buộc phải có thư viện này

public class PlayerHealthEvent : MonoBehaviour
{
    // Thay vì dùng Action, ta dùng UnityEvent
    // UnityEvent<int>: Nghĩa là sự kiện này mang theo 1 gói tin là số nguyên (máu)
    // Phải để public thì nó mới hiện trong Inspector
    public UnityEvent<int> onHealthChanged;
    
    // Sự kiện chết (không mang theo tham số gì)
    public UnityEvent onPlayerDeath;

    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        // Cập nhật UI ngay lúc đầu
        onHealthChanged?.Invoke(currentHealth);
    }

    void Update()
    {
        // Vẫn bấm H để test
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        // PHÁT TIN: Invoke sẽ gọi tất cả những gì bạn đã kéo thả trong Inspector
        onHealthChanged?.Invoke(currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            onPlayerDeath?.Invoke();
        }
    }
}