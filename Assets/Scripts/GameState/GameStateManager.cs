using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// Singleton example. Put on an object in scene for it to be there.
public class GameStateManager : MonoBehaviour

{
    [SerializeField]
    private List<string> m_Levels = new List<string>();
    [SerializeField]
    private string m_TitleSceneName;
    [SerializeField]
    private string m_GameOverSceneName;
    [SerializeField]
    private int m_StartingLives;
    private static int m_currentLives;

    // Make sure that they are just doing one thing. Restricting access and encapsulation, or else it will get messy.
    private static GameStateManager _instance; //static means one. Field of GameStateManager type. Singleton, single instance of this thing.

    enum GAMESTATE // Set up multiple gamestates for my game
    {
        MENU,
        PLAYING,
        PAUSED,
        GAMEOVER
    }

    private static GAMESTATE m_state; // Store(save) the state throughout the whole game.
    private void Awake() // Called when the script becomes active.
    {
        if (_instance == null) // If _instance hasn't been initialized yet.
        {
            _instance = this; // Set instance variable to itself.
            m_currentLives = _instance.m_StartingLives;
            // Reset the lives to the starting lives everytime we start.
            DontDestroyOnLoad(_instance); // Not gonna be destroyed when we switch scenes.
        }
        else
        {
            Destroy(this); // Since there is another instance, destroy it because there's two.
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // If player pressed escape key
        {
            GameStateManager.TogglePause(); // Pause the game.
        }
    }
    public static void NewGame() // Start a new game.
    {
        m_state = GAMESTATE.PLAYING; // Set the state to playing.
        m_currentLives = _instance.m_StartingLives;
        if (_instance.m_Levels.Count > 0) // Make sure there's at least one level in the list.
        {
            SceneManager.LoadScene(_instance.m_Levels[0]); // Load the first level of my game.
        }
    }

    public static void LevelComplete() // When the level is complete.
    {
        Debug.Log("Congrats, you passed the level!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Loads the next scene in the list.

    }

    public static void GameOver() //Quit to the title menu.
    {
        m_state = GAMESTATE.MENU; // Set the state to menu.
        SceneManager.LoadScene(_instance.m_GameOverSceneName); //Load the title scene.

    }

    public static void TogglePause() // Pause our game.
    {
        if (m_state == GAMESTATE.PLAYING) // If we are playing our game right now
        {
            m_state = GAMESTATE.PAUSED; // Set the game state to paused.
            Time.timeScale = 0; // Pause the game (Set time to 0).
        }
        else if (m_state == GAMESTATE.PAUSED) // If the game is already paused.
        {
            m_state = GAMESTATE.PLAYING; // Set the game state to playing.
            Time.timeScale = 1; // Unpause the game (Set time to 1).
        }
    }
    public static void LoseALife()
    {
        m_currentLives -= 1;
        if (m_currentLives <= 0)
        {
            GameStateManager.GameOver(); // Game Over! No more lives. Returned back to main screen.
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Load the active scene, reset to beginning of whatever scene we are in.
        }
    }

}
