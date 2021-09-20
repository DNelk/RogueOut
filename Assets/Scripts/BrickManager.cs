using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This creates the wall of bricks and stores them. Like the other managers, this is also a singleton
/// </summary>
public class BrickManager : MonoBehaviour
{
    //Public Fields
    public int rows = 8; //How many rows of bricks to spawn
    public int columns = 10; //How many columns of bricks to spawn
    public int totalBricks; //How many bricks did we make
    public int bricksLeft; //How many bricks are left
    public Brick[,] bricks; //2D array of all of our bricks
    public float xOffset = 100; //How far apart to place each brick on the x axis
    public float yOffset = 50; //How far apart to place each brick on the y axis
    public static BrickManager Instance = null; //Singleton instance

    public bool enableExplosives = false; //Are some bricks explosive
    public int purpleHP = 1; //HP of purple bricks
    
    //Private Fields
    private bool _pinkDestroyed = false;
    private bool _blueDestroyed = false;

    // Start is called before the first frame update
    private void Start()
    {
        if (Instance == null) //Set up singleton
            Instance = this;
        else
            Destroy(this);
        
        bricks = new Brick[rows,columns];
        totalBricks = columns * rows;
        bricksLeft = totalBricks;
        GenerateBricks();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
    
    // Instantiate the wall of bricks
    public void GenerateBricks()
    {
        Vector3 currentPosition;
        Color currentColor;
        for (int j = 0; j < rows; j++)
        {
            currentPosition = transform.position + Vector3.down * (yOffset * j); //Offset y coord of the position
            if (j < 2)
                currentColor = ProjectColors.Pink;
            else if (j < 4)
                currentColor = ProjectColors.Blue;
            else if (j < 6)
                currentColor = ProjectColors.Purple;
            else
                currentColor = ProjectColors.Teal;
            
            for (int k = 0; k < columns; k++)
            {
                var brick = Instantiate(Resources.Load<GameObject>("Prefabs/Brick"), currentPosition, Quaternion.identity).GetComponent<Brick>();
                brick.Color = currentColor;
                if (j < 6 && j >= 4)
                {
                    Debug.Log(purpleHP);
                    brick.hp = purpleHP;
                }

                if (enableExplosives)
                {
                    int rnd = Random.Range(0, 10);
                    if (rnd == 9)
                        brick.explosive = true;
                }

                brick.myIndexes = new[] {j, k};
                brick.transform.parent = transform;
                currentPosition += Vector3.right * xOffset; //Offset the x position

                bricks[j, k] = brick;
            }
        }
    }

    /// <summary>
    /// Called when a brick is destroyed. Also decides when to increase speed.
    /// </summary>
    /// <param name="brickColor">Color of the brick destroyed</param>
    public void BrickDestroyed(Color brickColor)
    {
        bricksLeft--;
        if (totalBricks - bricksLeft == 4) //First increase
        {
            GameManager.Instance.paddle.ball.currentBallSpeed *= 1.2f;
        }
        if (totalBricks - bricksLeft == 12) //second increase
        {
            GameManager.Instance.paddle.ball.currentBallSpeed *= 1.2f;
        }

        if (!_blueDestroyed && brickColor == ProjectColors.Blue) //3/4 increase
        {
            GameManager.Instance.paddle.ball.currentBallSpeed *= 1.2f;
            _blueDestroyed = true;
        }
        
        if (!_pinkDestroyed && brickColor == ProjectColors.Pink) //3/4 increase
        {
            GameManager.Instance.paddle.ball.currentBallSpeed *= 1.2f;
            _pinkDestroyed = true;
        }
    }

    //Destroy any remaining bricks, then re-generate
    public void ResetBricks()
    {
        for(int j = 0; j < rows; j++)
        {
            for (int k = 0; k < columns; k++)
            {
                if(bricks[j,k] != null)
                    Destroy(bricks[j,k].gameObject);
            }
        }
    }

    /// <summary>
    /// Explode a brick! damage its surrounding bricks
    /// </summary>
    /// <param name="indices">The brick's location</param>
    public void Explode(int[] indices)
    {
        int row = indices[0];
        int column = indices[1];

        if (row != 0) //Brick above
        {
            if(bricks[row - 1, column] != null)
                bricks[row - 1, column].TakeHit();
        }
        if (row != rows-1) //Brick below
        {
            if(bricks[row + 1, column] != null)
                bricks[row + 1, column].TakeHit();
        }
        if (column != columns-1) //Brick to the right
        {
            if(bricks[row, column+1] != null)
                bricks[row, column+1].TakeHit();
        }
        if (column != 0) //Brick to the left
        {
            if(bricks[row, column-1] != null)
                bricks[row, column-1].TakeHit();
        }
    }
}
