using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] AudioClip sfxDestroyed;
    // Start is called before the first frame update
    [SerializeField] public float vida;
    public int puntos = 10;
    private ScoreCounter scoreCounter;

    private void Start()
    {
        scoreCounter = GameObject.Find("ScoreCounter").GetComponent<ScoreCounter>();
    }

    public void TomarDa�o(float da�o) 
    {
        vida -= da�o;
        if (vida <= 0)
        {
            Muerte();
        }
    }
    public void Muerte() 
    {
        scoreCounter.AddScore(puntos);
        SoundManager.Instance.PlaySound(sfxDestroyed);
        Destroy(gameObject);
    }
    
}
