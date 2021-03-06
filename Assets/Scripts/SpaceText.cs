using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This just turns off the text when the ball is moving
public class SpaceText : MonoBehaviour
{
    public Ball ball; //Reference to the ball
    private CanvasGroup _cg;

    // Start is called before the first frame update
    private void Start()
    {
        _cg = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (ball.state == BallState.start && GameManager.Instance.gameState == GameState.ingame)
            _cg.alpha = 1;
        else
            _cg.alpha = 0;
    }
}
