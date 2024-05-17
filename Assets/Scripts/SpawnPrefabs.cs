using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefabs : MonoBehaviour
{
    private float currentSpawnDelay; // Tracks current spawn delay

    public GameObject[] prefabsToSpawn = new GameObject[14]; // Array for 14 prefabs
    public Transform spawnPoint; // Transform for spawn location
    public float baseSpawnDelay = 2.0f; // Initial delay between spawns
    public float spawnDelayDecrease = 0.1f; // Decrease in delay per second
    public float spawnXRange = 22.0f; // Range for randomizing Z position

    // Start is called before the first frame update
    void Start()
    {
        // Check if all prefab slots are filled
        if (prefabsToSpawn.Length != 14 )
        {
            Debug.LogError("Please assign 14 prefabs to the slots in the Inspector!");
            return;
        }

        currentSpawnDelay = baseSpawnDelay; //set spawn delay
        StartCoroutine(SpawnWithDelay());
    }
    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnWithDelay()
    {
        int randomIndex = Random.Range(0, prefabsToSpawn.Length); // Get random index
        Vector3 spawnPosition = spawnPoint.position; // Use spawnPoint transform

        // Randomize X position within spawnZRange
        spawnPosition.x += Random.Range(-spawnXRange / 2f, spawnXRange / 2f);

        // Spawn the randomly chosen prefab
        Instantiate(prefabsToSpawn[randomIndex],spawnPosition, Quaternion.identity);

        // Update spawn delay based on playtime
        currentSpawnDelay = Mathf.Max(baseSpawnDelay, currentSpawnDelay - Time.deltaTime * spawnDelayDecrease); // Ensure minimum delay

        // Wait for the delay before spawning again
        yield return new WaitForSeconds(currentSpawnDelay);

        // Call itself recursively to continue spawning
        StartCoroutine(SpawnWithDelay());
    }

}
