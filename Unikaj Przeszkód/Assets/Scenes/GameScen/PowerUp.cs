using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float speed = 5f; // Pr�dko�� poruszania si� power-upa
    public float floatStrength = 0.5f; // Si�a ruchu g�ra-d�
    public float rotationSpeed = 50f; // Szybko�� obrotu

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Power-up porusza si� w stron� gracza (w d� ekranu)
        transform.position += Vector3.back * speed * Time.deltaTime;

        // Oscylacyjny ruch g�ra-d�
        float newY = startPosition.y + Mathf.Sin(Time.time * 2) * floatStrength;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // Obr�t wok� w�asnej osi
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
