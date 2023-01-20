using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject obstacle;
    public float spawnRate = 1f;

    private void Start()
    {
        InvokeRepeating("SpawnObstacle", 1, spawnRate);
    }

    private void SpawnObstacle()
    {
        var spawnedObstacle = Instantiate(obstacle,
            transform.position + new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), 0),
            quaternion.identity);
        Destroy(spawnedObstacle, 60);
    }
}