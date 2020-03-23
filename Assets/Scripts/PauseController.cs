using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public GameObject screen;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void Pause()
    {
        Time.timeScale = 0f;
        screen.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        screen.SetActive(false);

    }

    public void Quit()
    {
        Application.Quit();

    }
}
