using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameDifficulty currentDificulty { get; private set; }
    public bool gameIsPaused { get; private set; }

    public delegate void GameManagerAction();
    public static event GameManagerAction OnGamePause;
    public static event GameManagerAction OnGameResume;

    public static GameManager Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

    }
    void Start()
    {
        gameIsPaused = false;
        Time.timeScale = 1;
        SetDifficulty(GameDifficulty.VeryEasy);
    }
    void Update()
    {
        if (!gameIsPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }
    public void SetDifficulty(GameDifficulty newValue)
    {
        currentDificulty = newValue;
    }
    public void PauseGame()
    {
        gameIsPaused = true;
        Time.timeScale = 0;

        if (OnGamePause != null)
        {
            OnGamePause();
        }
    }
    public void ResumeGame()
    {
        gameIsPaused = false;
        Time.timeScale = 1;
        
        if (OnGameResume != null)
        {
            OnGameResume();
        }
    }
}

/// <summary>
/// Indica el nivel de dificultad del juego. Sirve para que los Spawners generen distintos tipos de obstáculos.
/// </summary>
public enum GameDifficulty
{
    VeryEasy = 0,
    Easy = 1,
    Medium = 2,
    Hard = 3,
    VeryHard = 4
}