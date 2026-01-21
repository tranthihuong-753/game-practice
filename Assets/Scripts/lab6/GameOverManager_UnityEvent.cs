using UnityEngine;

public class GameOverManager_UnityEvent : MonoBehaviour
{
    public GameObject gameOverPanel;

    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void CheckGameOver(int hp)
    {
        if (hp <= 0)
            gameOverPanel.SetActive(true);
    }
}
