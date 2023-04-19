using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ControladorBalas : MonoBehaviour
{
    [SerializeField] private Transform controladorDisparo;
    [SerializeField] private GameObject bala;
    public AudioSource Disparo;
    public AudioClip Shoot;
    
    private void Update()
    {
        if (GameManager.Instance.gameIsPaused) return; // Ignorar Input si el juego está pausado

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
