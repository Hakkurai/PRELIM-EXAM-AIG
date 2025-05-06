using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAIFollow : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    public float detectionRange = 10f;
    public float rotationSpeed = 5f;
    public float damageCooldown = 3f;

    private float lastDamageTime = -Mathf.Infinity;

    private void Update()
    {
        if (player == null) return;

        Vector3 directionToPlayer = player.position - transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;

        if (distanceToPlayer <= detectionRange)
        {
            Ray ray = new Ray(transform.position, directionToPlayer.normalized);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, detectionRange, ~0))
            {
                if (hit.transform == player)
                {
                    Vector3 lookDirection = directionToPlayer.normalized;
                    lookDirection.y = 0;
                    Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

                    transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
{
    if (collision.transform == player)
    {
        if (Time.time - lastDamageTime >= damageCooldown)
        {
            PlayerHealth health = player.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.TakeDamage(1);
                lastDamageTime = Time.time;

                // Knockback
                Rigidbody playerRb = player.GetComponent<Rigidbody>();
                if (playerRb != null)
                {
                    Vector3 knockbackDir = (player.position - transform.position).normalized;
                    knockbackDir.y = 0; // Prevent vertical launch
                    playerRb.AddForce(knockbackDir * 5f, ForceMode.Impulse); // Adjust force as needed
                }
            }
        }
    }
}

}
