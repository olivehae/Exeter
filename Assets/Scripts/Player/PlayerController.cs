using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // The player's maximum health
    public int maxHealth = 100;

    // The player's current health
    private int health;

    // Movement speed of the player
    public float speed = 5.0f;

    // Reference to the player's Rigidbody2D component
    private Rigidbody2D rb;

    // Reference to the player's shooting script
    private ShootingController shooting;

    private Collider2D playerCollider;
  void Start()
    {
        health = maxHealth;

        // Get references to the Rigidbody2D, Animator, and Shooting components
        rb = GetComponent<Rigidbody2D>();
        shooting = GetComponent<ShootingController>();
    }

    void Update()
    {
        // Get input from the horizontal and vertical axes
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Set the player's movement direction based on the input
        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        rb.velocity = movement * speed;
        // rb.MovePosition(movement * speed);

        // Rotate the Player to face the mouse cursor.
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // If the player is shooting, shoot and set the "Shooting" animation parameter to true
        if (Input.GetButtonDown("Fire1"))
        {
            shooting.Shoot();
            // anim.SetBool("Shooting", true);
        }
    }

    public void TakeDamage(int damage)
    {
        // Reduce the player's health by the specified amount
        health -= damage;

        // If the player's health is zero or less, end the game
        if (health <= 0)
        {
            Debug.Log("Game Over!");
        }
    }
}