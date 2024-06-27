using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

  public float movementSpeed = 10.0f;
    public float jumpForce = 10.0f;
    public float gravity = -9.81f;

    private CharacterController controller;
    private bool isGrounded;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(-horizontalInput, 0, 0); // Only consider horizontal movement
        velocity.x = direction.x * movementSpeed;

        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Set a minimal downward force when grounded
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = jumpForce;
        }

        velocity.y += gravity * Time.deltaTime;

        // Set Z velocity to 0 to avoid movement on the Z-axis
        velocity.z = 0; 

        controller.Move(velocity * Time.deltaTime);
    }
}
