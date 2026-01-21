using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject gameOverPanel;

    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    void OnEnable()
    {
        playerHealth.OnHealthChanged += CheckGameOver;
    }

    void OnDisable()
    {
        playerHealth.OnHealthChanged -= CheckGameOver;
    }

    void CheckGameOver(int hp)
    {
        if (hp <= 0)
        {
            gameOverPanel.SetActive(true);
            Debug.Log("GAME OVER");
        }
    }
}
