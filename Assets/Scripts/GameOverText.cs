using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This just turns off the text when it's not game over
public class GameOverText : MonoBehaviour
{
    private CanvasGroup _cg;

    // Start is called before the first frame update
    private void Start()
    {
        _cg = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (GameManager.Instance.gameState == GameState.gameover)
            _cg.alpha = 1;
        else
            _cg.alpha = 0;
    }
}
