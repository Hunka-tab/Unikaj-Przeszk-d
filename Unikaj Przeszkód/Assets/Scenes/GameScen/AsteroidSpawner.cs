using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float spawnInterval = 2f;
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
        // Ustaw asteroidê, aby pojawia³a siê na pocz¹tku lane (z = 20)
        Vector3 spawnPos = new Vector3(lanes[laneIndex], 0.5f, 20f);
        Instantiate(asteroidPrefab, spawnPos, Quaternion.identity);
    }
}
