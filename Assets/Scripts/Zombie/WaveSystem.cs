using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaveSystem : MonoBehaviour
{
    public GameObject zombiePrefab;
    public Transform playerLocation;

    public int waveAmount;
  // Start is called before the first frame update

    private NavMeshTriangulation triangulation;
    void Start()
    {
        triangulation = NavMesh.CalculateTriangulation();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie");
        int numZombies = zombies.Length;

        if (numZombies == 0)
        {
            for (int i = 0; i < waveAmount; i++)
            {
                Vector3 spawnPosition = new Vector3(playerLocation.position.x + Random.Range(-10, 10), 0, playerLocation.position.x + Random.Range(-10, 10));
                GameObject zombie = Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);
                zombie.tag = "Zombie";
                
                int vertex = Random.Range(0, triangulation.vertices.Length);
                NavMeshHit Hit;
                if (NavMesh.SamplePosition(triangulation.vertices[vertex], out Hit, 2f, 1)){
                    zombie.GetComponent<NavMeshAgent>().Warp(Hit.position);
                    zombie.GetComponent<NavMeshAgent>().enabled = true;
                    zombie.GetComponent<ZombieController>().player = playerLocation;
                }
            }
        }
    }
}
