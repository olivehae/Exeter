using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneToggle : MonoBehaviour
{
  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player"))
    {

      GetComponentInParent<WaveSystem>().isEntered();

    }
  }
}
