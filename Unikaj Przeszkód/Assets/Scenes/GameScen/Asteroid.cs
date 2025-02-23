using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed = 7f;           // Pr�dko�� asteroid
    public float rotationSpeed = 100f;   // Szybko�� obrotu
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
        // Poruszamy asteroid� w kierunku gracza (w d� osi Z)
        transform.position += Vector3.back * speed * Time.deltaTime;
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        // Gdy asteroida przeleci poza ekran (np. Z < -10), dodaj punkt i zniszcz asteroid�
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
            // Pobierz komponent gracza i sprawd�, czy jest invincible
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null && playerController.IsInvincible())
            {
                // Je�li gracz jest nietykalny, ignoruj kolizj�
                return;
            }
            Debug.Log("Game Over!");
            Time.timeScale = 0;
        }
    }
}
