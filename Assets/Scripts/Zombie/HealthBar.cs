using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{

    public Slider healthSlider;

    public void SetMaxHealth(int health) {
        healthSlider.maxValue = health;
        healthSlider.value = health;
    }

    public void SetHealth(int health) {
        healthSlider.value = health;
    }

  // public GameObject zombie;
  // // Start is called before the first frame update
  // void Start()
  // {
  //     transform.position = zombie.transform.position;        
  // }

  // Update is called once per frame
  // void Update()
  // {
  //     transform.position = zombie.transform.position;
  //     mSlider.value = zombie.GetComponent<ZombieController>().getHealth() / zombie.GetComponent<ZombieController>().maxHealth;
  // }
}
