using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ControlLevelOne : MonoBehaviour
{
    public GameObject pauseMain;
    

    public void pausePlay()
    {
        pauseMain.SetActive(true);
        Time.timeScale = 0;
    }

    public void Play()
    {
        pauseMain.SetActive(false);
        Time.timeScale = 1;
    }

    public void Resect()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void main()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
