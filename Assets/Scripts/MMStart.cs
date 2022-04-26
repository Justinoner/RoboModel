using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MMStart : MonoBehaviour
{
    public void StartLevel()
    {
        SceneManager.LoadScene("LevelOne");


    }

    public void ExitLvl()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
