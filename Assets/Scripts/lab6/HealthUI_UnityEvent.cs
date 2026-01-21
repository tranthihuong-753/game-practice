using TMPro;
using UnityEngine;

public class HealthUI_UnityEvent : MonoBehaviour
{
    public TextMeshProUGUI hpText;

    public Color fullHealthColor = Color.green;
    public Color lowHealthColor = Color.yellow;
    public Color zeroHealthColor = Color.red;

    public void UpdateHP(int hp)
    {
        hpText.text = "HP: " + hp;

        if (hp <= 0)
            hpText.color = zeroHealthColor;
        else if (hp <= 30)
            hpText.color = lowHealthColor;
        else
            hpText.color = fullHealthColor;
    }
}
