using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cachorro : MonoBehaviour
{
   public Transform player; // Assign the player transform in the Inspector
    public float moveSpeed;
    public float jumpForce;
    public LayerMask obstacleLayer; // Layer containing obstacles

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (player == null)
        {
            return; // Prevent errors if player not assigned
        }

        // Calculate direction towards player on X and Y axes
        Vector3 direction = new Vector3(player.position.z - transform.position.z, 0f, player.position.y - transform.position.y);
        direction.Normalize();

        // Move towards player
        transform.Translate(direction * moveSpeed * Time.deltaTime);

        // Raycast for obstacles below
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up, Vector3.down, out hit, Mathf.Infinity, obstacleLayer))
        {
            // Jump if obstacle detected
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

}
