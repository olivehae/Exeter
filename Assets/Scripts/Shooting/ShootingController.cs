using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
  // Reference to the player's bullet prefab
  public GameObject bulletPrefab;

  public GameObject player;

  // The rate at which the player can shoot
  public float fireRate = 0.0f;

  // The next time the player can shoot
  private float nextFire = 0.0f;

  // public void Update()
  // {
  //     // If the Fire1 button is pressed and it is time to shoot again, shoot a bullet

  // }

  public void Shoot()
  {
    if (Time.time > nextFire)
    {
      // Create a bullet at the player's position and rotation
      GameObject bullet = Instantiate(bulletPrefab, player.transform.position, player.transform.rotation);

 
      // Set the bullet's velocity based on the player's rotation
      // bullet.GetComponent<Rigidbody2D>().speed = transform.right * bulletSpeed;


      // Calculate the next time the player can shoot
      nextFire = Time.time + fireRate;
    }
  }
}