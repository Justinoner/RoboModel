using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This class represents the game! SO everything that is in the game will be accessable through here.
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public UICanvas mainGameCanvas;
    public float secondsRemaining;
    public float roundTimeInSeconds;
    public Transform PlayerSpawn;
    public int lives;


    [Header("Game Prefabs")]
    public UICanvas UIPrefab;
    public PlayerController Player;
    public GameObject PlayerPrefab;

    [HideInInspector] public bool gameStart;

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
        
        //start countdown
        secondsRemaining = roundTimeInSeconds;

    }

    public void StartGame()
    {
        

    }
    public void LoadMainMenu()
    {
        //load main menu
        SceneManager.LoadScene("MainMenu");
    }

    
    

    public void HandlePersonKilled(GameObject killedObject)
    {
        if (killedObject == Player.gameObject && lives > 0)
        {
            lives--;
            SpawnPlayer();

            if (lives <= 0)
            {
                SceneManager.LoadScene(2);

            }
        }
    }

    public void SpawnPlayer()
    {
        //Spawns player at designated spawn point
        GameObject PlayerObject = Instantiate(PlayerPrefab, PlayerSpawn.position, PlayerSpawn.rotation) as GameObject;
        Debug.Log("" + PlayerObject.name);
        Player.pawn = PlayerObject.GetComponent<Pawn>();
    }


    public void Update()
    {
        if (!gameStart) return;
        
    }
}




