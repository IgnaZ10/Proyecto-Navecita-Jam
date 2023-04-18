using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public float velocity = 3f;
    private Rigidbody2D rb;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.gameIsPaused) return; // Ignorar Input si el juego está pausado

        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * velocity;
            
        }

    }
    
}
