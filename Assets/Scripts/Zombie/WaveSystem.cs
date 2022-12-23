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

    public GameObject finishBarrier;

    private bool entered;
    private int wavesSpawned;
    private bool completed;

    public Transform setSpawn;
    public int zombieNumber;
    public int waveNumber;

    void Start() {
        entered = false;
        completed = false;
        wavesSpawned = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (entered && !completed) {


            GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie");
            int numZombies = zombies.Length;

            if (numZombies == 0)
            {
                if (wavesSpawned >= waveNumber)
                {
                completed = true;
                completeArea();
                return;
                }

                for (int i = 0; i < zombieNumber; i++)
                {
                Vector3 spawnPosition;
                float x, y;

                if (!setSpawn)
                {
                    x = Random.Range(leftWall.position.x + 2, rightWall.position.x - 2);
                    y = Random.Range(bottomWall.position.y + 2, rightWall.position.y - 2);
                }
                else
                {
                    x = Random.Range(setSpawn.position.x - 2, setSpawn.position.x + 2);
                    y = Random.Range(setSpawn.position.y - 2, setSpawn.position.y + 2);
                }

                spawnPosition = new Vector3(x, y, 0);
                GameObject zombie = Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);

                zombie.tag = "Zombie";
                zombie.GetComponent<NavMeshAgent>().enabled = true;
                zombie.GetComponent<ZombieController>().player = playerLocation;
                }

                wavesSpawned += 1;
            }
        }

    }

    public void isEntered() {
        entered = true;
    }

    private void completeArea() {
        Destroy(finishBarrier);
    }
}
