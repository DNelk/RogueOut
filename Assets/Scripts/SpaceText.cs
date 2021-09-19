using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This just turns off the text when the ball is moving
public class SpaceText : MonoBehaviour
{
    public Ball ball; //Reference to the ball

    // Update is called once per frame
    private void Update()
    {
        if(ball.state == BallState.start)
            gameObject.SetActive(true);
        else 
            gameObject.SetActive(false);
    }
}
