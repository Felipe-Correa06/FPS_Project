using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public CharacterController characterController;

    public float speed = 10f;
    public float gravity = -9.81f;

    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        
        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        //transform.position += (transform.right * x + transform.forward * z) * Time.deltaTime * speed;

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Wall"))
        {
            //Debug.Log("Player Hit wall");
        }
        else if (other.gameObject.name.Contains("Enemy"))
        {
            //Debug.Log("Player Hit enemy");
        }
    }
}
