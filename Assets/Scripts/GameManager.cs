using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This is our catch-all Game manager. It's in all the scenes as a singleton. It:
/// -Tracks game state
/// -Presents the player with new upgrades/punishments
/// -Tracks score
/// </summary>
public class GameManager : MonoBehaviour
{
    //Public Fields
    public GameState gameState = GameState.start; //Our game state
    public static GameManager Instance = null; //Our singleton instance
    // Start is called before the first frame update
    private void Start()
    {
        //Set up singleton, also don't destroy on load so this persists across scenes
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
        
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

//States for tracking the game
public enum GameState
{
    start,
    ingame,
    choosing,
    gameover
}