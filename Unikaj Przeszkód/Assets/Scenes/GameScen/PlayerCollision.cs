using System.Collections;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private bool isInvincible = false;
    private Renderer playerRenderer;
    private Color originalColor;

    void Start()
    {
        playerRenderer = GetComponent<Renderer>(); // Pobiera renderer statku
        originalColor = playerRenderer.material.color; // Zapamiętuje oryginalny kolor
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Asteroid") && !isInvincible)
        {
            Debug.Log("Game Over!");
            Time.timeScale = 0; // Pauza gry po kolizji
        }

        if (other.CompareTag("PowerUp"))
        {
            StartCoroutine(ActivateInvincibility());
            Destroy(other.gameObject);
        }
    }

    IEnumerator ActivateInvincibility()
    {
        isInvincible = true;
        Debug.Log("Power-up aktywowany!");

        // Ustawienie przezroczystości statku
        SetTransparency(0.5f);

        yield return new WaitForSeconds(5); // Czas trwania nietykalności

        isInvincible = false;
        Debug.Log("Power-up skończony.");

        // Powrót do normalnej nieprzezroczystości
        SetTransparency(1f);
    }

    void SetTransparency(float alpha)
    {
        Color newColor = originalColor;
        newColor.a = alpha;
        playerRenderer.material.color = newColor;
    }
}
