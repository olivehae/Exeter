using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
  // The damage dealt by the bullet
  public int damage = 1;

  // The speed of the bullet
  public float speed = 4.5f;

  // The lifetime of the bullet
  public float lifetime = 5.0f;

  void Start() {
    Destroy(gameObject, lifetime);
  }

    // Update is called once per frame
  private void Update()
  {
    transform.position += transform.right * speed * Time.deltaTime;
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    // If the bullet hits a zombie, deal damage to the zombie and destroy the bullet
    if (other.CompareTag("Zombie"))
    {

      other.GetComponent<ZombieController>().TakeDamage(damage);
      Destroy(gameObject);

    } else if (other.CompareTag("Wall")) {

      Destroy(gameObject);

    } else if (other.CompareTag("Barrel")) {

      other.GetComponent<BarrelController>().Explode();

      Destroy(other.gameObject);
      Destroy(gameObject);

    }
  }
}