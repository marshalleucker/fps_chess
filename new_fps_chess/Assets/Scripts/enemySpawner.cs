using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    void Start()
    {
        SpawnEnemy(); // Spawn an enemy when the scene starts
    }

    private void SpawnEnemy()
    {
        if (enemyPrefab != null)
        {
            Instantiate(enemyPrefab, transform.position, transform.rotation);
        }
        else
        {
            Debug.LogError("Enemy prefab is not assigned!");
        }
    }
}