using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public float floatStrength = 0.1f; // Si³a ruchu góra-dó³
    public float rotationAmount = 5f; // Delikatne przechylanie

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Delikatny ruch góra-dó³
        float newY = startPosition.y + Mathf.Sin(Time.time * 2) * floatStrength;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // Lekka rotacja statku, by wygl¹da³o, ¿e leci
        float rotationZ = Mathf.Sin(Time.time * 2) * rotationAmount;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
    }
}
