using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public int numberOfEnemies = 5; //# of enemies to spawn

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            // Generate random position between -24 and 24 on both the x and z axes
            float xPosition = Random.Range(-20f, 20f);
            float zPosition = Random.Range(-20f, 20f);

            // Create a random position vector in 3D (x, y, z)
            Vector3 spawnPosition = new Vector3(xPosition, 1.0f, zPosition);  // y = 1 to keep enemies on the ground

            // Randomly choose an enemy prefab from the array
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

            // Instantiate the chosen enemy prefab at the generated position
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
