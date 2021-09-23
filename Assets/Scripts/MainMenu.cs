using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   
    public void EscenaJuego()
    {
        SceneManager.LoadScene("level1");
    }

    public void OptionsPlay()
    {
        SceneManager.LoadScene("Options");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
