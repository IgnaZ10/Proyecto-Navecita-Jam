using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerObstacles : MonoBehaviour
{
    public float tiempoMax = 1;
    [SerializeField] float tiempoInic = 0;
    public GameObject meteorito;
    public float altura;
    // Start is called before the first frame update
    void Start()
    {
        GameObject obstaculo = Instantiate(meteorito);
        obstaculo.transform.position = transform.position + new Vector3(0, 0, 0);
        Destroy(obstaculo, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (tiempoInic > tiempoMax)
        {
            GameObject obstaculo = Instantiate(meteorito);
            obstaculo.transform.position = transform.position + new Vector3(0, Random.Range(-altura,altura), 0);
            Destroy(obstaculo, 10);
            tiempoInic = 0;
        }
        else
        {
            tiempoInic += Time.deltaTime;
        }
    }
}
