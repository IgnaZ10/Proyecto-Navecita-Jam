using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    private float currentScore;
    [SerializeField] private float pointsPerSecond;

    [Header("UI")]
    [SerializeField] Text scoreText;

    [Header("Puntuaciones objetivo para cambiar dificultad")]
    [SerializeField] private int scoreToEasy; // Al llegar a esta puntuaci�n, cambiar la dificultad desde "Very Easy" a "Easy".
    [SerializeField] private int scoreToMedium;
    [SerializeField] private int scoreToHard;
    [SerializeField] private int scoreToVeryHard;
    void Update()
    {
        if (GameManager.Instance.gameIsPaused) return;

        currentScore += Time.deltaTime * pointsPerSecond;
        scoreText.text = "Score: " + Mathf.FloorToInt(currentScore);

        if (currentScore > scoreToVeryHard) GameManager.Instance.SetDifficulty(GameDifficulty.VeryHard);
        else if (currentScore > scoreToHard) GameManager.Instance.SetDifficulty(GameDifficulty.Hard);
        else if (currentScore > scoreToMedium) GameManager.Instance.SetDifficulty(GameDifficulty.Medium);
        else if (currentScore > scoreToEasy) GameManager.Instance.SetDifficulty(GameDifficulty.Easy);
    }

    public void AddScore(int value)
    {
        // Si se quiere a�adir puntos extra (por destruir obst�culos, por ej.) usar esta funci�n
        currentScore += value;
    }
}
