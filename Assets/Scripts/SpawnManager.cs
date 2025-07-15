using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemyPrefab;
    private float spawnRange = 9.0f; // the range of the map is -9 to 9 on the x and z axises, so we can have a default float to fill in the ranges.

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

        Instantiate(enemyPrefab, GenerateSpawnPosition()/*calls the return of  the function, randomPos*/, enemyPrefab.transform.rotation); //the Enemy prefab can spawn anywhere within the functional mapspace.
    }

    private Vector3 GenerateSpawnPosition()
    {
        // generates a random spawn position.

        float spawnPosX = Random.Range(-spawnRange, spawnRange); //the range of the map's x-axis
        float spawnPosZ = Random.Range(-spawnRange, spawnRange); //the range of the map's z-axis

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }
}
