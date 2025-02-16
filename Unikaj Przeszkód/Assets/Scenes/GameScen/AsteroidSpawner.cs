using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public Transform spawnPoint;
    public float spawnInterval = 2f;
    public float asteroidSpeed = 5f;

    private float timer = 0f;
    private float[] lanes = { -2f, 0f, 2f };

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnAsteroid();
            timer = 0f;
        }
    }

    void SpawnAsteroid()
    {
        int laneIndex = Random.Range(0, lanes.Length);
        Vector3 spawnPos = new Vector3(lanes[laneIndex], 0.5f, 10f);
        GameObject asteroid = Instantiate(asteroidPrefab, spawnPos, Quaternion.identity);
        asteroid.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -asteroidSpeed);
        Destroy(asteroid, 7f); // Usuwa asteroidê po 7 sekundach
    }
}
