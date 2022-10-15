using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using Unity.VisualScripting;

public class AgentAI : Agent
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
    public float shootForce = 50f;
    public int fire = 0;
    public float fireRate = 5f;
    bool readyToShoot = true;

    //episode begin
    public float timer = 0f;
    Vector3 initialPosition = new Vector3(-8.7f, 1.168f, -0.3f);
    public override void OnEpisodeBegin()
    {
        Debug.Log("Episode started");
        timer = 0f;
        transform.position = initialPosition;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
    }

    //-----------------------Action Space---------------------------
    public override void OnActionReceived(ActionBuffers actions)
    {
        
        //Movement Actions
        float moveX = actions.ContinuousActions[0];
        float moveZ = actions.ContinuousActions[1];
        float mouseX = actions.ContinuousActions[2];
        //float mouseY = actions.ContinuousActions[3];
        /*Debug.Log("MoveX: " + moveX);
        //Debug.Log("\nMoveZ: " + moveZ);
        //Debug.Log("\nMouseX: " + mouseX);
         Debug.Log("\nMouseY: " + mouseY);*/

        //Shoot Action
        fire = actions.DiscreteActions[0];
        //Debug.Log("\nFire: " + fire);

        //Character Movement
        /*Vector3 move = transform.right * moveX + transform.forward * moveZ;
        characterController.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);*/

        //Character Movement
        transform.position += (transform.right * moveX + transform.forward * moveZ) * Time.deltaTime * speed;

        //Mouse Movement
        //xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        cameraT.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);


    }

    private void Update()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);
        if(timer >= 400f)
        {
            AddReward(-5f);
        }

        transform.position = new Vector3(transform.position.x, 1f, transform.position.z);

        if (fire==1 && readyToShoot)
        {
            GameObject bullet = Instantiate(projectile, attackPoint.position, Quaternion.Euler(0f, 0f, 0f));
            Vector3 direction = attackPoint.position - fpsCam.transform.position;
            direction.y += 0.35f;
            bullet.GetComponent<Rigidbody>().AddForce(direction.normalized * shootForce, ForceMode.Impulse);
            readyToShoot = false;
            Invoke("ResetReadyToShoot", fireRate);
        }

    }

    void ResetReadyToShoot()
    {
        readyToShoot = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Wall"))
        {
            Debug.Log("Player Hit wall");
            AddReward(-5f);
            EndEpisode();   
        }
        else if (other.gameObject.name.Contains("Enemy"))
        {
            Debug.Log("Player Hit enemy");
            AddReward(-5f);
            EndEpisode();
        }
    }
}
