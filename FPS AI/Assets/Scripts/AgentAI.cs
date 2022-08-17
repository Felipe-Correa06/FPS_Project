using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;


public class AgentAI :  Agent
{
    //Character Movement
    public CharacterController characterController;
    public float speed = 10f;
    public float gravity = -9.81f;
    Vector3 velocity;

    //Mouse Movement
    public float sensivity = 100f;
    float xRotation = 0f;
    public Transform cameraT;

    //Shoot Projectiles
    public Camera fpsCam;
    public Transform attackPoint;
    public GameObject projectile;
    public float shootForce = 60f;
    public int fire = 0;

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
    }

    //-----------------------Action Space---------------------------
    public override void OnActionReceived(ActionBuffers actions)
    {
        /*
        //Movement Actions
        float moveX = actions.ContinuousActions[0];
        float moveZ = actions.ContinuousActions[1];
        float mouseX = actions.ContinuousActions[2];
        float mouseY = actions.ContinuousActions[3];
        /*Debug.Log("MoveX: " + moveX);
        Debug.Log("\nMoveZ: " + moveZ);
        Debug.Log("\nMouseX: " + mouseX);
        Debug.Log("\nMouseY: " + mouseY);*/

        //Shoot Action
        fire = actions.DiscreteActions[0];

        //Character Movement
        /*Vector3 move = transform.right * moveX + transform.forward * moveZ;
        characterController.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        //Mouse Movement
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        cameraT.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);*/


    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, 1f, transform.position.z);

        if (fire==1)
        {
            GameObject bullet = Instantiate(projectile, attackPoint.position, Quaternion.identity);
            Vector3 direction = attackPoint.position - fpsCam.transform.position;
            direction.y += 0.5f;
            bullet.GetComponent<Rigidbody>().AddForce(direction.normalized * shootForce, ForceMode.Impulse);

        }
    }

}
