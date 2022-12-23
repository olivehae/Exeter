using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaveSystem : MonoBehaviour
{
    public GameObject zombiePrefab;
    public Transform playerLocation;

    public Transform topWall;
    public Transform leftWall;
    public Transform rightWall;
    public Transform bottomWall;
    public Transform setSpawn;
    public int waveAmount;

    void Start() {}

    // Update is called once per frame
    void Update()
    {
        GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie");
        int numZombies = zombies.Length;

        if (numZombies == 0)
        {
            for (int i = 0; i < waveAmount; i++)
            {
                Vector3 spawnPosition;
                float x, y;

                if (!setSpawn) {
                    x = Random.Range(leftWall.position.x, rightWall.position.x);
                    y = Random.Range(bottomWall.position.y, rightWall.position.y);
                } else {
                    x = Random.Range(setSpawn.position.x - 2, setSpawn.position.x + 2);
                    y = Random.Range(setSpawn.position.y - 2, setSpawn.position.y + 2);
                }

                spawnPosition = new Vector3(x, y, 0);
                GameObject zombie = Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);

                zombie.tag = "Zombie";
                zombie.GetComponent<NavMeshAgent>().enabled = true;
                zombie.GetComponent<ZombieController>().player = playerLocation;
            }
        }
    }
}
