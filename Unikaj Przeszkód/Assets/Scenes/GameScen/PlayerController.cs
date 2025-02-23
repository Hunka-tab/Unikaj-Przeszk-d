using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // === Ruch miêdzy pasami ===
    public float laneDistance = 2f;  // Odleg³oœæ miêdzy pasami
    private int currentLane = 1;     // 0 = lewo, 1 = œrodek, 2 = prawo

    // === Animacja (unoszenie i przechylanie) ===
    public float floatStrength = 0.1f;   // Si³a unoszenia
    public float rotationAmount = 5f;    // Si³a przechy³u
    private Vector3 startPosition;

    // === Kolizje i power-up ===
    private bool isInvincible = false;
    private Renderer playerRenderer;
    private Color originalColor;

    void Start()
    {
        startPosition = transform.position;
        playerRenderer = GetComponent<Renderer>();
        if (playerRenderer != null)
        {
            originalColor = playerRenderer.material.color;
        }
    }

    void Update()
    {
        HandleInput();
        AnimatePlayer();
    }

    // Obs³uga sterowania miêdzy pasami
    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentLane > 0)
            {
                currentLane--;
                MovePlayer();
            }
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentLane < 2)
            {
                currentLane++;
                MovePlayer();
            }
        }
    }

    void MovePlayer()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = (currentLane - 1) * laneDistance;
        transform.position = newPosition;
    }

    // Animacja unoszenia i przechylania
    void AnimatePlayer()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * 2) * floatStrength;
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x, newY, pos.z);

        float rotationZ = Mathf.Sin(Time.time * 2) * rotationAmount;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
    }

    // Wykrywanie kolizji (dla asteroid oraz power-upów)
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Asteroid"))
        {
            // Jeœli gracz nie jest nietykalny, zakoñcz grê
            if (!isInvincible)
            {
                Debug.Log("Game Over!");
                Time.timeScale = 0;
            }
        }
        else if (other.CompareTag("PowerUp"))
        {
            StartCoroutine(ActivateInvincibility());
            Destroy(other.gameObject);
        }
    }

    // Publiczna metoda, by inne skrypty mog³y sprawdziæ, czy gracz jest invincible
    public bool IsInvincible()
    {
        return isInvincible;
    }

    // Aktywacja power-upa (nietykalnoœæ na 3 sekundy)
    IEnumerator ActivateInvincibility()
    {
        isInvincible = true;
        Debug.Log("Power-up activated!");
        SetTransparency(0.5f);

        yield return new WaitForSeconds(3);

        isInvincible = false;
        Debug.Log("Power-up ended.");
        SetTransparency(1f);
    }

    void SetTransparency(float alpha)
    {
        if (playerRenderer != null)
        {
            Color newColor = originalColor;
            newColor.a = alpha;
            playerRenderer.material.color = newColor;
        }
    }
}
