using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// These are the bricks that the player is breaking.
/// </summary>
public class Brick : MonoBehaviour
{
    //Private Fields
    private int _hp = 1; //The brick's health. It may take a certain number of hits to break a brick.
    private SpriteRenderer _sr; //The brick's sprite
    public Color Color //Set the color of the brick
    {
        get => _sr.color;
        set => _sr.color = value;
    }
    
    // Awake is called when the object is created
    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    public void TakeHit()
    {
        _hp--;
        if (_hp <= 0)
        {
            GameManager.Instance.GetPoints(Color);
            Destroy(gameObject);
            BrickManager.Instance.bricksLeft--;
        }
    }
}
