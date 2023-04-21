using UnityEngine;

public class GameHUDLogic : MonoBehaviour
{
    [SerializeField] Canvas hudCanvas;
    [SerializeField] Canvas introCanvas;

    void OnEnable()
    {
        GameManager.OnGameStart += ShowHUD;
        GameManager.OnGameStart += HideIntro;

        GameManager.OnGamePause += HideHUD;

        GameManager.OnGameResume += ShowHUD;
        
        GameManager.OnGameOver += HideHUD;
    }
    void OnDisable()
    {
        GameManager.OnGameStart -= ShowHUD;
        GameManager.OnGameStart -= HideIntro;

        GameManager.OnGamePause -= HideHUD;

        GameManager.OnGameResume -= ShowHUD;

        GameManager.OnGameOver -= HideHUD;
    }
    void Start()
    {
        HideHUD();
        ShowIntro();
    }

    void ShowIntro()
    {
        introCanvas.gameObject.SetActive(true);
    }
    void HideIntro()
    {
        introCanvas.gameObject.SetActive(false);
    }
    void ShowHUD()
    {
        hudCanvas.gameObject.SetActive(true);
    }
    void HideHUD()
    {
        hudCanvas.gameObject.SetActive(false);
    }
}
