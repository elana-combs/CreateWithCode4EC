using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemyPrefab;
    public GameObject powerupPrefab;

    private float spawnRange = 9.0f; // the range of the map is -9 to 9 on the x and z axises, so we can have a default float to fill in the ranges.

    public int enemyCount;
    public int waveNumber = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnPowerup();

    }

    private void Update()
    {
        enemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length; //finds and tracks all objects in the scene with the Enemy tag.
        if (enemyCount == 0)
        {
            waveNumber++; // increases wave number by 1 whenever there are 0 enemies remaining
            SpawnEnemyWave(waveNumber);
            SpawnPowerup();
        }
    }
    void SpawnPowerup()
    {
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++) // spawns 3 enemies
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition()/*calls the return of  the function, randomPos*/, enemyPrefab.transform.rotation); //the Enemy prefab can spawn anywhere within the functional mapspace.
        }
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
