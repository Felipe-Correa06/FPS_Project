using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public AgentAI agentAI;
    public SpawnEnemy spawnEnemy;
    //public ShootProjectiles sProjectiles;
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
        if (collision.gameObject.name.Contains("Enemy"))
        {
            Debug.Log("hit enemy");
            spawnEnemy.SpawnRandomEnemy();
            Destroy(collision.collider.gameObject);
            Destroy(gameObject);
            agentAI.AddReward(+1f);
            //agentAI.EndEpisode();
            
        }
        else
        {
            Debug.Log("hit wall or floor");
            Destroy(gameObject);
            agentAI.AddReward(-5F);
            //agentAI.EndEpisode();
        }
    }
}
