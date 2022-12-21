using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelController : MonoBehaviour
{
    public float blastRadius = 5.0f;
    public int damage = 10;

  public Transform player;

    public void Explode()
    {
        float distance = Vector2.Distance(transform.position, player.position);
        if (distance <= blastRadius) {
            player.GetComponent<PlayerController>().TakeDamage(damage);
        }

        GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie");
        foreach (GameObject zombie in zombies)
        {
            distance = Vector2.Distance(transform.position, zombie.transform.position);
            if (distance <= blastRadius) {
                zombie.GetComponent<ZombieController>().TakeDamage(damage);
            }
        }
    }
}
