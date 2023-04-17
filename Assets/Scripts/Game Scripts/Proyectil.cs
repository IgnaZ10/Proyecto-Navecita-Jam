using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Proyectil : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float velocity = 3f;
    [SerializeField] public float daño = 20f;
    [SerializeField] private float tiempo = 2f;

    private void Start()
    {
        Invoke("AutoDestruccionBala", tiempo);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * velocity * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemigo")) 
        {
            other.GetComponent<Enemigo>().TomarDaño(daño);
            Destroy(gameObject);
        }

        
    }
    private void AutoDestruccionBala() 
    {
        Destroy(gameObject);
    }

}
