using UnityEngine;
using UnityEngine.UI;

public class GameOverMenuLogic : MonoBehaviour
{
    [SerializeField] GameData gameData;
    [SerializeField] ScoreCounter scoreCounter;

    [Header("UI - Configuración")]
    [SerializeField] Canvas gameOverMenuCanvas;
    [SerializeField] Text yourScoreText;
    [SerializeField] Text highScoreText;
    [SerializeField] Text highScoreObtainedText;
    void OnEnable()
    {
        GameManager.OnGameOver += HandleGameOver;
    }
    void OnDisable()
    {
        GameManager.OnGameOver -= HandleGameOver;
    }
    void Awake()
    {
        if (scoreCounter == null) scoreCounter = FindObjectOfType<ScoreCounter>();
    }
    void HandleGameOver()
    {
        gameOverMenuCanvas.gameObject.SetActive(true);
        yourScoreText.text = "Your Score: " + Mathf.FloorToInt(scoreCounter.currentScore);
        highScoreText.text = "High Score: " + Mathf.FloorToInt(gameData.highScore);

        if (scoreCounter.currentScore > gameData.highScore)
        {
            highScoreObtainedText.gameObject.SetActive(true);
            gameData.highScore = scoreCounter.currentScore;
        }
        else
        {
            highScoreObtainedText.gameObject.SetActive(false);
        }
    }
}
