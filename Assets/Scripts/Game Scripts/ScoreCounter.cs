using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public float currentScore { get; private set; }

    [Header("UI")]
    [SerializeField] Text scoreText;

    [Header("Puntuaciones objetivo para cambiar dificultad")]
    [SerializeField] private int scoreToEasy; // Al llegar a esta puntuación, cambiar la dificultad desde "Very Easy" a "Easy".
    [SerializeField] private int scoreToMedium;
    [SerializeField] private int scoreToHard;
    [SerializeField] private int scoreToVeryHard;
    void Update()
    {
        if (GameManager.Instance.gameIsPaused) return;

        scoreText.text = "Score: " + Mathf.FloorToInt(currentScore);

        if (currentScore > scoreToVeryHard) GameManager.Instance.SetDifficulty(GameDifficulty.VeryHard);
        else if (currentScore > scoreToHard) GameManager.Instance.SetDifficulty(GameDifficulty.Hard);
        else if (currentScore > scoreToMedium) GameManager.Instance.SetDifficulty(GameDifficulty.Medium);
        else if (currentScore > scoreToEasy) GameManager.Instance.SetDifficulty(GameDifficulty.Easy);
    }

    public void AddScore(int value)
    {
        // Si se quiere añadir puntos extra (por destruir obstáculos, por ej.) usar esta función
        
        if (GameManager.Instance.gameIsOver) return;
        if (GameManager.Instance.inGameIntro) return;
        if (GameManager.Instance.gameIsPaused) return;

        currentScore += value;
    }
}
