using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed = 7f;           // Prêdkoœæ asteroid
    public float rotationSpeed = 100f;   // Szybkoœæ obrotu
    private ScoreManager scoreManager;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager not found in scene!");
        }
    }

    void Update()
    {
        // Poruszamy asteroid¹ w kierunku gracza (w dó³ osi Z)
        transform.position += Vector3.back * speed * Time.deltaTime;
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        // Gdy asteroida przeleci poza ekran (np. Z < -10), dodaj punkt i zniszcz asteroidê
        if (transform.position.z < -10)
        {
            if (scoreManager != null)
            {
                scoreManager.AddPoint();
            }
            Destroy(gameObject);
        }
    }

    // Wykrywanie kolizji z graczem
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Pobierz komponent gracza i sprawdŸ, czy jest invincible
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null && playerController.IsInvincible())
            {
                // Jeœli gracz jest nietykalny, ignoruj kolizjê
                return;
            }
            Debug.Log("Game Over!");
            Time.timeScale = 0;
        }
    }
}
