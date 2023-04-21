using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuLogic : MonoBehaviour
{
    [SerializeField] private Canvas pauseMenuCanvas;
    [SerializeField] private Selectable resumeButton;

    private bool waitingForAnimation;
    private Animator animator;
    private Coroutine storedCoroutine;

    void Awake()
    {
        animator = pauseMenuCanvas.gameObject.GetComponent<Animator>();
    }
    void OnEnable()
    {
        GameManager.OnGamePause += ShowMenu;
    }
    void OnDisable()
    {
        GameManager.OnGamePause -= ShowMenu;
    }
    public void HideMenu()
    {
        if (waitingForAnimation) return;

        animator.Play("pausemenu_close");
        if (storedCoroutine != null) StopCoroutine(storedCoroutine);
        storedCoroutine = StartCoroutine(WaitForMenuClose());
    }
    void ShowMenu()
    {
        if (waitingForAnimation) return;

        pauseMenuCanvas.gameObject.SetActive(true);
        animator.Play("pausemenu_open");
        if (storedCoroutine != null) StopCoroutine(storedCoroutine);
        storedCoroutine = StartCoroutine(WaitForMenuOpen());
    }
    IEnumerator WaitForMenuClose()
    {
        waitingForAnimation = true;
        AnimationClip currentClip = animator.GetCurrentAnimatorClipInfo(0)[0].clip;

        yield return new WaitForSecondsRealtime(currentClip.length);

        GameManager.Instance.ResumeGame();
        pauseMenuCanvas.gameObject.SetActive(false);
        waitingForAnimation = false;
    }
    IEnumerator WaitForMenuOpen()
    {
        waitingForAnimation = true;
        AnimationClip currentClip = animator.GetCurrentAnimatorClipInfo(0)[0].clip;

        yield return new WaitForSecondsRealtime(currentClip.length);

        resumeButton.Select();
        waitingForAnimation = false;
    }
}
