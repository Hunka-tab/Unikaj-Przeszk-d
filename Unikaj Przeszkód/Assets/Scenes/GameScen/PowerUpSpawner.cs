using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject powerUpPrefab;
    public float spawnInterval = 10f;
    private float timer = 0f;
    private float[] lanes = { -2f, 0f, 2f };

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnPowerUp();
            timer = 0f;
        }
    }

    void SpawnPowerUp()
    {
        int laneIndex = Random.Range(0, lanes.Length);
        Vector3 spawnPos = new Vector3(lanes[laneIndex], 0.4f, 10f);
        Instantiate(powerUpPrefab, spawnPos, Quaternion.identity);
    }
}
