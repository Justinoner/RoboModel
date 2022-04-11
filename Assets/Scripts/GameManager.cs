using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This class represents the game! SO everything that is in the game will be accessable through here.
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public MenuManager menuManager;
    public UICanvas mainGameCanvas;
    public float secondsRemaining;
    public float roundTimeInSeconds;

    [Header("Game Prefabs")]
    public UICanvas UIPrefab;

    private void Awake()
    {
        // if i am the first!
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //There is already a game manager, so destroy myself
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //Main menu
        //start countdown
        secondsRemaining = roundTimeInSeconds;
        
    }

    public void StartGame()
    {
        //load gameplay scene
        SceneManager.LoadScene("UIMainLevel");
        //Set score to zero
        //Spawn player
        //turn on the enemy spawners
        //instantiate UI
        mainGameCanvas = Instantiate(UIPrefab) as UICanvas;

    }
    public void LoadMainMenu()
    {
        //load main menu
        SceneManager.LoadScene("UITestScene");
    }

    //endgame runs when the player is out of lives
    public void EndGame()
    {
        //send a command to stop the controller from controlling the player
        //show GameOver overlay
    }

    // Update is called once per frame
    void Update()
    {
        //mainGameCanvas.UpdateCountdownTimer(secondsRemaining);
    }
}
