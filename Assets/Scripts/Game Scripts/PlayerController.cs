using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocity = 3f;
    private Rigidbody2D rb;
    private Animator animator;
    private float savedGravityScale;

    [Header("Sonido")]
    [SerializeField] AudioClip sfxDestroyed1;
    [SerializeField] AudioClip sfxDestroyed2;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        savedGravityScale = rb.gravityScale; // Se guarda el valor de gravityScale del Rigidbody2D establecido en el inspector, para luego volvérselo a asignar al reactivar la gravedad.
    }
    void OnEnable()
    {
        GameManager.OnGameStart += StartMoving;
    }
    void OnDisable()
    {
        GameManager.OnGameStart -= StartMoving;
    }
    void Start()
    {
        // La nave no cae mientras se está en "Intro",
        // la gravedad se vuelve a activar al hacer el Input (función StartMoving(), activado por el evento del GameManager: OnGameStart)
        rb.gravityScale = 0;
    }
    void Update()
    {
        // Salir de Update() si se cumple una de las siguientes condiciones:
        if (GameManager.Instance.gameIsPaused) return;
        if (GameManager.Instance.gameIsOver) return;

        animator.SetFloat("val_Velocity", rb.velocity.y);
        
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * velocity;
        }
    }
    void CollideShip(AudioClip soundEffect)
    {
        rb.simulated = false; // Desactivar la colisión
        SoundManager.Instance.PlaySound(soundEffect);
        animator.SetTrigger("DestroyShip");
    }

    void StartMoving()
    {
        animator.SetTrigger("Start");
        rb.gravityScale = savedGravityScale;
        rb.simulated = true; // Reactivar la colisión
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Por ahora, al tocar un obstáculo se pierde instantáneamente
        if (collision.CompareTag("Enemigo"))
        {
            CollideShip(sfxDestroyed1);
            GameManager.Instance.LoseGame();
        }
        else if (collision.CompareTag("LimitePantalla"))
        {
            CollideShip(sfxDestroyed2);
            GameManager.Instance.LoseGame();
        }
    }
}
