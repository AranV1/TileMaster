using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] AudioSource buttonClickSFX;

    public void PlayGame()
    {
        buttonClickSFX.Play();
        SceneManager.LoadScene("Level 1");
    }
}