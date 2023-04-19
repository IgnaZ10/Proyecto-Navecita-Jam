using UnityEngine;

public class ControladorBalas : MonoBehaviour
{
    [SerializeField] private Transform controladorDisparo;
    [SerializeField] private GameObject bala;
    public AudioSource Disparo;
    public AudioClip Shoot;
    
    private void Update()
    {
        if (GameManager.Instance.gameIsPaused) return; // Ignorar Input si el juego está pausado
        if (GameManager.Instance.gameIsOver) return;

        if (Input.GetMouseButtonDown(0)) 
        {
            Disparar();
        }
    }
    void Disparar() 
    {
        Instantiate(bala, controladorDisparo.position, controladorDisparo.rotation);
        Disparo.PlayOneShot(Shoot);
    }

}
