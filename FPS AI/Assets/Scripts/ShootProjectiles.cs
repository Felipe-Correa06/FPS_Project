using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectiles : MonoBehaviour
{
    public Camera fpsCam;
    public Transform attackPoint;
    public GameObject projectile;

    float shootForce = 50f;

    void Start()
    {
        
    }

    void Update()
    {

        bool clickInput = Input.GetMouseButtonDown(0);

        if (clickInput)
        {
            GameObject bullet = Instantiate(projectile, attackPoint.position, Quaternion.identity);
            Vector3 direction = attackPoint.position - fpsCam.transform.position;
            direction.y = 0.02f;
            bullet.GetComponent<Rigidbody>().AddForce(direction.normalized * shootForce, ForceMode.Impulse);
        }

    }

}
