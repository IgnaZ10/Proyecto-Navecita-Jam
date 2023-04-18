using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuLogic : MonoBehaviour
{
    [SerializeField] Canvas pauseMenuCanvas;
    [SerializeField] Selectable resumeButton;

    bool inAnimation;
    Animator anim;
    Coroutine storedCoroutine;
    void Awake()
    {
        anim = pauseMenuCanvas.gameObject.GetComponent<Animator>();
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
        if (inAnimation) return;
        anim.Play("pausemenu_close");
        if (storedCoroutine != null) StopCoroutine(storedCoroutine);
        storedCoroutine = StartCoroutine(WaitForMenuClose());
    }
    void ShowMenu()
    {
        if (inAnimation) return;
        pauseMenuCanvas.gameObject.SetActive(true);
        anim.Play("pausemenu_open");
        if (storedCoroutine != null) StopCoroutine(storedCoroutine);
        storedCoroutine = StartCoroutine(WaitForMenuOpen());
    }
    IEnumerator WaitForMenuClose()
    {
        inAnimation = true;
        AnimationClip currentClip = anim.GetCurrentAnimatorClipInfo(0)[0].clip;

        yield return new WaitForSecondsRealtime(currentClip.length);

        GameManager.Instance.ResumeGame();
        pauseMenuCanvas.gameObject.SetActive(false);
        inAnimation = false;
    }
    IEnumerator WaitForMenuOpen()
    {
        inAnimation = true;
        AnimationClip currentClip = anim.GetCurrentAnimatorClipInfo(0)[0].clip;

        yield return new WaitForSecondsRealtime(currentClip.length);

        resumeButton.Select();
        inAnimation = false;
    }
}
