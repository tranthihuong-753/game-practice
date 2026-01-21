using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    // EVENT
    public event Action<int> OnHealthChanged;

    void Start()
    {
        currentHealth = maxHealth;
        OnHealthChanged?.Invoke(currentHealth);
    }

    void Update()
    {
        // Nhấn H để trừ máu (đúng yêu cầu lab)
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // PHÁT SỰ KIỆN
        OnHealthChanged?.Invoke(currentHealth);
    }
}
