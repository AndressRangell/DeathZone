using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CartoonOne : MonoBehaviour
{
    public void NextLevelOne()
    {
        SceneManager.LoadScene("Level1");
    }
}
