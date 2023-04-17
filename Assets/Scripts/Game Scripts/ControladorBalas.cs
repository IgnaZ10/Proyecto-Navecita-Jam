using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorBalas : MonoBehaviour
{
    [SerializeField] private Transform controladorDisparo;
    [SerializeField] private GameObject bala;

    private void Update()
    {
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
