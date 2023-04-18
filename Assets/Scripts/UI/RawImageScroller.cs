using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Se usa para que la imagen de fondo haga scroll infinito dada una dirección.
/// </summary>
public class RawImageScroller : MonoBehaviour
{
    [SerializeField] Vector2 direction;
    RawImage img;
    void Awake()
    {
        img = GetComponent<RawImage>();
    }
    void Update()
    {
        Vector2 newPosition = new Vector2(
            (img.uvRect.position.x + direction.x * Time.deltaTime) % 100,
            (img.uvRect.position.y + direction.y * Time.deltaTime) % 100);
        img.uvRect = new Rect(newPosition, img.uvRect.size);
    }
}
