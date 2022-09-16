using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public AgentAI agentAI;
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
            Debug.Log("hit");
            //sProjectiles.SetReward(5f);
            agentAI.AddReward(+5f);
            agentAI.EndEpisode();
        }
        else
        {
            agentAI.AddReward(-5F);
            //agentAI.EndEpisode();
        }
    }
}
