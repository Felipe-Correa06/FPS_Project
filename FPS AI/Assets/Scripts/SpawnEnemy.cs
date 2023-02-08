using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject EnemyPrefab;

    public GameObject wall;
    public GameObject wall1;
    public GameObject wall2;
    public GameObject wall3;

    public int count = 0;

    float distance = 30f;
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

        //Vector3 enemyPosition = new Vector3(UnityEngine.Random.Range(-5.3f, 21.2f), 2.8f, UnityEngine.Random.Range(-19.8f, 19.8f));
        Vector3 enemyPosition = new Vector3(UnityEngine.Random.Range(wall1.transform.position.x - distance, wall.transform.position.x + distance), 2.38f, UnityEngine.Random.Range(wall3.transform.position.z + distance, wall2.transform.position.z - distance));
        Instantiate(EnemyPrefab, enemyPosition, transform.localRotation * Quaternion.Euler(0f, 90f, 0f));
    }
}
