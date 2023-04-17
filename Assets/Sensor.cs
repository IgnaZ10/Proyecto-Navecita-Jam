using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    private float limiteDerecha = 17;
    void Update()
    {
        if (transform.position.x >= limiteDerecha) 
        {
            Destroy(gameObject);    
        }
    }

    



}
