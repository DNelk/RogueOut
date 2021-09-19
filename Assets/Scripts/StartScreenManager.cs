using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This is a singleton that manages the start game screen. It changes colors when the ball hits the wall and also changes the scene to gameplay when a key is pressed
/// </summary>
public class StartScreenManager : MonoBehaviour
{
    //Public Fields
    public TMP_Text[] texts = new TMP_Text[2]; //Our Two text objects (referenced here so we can change their colors)
    public Camera mainCamera; //We also want a reference to the camera so we can change the camera BG color
    public Ball startBall; //The ball that bounces around on this start screen
    public static StartScreenManager Instance = null; //Our singleton instance of this manager
    
    //Private Fields
    private int _currentBGColorIndex = -1; //Track our Background Color so we never have the same one twice
    
    // Start is called before the first frame update
    private void Start()
    {
        //Set up singleton.
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

        startBall.state = BallState.moving;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.anyKeyDown) //When any key is pressed, the game starts
        {
            SceneManager.LoadScene("MainScene");
        }
    }

    //Change the background color randomly, and also change the text and ball color so it's legible
    public void ChangeColor()
    {
        int newColorIndex = _currentBGColorIndex;
        while (newColorIndex == _currentBGColorIndex)
        {
            newColorIndex = Random.Range(0, ProjectColors.Colors.Length);
        }

        _currentBGColorIndex = newColorIndex; //Set current color
        
        //Decide our new foreground color
        Color newColor = ProjectColors.Colors[_currentBGColorIndex];
        Color foregroundColor = Color.white;
        //We want white on darker colors, and black on lighter colors
        if (newColor == ProjectColors.Yellow || newColor == ProjectColors.Teal)
            foregroundColor = Color.black;
        
        //Set all the colors
        mainCamera.backgroundColor = newColor;
        foreach (var text in texts)
        {
            text.color = foregroundColor;
        }
        startBall.BallColor = foregroundColor;

    }
}
