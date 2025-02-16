using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed = 7f; // Prêdkoœæ spadania
    public float rotationSpeed = 100f; // Szybkoœæ obrotu

    void Update()
    {
        // Asteroida leci w stronê gracza
        transform.position += Vector3.back * speed * Time.deltaTime;

        // Obrót wokó³ w³asnej osi
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}

