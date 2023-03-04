using UnityEngine;

public class Director : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int maxEnemies = 10;
    public float spawnDelay = 2f;
    public float spawnRadius = 5f;
    public Vector2 spawnArea = new Vector2(10f, 10f);

    private int currentEnemies = 0;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnDelay, spawnDelay);
    }

    private void SpawnEnemy()
    {
        if (currentEnemies >= maxEnemies)
        {
            return;
        }

        Vector2 spawnPosition = GetRandomSpawnPosition();
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        currentEnemies++;
    }

    private Vector2 GetRandomSpawnPosition()
    {
        float x = Random.Range(-spawnArea.x / 2f, spawnArea.x / 2f);
        float y = Random.Range(-spawnArea.y / 2f, spawnArea.y / 2f);
        Vector2 spawnPosition = new Vector2(x, y);

        return spawnPosition;
    }
}
