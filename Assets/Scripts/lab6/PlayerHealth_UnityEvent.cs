using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth_UnityEvent : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public UnityEvent<int> OnHealthChanged;

    void Start()
    {
        currentHealth = maxHealth;
        OnHealthChanged.Invoke(currentHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        OnHealthChanged.Invoke(currentHealth);
    }
}
