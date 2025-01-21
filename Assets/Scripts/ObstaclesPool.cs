using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesPool : MonoBehaviour
{

    [SerializeField] private GameObject obstaclePrefab;
    private int poolSize = 6;
    private GameObject[] obstacles;
    private float spawnTime = 2f;
    private int obstacleCount;
    private float timeLapse;
    [SerializeField] private float xSpawnPosition=5f;
    [SerializeField] private float maxYPosition=1.82f;
    [SerializeField] private float minYPosition=-2f;
    // Start is called before the first frame update
    void Start()
    {
        obstacles = new GameObject[poolSize];

        for(int i = 0; i < poolSize; i++)
        {
            obstacles[i] = Instantiate(obstaclePrefab);
            obstacles[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeLapse += Time.deltaTime;
        if (timeLapse > spawnTime && !GameManager.Instance.isGameOver)
        {
            SpawnObstacle();
        }
    }


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

        if (obstacleCount == poolSize)
        {
            obstacleCount = 0;
        }
    }
}
