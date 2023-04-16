using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameIsPaused { get; private set; }

    public delegate void GameManagerAction();
    public static event GameManagerAction OnGamePause;
    public static event GameManagerAction OnGameResume;

    public static GameManager Instance;
    void Start()
    {
        gameIsPaused = false;
        Time.timeScale = 1;
    }
    void Awake()
    {
        #region Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        #endregion

    }
    void Update()
    {
        if (!gameIsPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
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
