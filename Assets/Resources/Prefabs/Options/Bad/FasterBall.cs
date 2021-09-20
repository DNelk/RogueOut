using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FasterBall: Option
{
    public override void ApplyOption()
    {
        GameManager.Instance.paddle.ball.ballSpeed *= 1.1f;
        base.ApplyOption();
    }
}
