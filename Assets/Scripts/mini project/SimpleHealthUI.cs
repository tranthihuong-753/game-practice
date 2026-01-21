using UnityEngine;
using TMPro;

public class SimpleHealthUI : MonoBehaviour
{
    public TextMeshProUGUI healthText;

    // Hàm này phải là PUBLIC để UnityEvent nhìn thấy
    // Tên hàm tùy ý, miễn là nhận vào 1 số int khớp với bên kia
    public void CapNhatMau(int mauHienTai)
    {
        healthText.text = "HP: " + mauHienTai;
        
        if (mauHienTai <= 30) healthText.color = Color.yellow;
        else healthText.color = Color.green;
    }
    
    public void HienThiGameOver()
    {
        healthText.text = "YOU DIED!";
        healthText.color = Color.red;
    }
}