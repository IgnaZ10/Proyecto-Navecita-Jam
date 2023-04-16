using UnityEngine;
using UnityEngine.UI;

public class MenuCursor : MonoBehaviour
{
    private Vector2 currentPosition;
    private RectTransform rt;
    void Awake()
    {
        rt = GetComponent<RectTransform>();
    }
    public void SetCursorPosition(RectTransform newRectTransform)
    {
        rt.anchoredPosition = newRectTransform.anchoredPosition;
    }
}
