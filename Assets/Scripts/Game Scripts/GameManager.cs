using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameDifficulty currentDificulty { get; private set; }
    public bool gameIsPaused { get; private set; }
    public bool gameIsOver { get; private set; }
    public bool inGameIntro { get; private set; }

    public delegate void GameManagerAction();
    public static event GameManagerAction OnGameStart;
    public static event GameManagerAction OnGamePause;
    public static event GameManagerAction OnGameResume;
    public static event GameManagerAction OnGameOver;

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
        inGameIntro = true;
        gameIsPaused = false;
        gameIsOver = false;
        Time.timeScale = 1;
        SetDifficulty(GameDifficulty.VeryEasy);
    }
    void Update()
    {
        if (inGameIntro && Input.GetMouseButtonDown(0))
        {
            inGameIntro = false;
            if (OnGameStart != null)
            {
                OnGameStart();
            }
        }
        if (!gameIsOver && !gameIsPaused && Input.GetKeyDown(KeyCode.Escape))
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
    public void LoseGame()
    {
        gameIsOver = true;
        if (OnGameOver != null)
        {
            OnGameOver();
        }
    }
}