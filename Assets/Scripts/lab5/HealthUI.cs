using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public TextMeshProUGUI hpText;

    public Color fullHealthColor = Color.green;
    public Color lowHealthColor = Color.yellow;
    public Color zeroHealthColor = Color.red;

    void OnEnable()
    {
        playerHealth.OnHealthChanged += UpdateHP;
    }

    void OnDisable()
    {
        playerHealth.OnHealthChanged -= UpdateHP;
    }

    void UpdateHP(int hp)
    {
        // Cập nhật text
        hpText.text = "HP: " + hp;

        // Đổi màu theo HP
        if (hp <= 0)
        {
            hpText.color = zeroHealthColor;
        }
        else if (hp <= 30)
        {
            hpText.color = lowHealthColor;
        }
        else
        {
            hpText.color = fullHealthColor;
        }
    }
}
