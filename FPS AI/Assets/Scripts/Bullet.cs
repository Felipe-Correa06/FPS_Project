using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public AgentAI agentAI;
    public SpawnEnemy spawnEnemy;
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
        if (collision.gameObject.name.Contains("Enemy") || collision.gameObject.tag.Contains("enemy"))
        {
            Debug.Log("Shot hit enemy");
            //spawnEnemy.SpawnRandomEnemy();
            agentAI.timer = 0f;
            agentAI.AddReward(+5f);
            Destroy(gameObject);

            if (collision.gameObject.name != "First Person Player") {
                Destroy(collision.collider.gameObject);
               
                spawnEnemy.count++;
                if (spawnEnemy.count == 12)
                {
                    agentAI.AddReward(+50f);
                    Debug.Log(spawnEnemy.count);
                    for (spawnEnemy.count = 12; spawnEnemy.count > 0; spawnEnemy.count--)
                    {
                        spawnEnemy.SpawnRandomEnemy();
                    }
                    spawnEnemy.count = 0;
                    agentAI.EndEpisode();
                }
            }

        }
        else if (collision.gameObject.name.Contains("Wall") || collision.gameObject.name.Contains("Floor") || collision.gameObject.name.Contains("Guide"))
        {
            Debug.Log("Shot hit wall or floor or guide");
            Destroy(gameObject);
            agentAI.AddReward(-15f);
        }
    }
}
