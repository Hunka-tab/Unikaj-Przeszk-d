using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float speed = 5f; // Prêdkoœæ poruszania siê power-upa
    public float floatStrength = 0.5f; // Si³a ruchu góra-dó³
    public float rotationSpeed = 50f; // Szybkoœæ obrotu

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Power-up porusza siê w stronê gracza (w dó³ ekranu)
        transform.position += Vector3.back * speed * Time.deltaTime;

        // Oscylacyjny ruch góra-dó³
        float newY = startPosition.y + Mathf.Sin(Time.time * 2) * floatStrength;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // Obrót wokó³ w³asnej osi
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
