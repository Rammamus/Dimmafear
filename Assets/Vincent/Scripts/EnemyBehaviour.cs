using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float speed = 5f; // Enemy speed
    public float stoppingDistance = 1f; // Distance to stop from player
    public Transform target; // Player transform

    private void Update()
    {
        if (target == null)
        {
            // If target is null, find the player game object
            target = GameObject.FindGameObjectWithTag("Player").transform;
            return;
        }

        // Calculate the distance between enemy and player
        float distanceToTarget = Vector2.Distance(transform.position, target.position);

        if (distanceToTarget > stoppingDistance)
        {
            // Move towards the player
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}