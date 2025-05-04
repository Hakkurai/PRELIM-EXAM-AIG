using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAIFollow : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    public float detectionRange = 10f;
    public LayerMask obstacleMask;

    void Update()
    {
        if (player == null) return;

        Vector3 directionToPlayer = player.position - transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;

        // Only detect if within range
        if (distanceToPlayer <= detectionRange)
        {
            // Perform raycast to check for obstacles
            Ray ray = new Ray(transform.position, directionToPlayer.normalized);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, detectionRange, ~0))
            {
                if (hit.transform == player)
                {
                    // No obstacles in the way, move toward player
                    transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                }
                else
                {
                    // Debugging: Uncomment to see what the AI is hitting
                    // Debug.Log("AI sees " + hit.transform.name + " instead of the player.");
                }
            }
        }
    }
}