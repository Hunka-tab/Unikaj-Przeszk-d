using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public AudioSource clickSound; // D�wi�k klikni�cia (opcjonalnie)

    public void StartGame()
    {
        if (clickSound != null)
        {
            clickSound.PlayOneShot(clickSound.clip); // Odtwarza d�wi�k klikni�cia
        }

        SceneManager.LoadScene("gamescene"); // Wczytuje scen� gry
    }
}
