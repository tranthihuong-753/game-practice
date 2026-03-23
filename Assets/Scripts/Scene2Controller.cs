using UnityEngine;
using TMPro;

public class Scene2Controller : MonoBehaviour
{
    public TextMeshProUGUI scoreDisplay;

    void Update()
    {
        // Liên tục cập nhật điểm từ Singleton lên UI của Scene 2
        if (scoreDisplay != null && DataManager.instance != null)
        {
            scoreDisplay.text = "Score from Scene 1: " + DataManager.instance.score;
        }
    }
}