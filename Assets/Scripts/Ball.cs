using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// This is the game's ball. It bounces against objects and damages bricks
/// </summary>
public class Ball : MonoBehaviour
{
    //Public Fields and Properties
    public BallState state = BallState.start;
    
    public Color BallColor //Property to get/set color of the ball
    {
        get => _ballSprite.color;
        set => _ballSprite.color = value;
    }

    //Private Fields
    //Components
    private SpriteRenderer _ballSprite; //The ball sprite renderer component
    
    //Physics
    private Vector2 _velocity; //The ball's velocity vector
    [SerializeField] private float _ballSpeed = 1; //The scalar component of the velocity. Serialized so we can tune it in the inspector, but other places can't touch it.
    
    // Start is called before the first frame update
    private void Start()
    {
        //Get all our components
        _ballSprite = GetComponentInChildren<SpriteRenderer>();
        
        //Initialize velocity
        _velocity = new Vector2(Random.Range(0f,1f),1);
    }

    // Update is called once per frame
    private void Update()
    {
        switch (state) //State machine for ball movement
        {
            case BallState.moving:
                MoveBall();
                break;
            default:
                break;
        }
    }

    //Move the ball using velocity
    private void MoveBall()
    {
        transform.Translate(_velocity * _ballSpeed * Time.deltaTime); //Straightforward move here, just translating it by velocity.
    }

    //Collisions!
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(GameManager.Instance.gameState == GameState.start) //If we're on the start screen, we want to change color
            StartScreenManager.Instance.ChangeColor();

        if (other.gameObject.CompareTag("Boundary")) //Bounce off boundaries
        {
            //Bounce! Flip the x or y depending on which boundary it is
            if (other.gameObject.GetComponent<Boundary>().isTopBoundary)
                _velocity.y *= -1;
            else
                _velocity.x *= -1;
        }
            
    }
}

//State for tracking what the ball's doing
public enum BallState
{
    moving,
    start,
    gameover
}
