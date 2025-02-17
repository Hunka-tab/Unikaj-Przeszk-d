using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public AudioSource clickSound; // DŸwiêk klikniêcia

    public void StartGame()
    {
        clickSound.Play(); // Odtwarza dŸwiêk klikniêcia
        SceneManager.LoadScene("MainGame"); // Wczytuje scenê gry
    }
}

