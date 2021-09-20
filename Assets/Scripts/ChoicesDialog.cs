using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TMPro;
using UnityEngine;
/// <summary>
/// This handles the player's roguelike choice
/// </summary>
public class ChoicesDialog : MonoBehaviour
{
    //Public Fields
    public TMP_Text choiceText; //The text on the dialog
    public Transform options; //The Options container
    
    //Private Field
    private CanvasGroup _cg; //Our Canvas group
    private bool _goodOptionSelected = false; //Have we selected our two options
    private bool _showingOptions = false; //are we currently showing options
    private Option[] _options; //Our available options
    
    // Start is called before the first frame update
    private void Start()
    {
        _cg = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Toggle visibility
        if (GameManager.Instance.gameState == GameState.choosing)
        {
            _cg.alpha = 1;
            if (_showingOptions == false)
            {
                _showingOptions = true;
                GenerateOptions("Good");
            }
        }
        else
            _cg.alpha = 0;
    }

    /// <summary>
    /// Generate the option buttons
    /// </summary>
    /// <param name="folder">The folder to load from</param>
    private void GenerateOptions(string folder)
    {
        _options = new Option[3];
        int[] indices = new int[3];
        //Choose 3 random options, then instantiate them and add them to the container
        for (int i = 0; i < 3; i++)
        {
            int currentIndex = -1;
            do
            {
                currentIndex = Random.Range(1, 5);
            } while (indices.Contains(currentIndex));

            indices[i] = currentIndex;
            _options[i] = Instantiate(Resources.Load<GameObject>("Prefabs/Options/" + folder + "/" + currentIndex), options).GetComponent<Option>();
        }
    }

    //A choice was made. If it was the first choice, now make a bad choice. Otherwise restart the game
    public void ChoiceMade()
    {
        foreach (var option in _options)
        {
            Destroy(option.gameObject);
        }

        if (!_goodOptionSelected)
        {
            _goodOptionSelected = true;
            GenerateOptions("Bad");
            choiceText.text = "Choose an obstacle.";
        }
        else
        {
            GameManager.Instance.ResetGame(false);
            _goodOptionSelected = false;
            _showingOptions = false;
        }

    }
}
