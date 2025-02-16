using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float laneDistance = 2f; // Odleg³oœæ miêdzy pasami
    private int currentLane = 1; // 0 = lewo, 1 = œrodek, 2 = prawo

    void Update()
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
}
