using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallerPaddle : Option
{
    public override void ApplyOption()
    {
        GameManager.Instance.paddle.transform.localScale = new Vector3(
            0.75f * GameManager.Instance.paddle.transform.localScale.x,
            GameManager.Instance.paddle.transform.localScale.y, GameManager.Instance.paddle.transform.localScale.z);
        base.ApplyOption();
    }
}
