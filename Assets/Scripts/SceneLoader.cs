using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("GameScreen");
    }

    public void Quit() {
        Application.Quit();
    }
}