using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad_5 : MonoBehaviour
{
    public GameObject cubePrefab; 
    public float spawnSize = 10.0f; 

    private List<Vector3> spawnPoints = new List<Vector3>(); 

    void Start()
    {
        generateSpawnPoints();
        generateCubes();
    }

    void generateSpawnPoints() {
        while(spawnPoints.Count < 10) {
            Vector3 randomSpawnPoint = new Vector3(Random.Range(-10, 10), 0.5f, Random.Range(-10, 10));
            if (!spawnPoints.Contains(randomSpawnPoint)) {
                spawnPoints.Add(randomSpawnPoint);
            }
        }
    }

    void generateCubes() {
        foreach(Vector3 spawnPoint in spawnPoints) {
            Instantiate(cubePrefab, spawnPoint, Quaternion.identity);
        }
    }
}
