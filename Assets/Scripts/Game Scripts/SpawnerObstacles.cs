using UnityEngine;

public class SpawnerObstacles : MonoBehaviour
{
    public float tiempoMax = 1;
    [SerializeField] float tiempoInic = 0;
    public float altura;

    [Header("Prefabs de obst�culos")]
    [SerializeField] GameObject meteoritoVeryEasy;
    [SerializeField] GameObject meteoritoEasy;
    [SerializeField] GameObject meteoritoMedium;
    [SerializeField] GameObject meteoritoHard;
    [SerializeField] GameObject meteoritoVeryHard;

    void Start()
    {
        GameObject obstaculo = Instantiate(ObstaculoBasadoEnDificultad());
        obstaculo.transform.position = transform.position + new Vector3(0, 0, 0);
        Destroy(obstaculo, 3);
    }

    void Update()
    {
        if (tiempoInic > tiempoMax)
        {
            GameObject obstaculo = Instantiate(ObstaculoBasadoEnDificultad());
            obstaculo.transform.position = transform.position + new Vector3(0, Random.Range(-altura,altura), 0);
            Destroy(obstaculo, 10);
            tiempoInic = 0;
        }
        else
        {
            tiempoInic += Time.deltaTime;
        }
    }
    private GameObject ObstaculoBasadoEnDificultad()
    {
        int spawnTreshold = 10; // Chance de que aparezcan obst�culos dificiles (menor valor = menor chance).
        spawnTreshold += 10 * (int)GameManager.Instance.currentDificulty; // A mayor dificultad, se le suma m�s al n�mero.

        int randomNumber = Random.Range(0, ++spawnTreshold); // Se elige un n�mero aleatorio entre 0 y spawnTreshold (++ para que incluya el m�ximo valor de spawnTreshold)

        // Finalmente se elige un obst�culo.
        // Por ejemplo: En la dificultad "Very Easy" s�lo spawnea el meteoritoVeryEasy, ya que el n�mero random s�lo llega de 0 a 10,
        //              y en la dificultad "Very Hard" puede spawnear todo tipo de meteorito, incluido el meteoritoVeryHard.
        if (randomNumber > 40) return meteoritoVeryHard;
        else if (randomNumber > 30) return meteoritoHard;
        else if (randomNumber > 20) return meteoritoMedium;
        else if (randomNumber > 10) return meteoritoEasy;
        else return meteoritoVeryEasy;
    }
}
