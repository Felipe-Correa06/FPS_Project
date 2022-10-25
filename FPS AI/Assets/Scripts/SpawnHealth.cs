using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class SpawnHealth : MonoBehaviour
{
    public GameObject HealthPrefab;

    public GameObject wall;
    public GameObject wall1;
    public GameObject wall2;
    public GameObject wall3;

    public int count;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void SpawnRandomHealth()
    {
        //Vector3 enemyPosition = new Vector3(UnityEngine.Random.Range(-5.3f, 21.2f), 2.8f, UnityEngine.Random.Range(-19.8f, 19.8f));
        Vector3 healthPosition = new Vector3(UnityEngine.Random.Range(wall1.transform.position.x - 2, wall.transform.position.x + 1), 2.38f, UnityEngine.Random.Range(wall3.transform.position.z + 1, wall2.transform.position.z - 1));
        Instantiate(HealthPrefab, healthPosition, transform.localRotation * Quaternion.Euler(0f, 90f, 0f));

    }
}
