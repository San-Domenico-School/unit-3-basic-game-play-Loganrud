using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***************************************
 * Component of Spawn Manager, spawns animals into the scene but out of view.
 * 
 * Logan Rudsenske
 * October 17, 2023 version 1.0
 **************************************/

public class SpawnManager : MonoBehaviour
{
    private float spawnRange = 24f;                    // distance to edge from center of field
    private float startDelay = 2.0f;             // time before first spawn
    private float spawnInterval = 1.5f;          // interval between spawns
    [SerializeField] GameObject[] animals;       // list of animals to spawn

    // Calls the SpawnRandomAnimal method after a certain delay, then every interval
    private void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Adds a random animal at a random point between the spawn ranges
    private void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animals.Length);
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnRange, spawnRange), 0.0f, 25.0f);
        GameObject animal = animals[animalIndex];

        Instantiate(animal, spawnPosition, animal.transform.rotation);

    }
}
