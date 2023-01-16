using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Spawn the object again if it spawned colliding with a wall
public class DetectCollision : MonoBehaviour
{
    public SpawnEnemy spawnEnemy;
    public SpawnGuide spawnGuide;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.name.Contains("Floor") && collision.collider.name.Contains("Wall"))
        {
            if (gameObject.name.Contains("Enemy"))
            {
                Destroy(gameObject);
                spawnEnemy.SpawnRandomEnemy();
            }
            else if (gameObject.name.Contains("Guide"))
            {
                Destroy(gameObject);
                spawnGuide.SpawnRandomGuide();
            }
        }
        
    }
}
