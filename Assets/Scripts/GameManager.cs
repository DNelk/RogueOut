using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This is our catch-all Game manager. It: 
/// -Tracks game state
/// -Presents the player with new upgrades/punishments
/// -Tracks score
/// </summary>
public class GameManager : MonoBehaviour
{
    //Public Fields
    public GameState gameState = GameState.ingame; //Our game state
    public static GameManager Instance = null; //Our singleton instance
    public TMP_Text scoreText; //Score text
    public TMP_Text outsText; //Outs text
    public ChoicesDialog choices; //Panel for choosing upgrades/obstacles
    public Paddle paddle; //Reference to the paddle
    public int pinkPoints = 700;
    public int bluePoints = 500;
    public int purplePoints = 300;
    public int tealPoints = 100;
    public bool losePoints = false;
    
    //Private Fields
    private int _score = 0; //Current score
    private int _outs = 0; //How many outs have we had
    private int _maxOuts = 3; //How many outs do we have until we lose
     
    
    // Start is called before the first frame update
    private void Start()
    {
        //Set up singleton
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    // Update is called once per frame
    private void Update()
    {
        switch (gameState) //State machine
        {
            case GameState.ingame:
                InGameUpdate();
                break;
            case GameState.gameover:
                GameOverUpdate();
                break;
            case GameState.choosing:
                ChoosingUpdate();
                break;
        }
    }

    //Update function when the game is happening
    private void InGameUpdate()
    {
        if (BrickManager.Instance.bricksLeft == 0)
        {
            GameOver(true);
            BrickManager.Instance.ResetBricks();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameOver(true);
            BrickManager.Instance.ResetBricks();
        }
            
    }
   
    //Update function when the game is over
    private void GameOverUpdate()
    {
        if (Input.anyKeyDown) //When any key is pressed, the game starts
        {
            ResetGame(true);
        }
    }

    //Update function when choosing new rules
    private void ChoosingUpdate()
    {
        
    }
    
    /// <summary>
    /// Add points to the score
    /// </summary>
    /// <param name="brickColor">The color of the brick that added points</param>
    public void GetPoints(Color brickColor)
    {
        if (brickColor == ProjectColors.Pink)
            _score += pinkPoints;
        if (brickColor == ProjectColors.Blue)
            _score += bluePoints;
        if (brickColor == ProjectColors.Purple)
            _score += purplePoints;
        if (brickColor == ProjectColors.Teal)
            _score += tealPoints;

        scoreText.text = "Score: " + _score;
    }

    //Called when the ball goes out of bounds
    public void OutOfBounds()
    {
        if (losePoints)
        {
            _score -= 1000;
            scoreText.text = "Score: " + _score;
        }
            
        paddle.ResetPaddle(); //Reset paddle and ball position 
        _outs++;
        outsText.text = "Outs: " + _outs + "/" + _maxOuts;
        if (_outs == _maxOuts)
            GameOver(false);
    }

    /// <summary>
    /// Called when there are no bricks yet or the player is out of outs.
    /// </summary>
    /// <param name="win">is this a game over because we won?</param>
    private void GameOver(bool win)
    {
        if (win)
        {
            gameState = GameState.choosing;
        }
        else
        {
            gameState = GameState.gameover;
            
        }

        paddle.ball.state = BallState.gameover;
    }

    /// <summary>
    /// Reset everything to its initial positions
    /// </summary>
    /// <param name="wipeScore">Is the score put back to zero</param>
    public void ResetGame(bool wipeScore)
    {
        if (wipeScore)
        {
            SceneManager.LoadScene("MainScene");
            return;
        }
        paddle.ResetPaddle();
        paddle.ball.currentBallSpeed = paddle.ball.ballSpeed;
        gameState = GameState.ingame;
        _outs = 0;
        BrickManager.Instance.GenerateBricks();
    }
}

//States for tracking the game
public enum GameState
{
    ingame,
    choosing,
    gameover
}