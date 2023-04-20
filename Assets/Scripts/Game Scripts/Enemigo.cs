using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public float vida;
    private ScoreCounter scoreCounter;

    private void Start()
    {
        scoreCounter = GameObject.Find("ScoreCounter").GetComponent<ScoreCounter>();
    }

    public void TomarDaño(float daño) 
    {
        vida -= daño;
        if (vida <= 0)
        {
            Muerte();
        }
    }
    public void Muerte() 
    {
        Destroy(gameObject);
        scoreCounter.AddScore(10);
    }
    
}
