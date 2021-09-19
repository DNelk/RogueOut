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
    private void GenerateBricks()
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
                brick.transform.parent = transform;
                currentPosition += Vector3.right * xOffset; //Offset the x position

                bricks[j, k] = brick;
            }
        }
    }
}
