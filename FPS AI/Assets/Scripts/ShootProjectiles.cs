using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;

public class ShootProjectiles : MonoBehaviour
{
    public Camera fpsCam;
    public Transform attackPoint;
    public GameObject projectile;

    public float shootForce = 50f;
    public float fireRate = 1f;
    bool readyToShoot = true;

    public float reward = 0f;
    void Start()
    {
        
    }

    void Update()
    {

        bool leftMouseClick = Input.GetMouseButtonDown(0);

        if (leftMouseClick && readyToShoot)
        {
            GameObject bullet = Instantiate(projectile, attackPoint.position, Quaternion.identity);
            Vector3 direction = attackPoint.position - fpsCam.transform.position;
            direction.y += 0.5f;
            bullet.GetComponent<Rigidbody>().AddForce(direction.normalized * shootForce, ForceMode.Impulse);
            readyToShoot = false;
            Invoke("ResetReadyToShoot", fireRate);
        }

    }
    void ResetReadyToShoot()
    {
        readyToShoot = true;
    }
    
    public void SetReward(float reward)
    {
        this.reward += reward;
    }
}
