using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorBalas : MonoBehaviour
{
    [SerializeField] private Transform controladorDisparo;
    [SerializeField] private GameObject bala;

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
    }

}
