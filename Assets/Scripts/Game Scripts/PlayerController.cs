using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocity = 3f;
    private Rigidbody2D rb;
    private Animator animator;

    [Header("Sonido")]
    [SerializeField] AudioClip sfxDestroyed;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void OnEnable()
    {
        GameManager.OnGameOver += DestroyShip;
    }
    void OnDisable()
    {
        GameManager.OnGameOver -= DestroyShip;
    }
    void Start()
    {
        rb.simulated = true;
    }
    void Update()
    {
        if (GameManager.Instance.gameIsPaused) return; // Ignorar Input si el juego está pausado
        if (GameManager.Instance.gameIsOver) return;

        animator.SetFloat("val_Velocity", rb.velocity.y);
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * velocity;
        }
    }
    void DestroyShip()
    {
        rb.simulated = false;
        SoundManager.Instance.PlaySound(sfxDestroyed);
        animator.SetTrigger("DestroyShip");
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            GameManager.Instance.LoseGame();
        }
    }
}
