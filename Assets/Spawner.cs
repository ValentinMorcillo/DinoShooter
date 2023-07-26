using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float spawnInterval = 1.0f;
    public Vector3 spawnAreaSize = new Vector3(10, 0, 10);
    public float spawnIcreaseRate = 2.0f;
    public float spawnIntervalMin = 0.5f;
    private float timeSinceLastSpawn = 0.0f;

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnPrefab();
            timeSinceLastSpawn = 0.0f;
            if (spawnInterval - spawnIcreaseRate > spawnIntervalMin)
            {
                spawnInterval -= spawnIcreaseRate;
            }
            else
            {
                spawnInterval = spawnIntervalMin;
            }

        }
    }

    void SpawnPrefab()
    {
        Vector3 spawnPosition = transform.position + new Vector3(
            Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
            0,
            Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)
        );
        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, spawnAreaSize);
    }
}
