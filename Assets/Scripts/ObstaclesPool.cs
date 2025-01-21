using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesPool : MonoBehaviour
{
    // Prefab del obst�culo a instanciar
    [SerializeField] private GameObject obstaclePrefab;
    // Para el tama�o del pool de obst�culos
    private int poolSize = 6;
    private GameObject[] obstacles;
    // Para el tiempo entre cada aparici�n de un obst�culo
    private float spawnTime = 2f;
    private int obstacleCount;
    private float timeLapse;

    // Para controlar las posiciones de aparici�n de los obst�culos y dar el maximo y minimo de los valores random
    [SerializeField] private float xSpawnPosition=5f;
    [SerializeField] private float maxYPosition=1.82f;
    [SerializeField] private float minYPosition=-2f;


    // Start is called before the first frame update
    void Start()
    {
        // Inicializa el pool de obst�culos
        obstacles = new GameObject[poolSize];

        for(int i = 0; i < poolSize; i++)
        {
            obstacles[i] = Instantiate(obstaclePrefab);//Instancia el obstaculo
            obstacles[i].SetActive(false);//Desactiva el obstaculo inicialmente
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Controla el tiempo para la aparici�n de obst�culos
        timeLapse += Time.deltaTime;
        if (timeLapse > spawnTime && !GameManager.Instance.isGameOver)
        {
            SpawnObstacle();
        }
    }

    // Funcion para activar un obst�culo del pool en una posici�n aleatoria
    private void SpawnObstacle()
    {
        timeLapse = 0f;

        float ySpawnPosition = Random.Range(minYPosition, maxYPosition);
        Vector2 spawnPosition = new Vector2(xSpawnPosition, ySpawnPosition);
        obstacles[obstacleCount].transform.position = spawnPosition;

        if (!obstacles[obstacleCount].activeSelf)
        {
            obstacles[obstacleCount].SetActive(true);

        }

        obstacleCount++;

        // Reinicia el contador cuando llega al l�mite del pool
        if (obstacleCount == poolSize)
        {
            obstacleCount = 0;
        }
    }
}
