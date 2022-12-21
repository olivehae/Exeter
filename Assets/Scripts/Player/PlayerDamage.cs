using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public GameObject player;

  void OnTriggerEnter2D(Collider2D other)
  {
    // If the player collides with a zombie, reduce their health
    if (other.CompareTag("Zombie"))
    {
        player.GetComponent<PlayerController>().TakeDamage(1);

    }
  }
}
