using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public AudioSource clickSound; // D�wi�k klikni�cia

    public void StartGame()
    {
        clickSound.Play(); // Odtwarza d�wi�k klikni�cia
        SceneManager.LoadScene("MainGame"); // Wczytuje scen� gry
    }
}

