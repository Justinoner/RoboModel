using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public Button retryButton;
    public Button titleButton;
    public Button quitButton;

    private void Start()
    {
        retryButton.onClick.AddListener(Retry);
        titleButton.onClick.AddListener(Title);
        quitButton.onClick.AddListener(Quit);
    }

    public void Retry()
    {
        GameManager.instance.lives = 3;
        SceneManager.LoadScene(1);
    }

    public void Title()
    {
        GameManager.instance.lives = 3;

        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
