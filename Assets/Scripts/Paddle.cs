using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

/// <summary>
/// This is the paddle, which the player controls to knock the ball around.
/// </summary>
public class Paddle : MonoBehaviour
{
    //Public fields
    public float moveSpeed = 1;
    public Ball ball;
    
    //Private fields
    private Vector3 _initialPaddlePos;
    private Vector3 _initialBallPos;
    
    // Start is called before the first frame update
    void Start()
    {
        _initialPaddlePos = transform.position;
        _initialBallPos = ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.gameState == GameState.ingame) //Should we check input
            ProcessInput();
            
    }

    //Read input and move the paddle accordingly, also launch the ball 
    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))//Left movement, a or left arrow
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) //Right movement, d or right arrow
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }

        if (ball.state == BallState.start) //Launch the ball
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ball.state = BallState.moving;
                ball.transform.SetParent(GameManager.Instance.transform, true);
            }
        }
            
    }

    //Reset the ball and paddle to initial positions
    public void ResetPaddle()
    {
        ball.transform.parent = transform;
        transform.position = _initialPaddlePos;
        ball.transform.position = _initialBallPos;
        ball.state = BallState.start;
    }
}
