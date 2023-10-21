using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatMovement : MonoBehaviour
{    
    public Transform[] players;          // Reference to player transforms
    public float moveSpeed = 2.0f;      // Speed of movement

    private Transform closestPlayer;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Find the closest player
        closestPlayer = GetClosestPlayer();

        if (closestPlayer != null)
        {
            // Calculate the direction to the closest player
            Vector3 moveDirection = closestPlayer.position - transform.position;
            moveDirection.Normalize();

            // Move towards the closest player's position
            rb.velocity = moveDirection * moveSpeed;

            // Rotate to face the closest player's position
            Quaternion newRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = newRotation;
        }
        else
        {
            // Stop moving if there are no players
            rb.velocity = Vector3.zero;
        }
    }

    private Transform GetClosestPlayer()
    {
        Transform closest = null;
        float closestDistance = float.MaxValue;

        foreach (Transform player in players)
        {
            float distance = Vector3.Distance(transform.position, player.position);
            if (distance < closestDistance)
            {
                closest = player;
                closestDistance = distance;
            }
        }

        return closest;
    }
}
