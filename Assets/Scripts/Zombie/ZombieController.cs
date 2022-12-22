using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    // The maximum health of the zombie
    public int maxHealth = 1;

    // The current health of the zombie
    private int health;

    // The speed of the zombie
    public float speed = 5.0f;

    // The distance at which the zombie will start chasing the player
    public float chaseDistance = 10.0f;

    // The distance at which the zombie will stop chasing the player
    public float stopChaseDistance = 15.0f;

    // Reference to the player's transform
    public Transform player;

    // Reference to the zombie's Rigidbody2D component
    private Rigidbody2D rb;

    public HealthBar healthBar;

    NavMeshAgent agent;


  void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        // Get references to the Rigidbody2D and Animator components
        rb = GetComponent<Rigidbody2D>();

        // Set the zombie's health to its maximum value
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
    // WITH PATHFINDING

    float distance = Vector2.Distance(transform.position, player.position);

    if (distance < chaseDistance) {
      agent.SetDestination(new Vector3(player.position.x, player.position.y, transform.position.z));
    } else {
      agent.SetDestination(new Vector3(transform.position.x, transform.position.y, transform.position.z));
    }
    
    // WIHTHOUT PATHFINDING
    // Calculate the distance to the player
    // float distance = Vector2.Distance(transform.position, player.position);

    // If the distance to the player is less than the chase distance, chase the player             
    // if (distance < chaseDistance)
    //     {
    //         Set the zombie's movement direction towards the player
    //         Vector2 direction = player.position - transform.position;
    //         direction.Normalize();
    //         rb.velocity = direction * speed;

    //         Update the zombie's animation
    //         anim.SetFloat("MovementX", direction.x);
    //         anim.SetFloat("MovementY", direction.y);
    //         anim.SetBool("Walking", true);
    //     }
    //     // If the distance to the player is greater than the stop chase distance, stop chasing the player
    //     else if (distance > stopChaseDistance)
    //     {
    //         // Set the zombie's velocity to zero
    //         rb.velocity = Vector2.zero;

    //         // Update the zombie's animation
    //         // anim.SetBool("Walking", false);
    //     }
  }

    public void TakeDamage(int damage)
    {
        // Reduce the zombie's health by the specified amount
        health -= damage;
        healthBar.SetHealth(health);

        // If the zombie's health is zero or less, destroy it
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public int getHealth(){
        return health;
    }
}