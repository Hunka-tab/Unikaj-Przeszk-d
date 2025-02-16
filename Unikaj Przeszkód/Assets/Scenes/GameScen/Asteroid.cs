using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed = 7f; // Pr�dko�� spadania
    public float rotationSpeed = 100f; // Szybko�� obrotu

    void Update()
    {
        // Asteroida leci w stron� gracza
        transform.position += Vector3.back * speed * Time.deltaTime;

        // Obr�t wok� w�asnej osi
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}

