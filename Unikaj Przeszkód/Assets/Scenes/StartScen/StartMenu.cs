using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public AudioSource clickSound; // DŸwiêk klikniêcia (opcjonalnie)

    public void StartGame()
    {
        if (clickSound != null)
        {
            clickSound.PlayOneShot(clickSound.clip); // Odtwarza dŸwiêk klikniêcia
        }

        SceneManager.LoadScene("gamescene"); // Wczytuje scenê gry
    }
}
