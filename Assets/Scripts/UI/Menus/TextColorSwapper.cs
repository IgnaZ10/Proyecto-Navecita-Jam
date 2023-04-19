using UnityEngine;
using UnityEngine.UI;

public class TextColorSwapper : MonoBehaviour
{
    Text text;
    void Awake()
    {
        text = GetComponent<Text>();
    }
    public void SetToWhite()
    {
        text.color = Color.white;
    }
    public void SetToBlack()
    {
        text.color = Color.black;
    }
}
