using UnityEngine;

public class PauseMenuLogic : MonoBehaviour
{
    [SerializeField] Canvas pauseMenuCanvas;
    void OnEnable()
    {
        GameManager.OnGamePause += ShowMenu;
        GameManager.OnGameResume += HideMenu;
    }
    void OnDisable()
    {
        GameManager.OnGamePause -= ShowMenu;
        GameManager.OnGameResume -= HideMenu;
    }
    void HideMenu()
    {
        pauseMenuCanvas.gameObject.SetActive(false);
    }
    void ShowMenu()
    {
        pauseMenuCanvas.gameObject.SetActive(true);
    }
}
