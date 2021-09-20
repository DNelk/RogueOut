using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//These options are buttons that add their rule to the game when pressed
public class Option : MonoBehaviour
{
    public bool isBad; //Is this an obstacle?
    private Image _image; //Our image

    //Start is called before the first frame
    private void Start()
    {
        _image = GetComponent<Image>();
        if (isBad)
            _image.color = ProjectColors.Blue;
    }

    //Apply the effect of this option to the game
    public virtual void ApplyOption()
    {
        //This is empty. The options that extend this override it with their effect
        GameManager.Instance.choices.ChoiceMade();
    }
}
