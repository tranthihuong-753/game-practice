using TMPro;
using UnityEngine;

public class AngleUI : MonoBehaviour
{
    public RotateToTarget rotateScript;
    public TextMeshProUGUI angleText;

    void Update()
    {
        angleText.text =
            "Signed Angle: " 
            + rotateScript.angle.ToString("F1") + "°";
    }
}
