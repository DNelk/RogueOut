using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// These are the bricks that the player is breaking.
/// </summary>
public class Brick : MonoBehaviour
{
    //Private Fields
    private SpriteRenderer _sr; //The brick's sprite
    //Public Fields/Properties
    public Color Color //Set the color of the brick
    {
        get => _sr.color;
        set => _sr.color = value;
    }

    public bool explosive = false; //does this explode
    public int[] myIndexes; //this brick's location in the grid
    public int hp = 1; //The brick's health. It may take a certain number of hits to break a brick.
    
    // Awake is called when the object is created
    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
    }
    

    public void TakeHit()
    {
        hp--;
        if (explosive)
        {
            BrickManager.Instance.Explode(myIndexes);
        }
        if (hp <= 0)
        {
            GameManager.Instance.GetPoints(Color);
            BrickManager.Instance.BrickDestroyed(Color);
            Destroy(gameObject);
        }
    }
}
