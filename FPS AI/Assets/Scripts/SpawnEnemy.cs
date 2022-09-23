using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject EnemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnRandomEnemy()
    {
        Vector3 enemyPosition = new Vector3(Random.Range(-5.3f, 21.2f), 2.8f, Random.Range(-19.8f, 19.8f));
        Instantiate(EnemyPrefab, enemyPosition, transform.rotation * Quaternion.Euler(0f, 90f, 0f));
    }
}
