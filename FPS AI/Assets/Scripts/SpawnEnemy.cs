using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public int numberOfEnemies;
    public List<Vector3> spawnPoints;
    public bool spawnExists = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        numberOfEnemies = GameObject.FindGameObjectsWithTag("enemy").Length;
    }

    public void SpawnRandomEnemy()
    {
        
        if (numberOfEnemies < 7)
        {
            Vector3 enemyPosition = new Vector3(UnityEngine.Random.Range(-5.3f, 21.2f), 2.8f, UnityEngine.Random.Range(-19.8f, 19.8f));

            
            for (int i = 0; i < spawnPoints.Count; i++)
            {
                if (spawnPoints[i] == enemyPosition)
                {
                    spawnExists = true;
                }
                
            }

            if (!spawnExists)
            {
                spawnPoints.Add(enemyPosition);
                Instantiate(EnemyPrefab, enemyPosition, transform.localRotation * Quaternion.Euler(0f, 90f, 0f));
            }
            else SpawnRandomEnemy();

            spawnExists = false;
        }
    }
}
