using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FasterPaddle : Option
{
    public override void ApplyOption()
    {
        GameManager.Instance.paddle.moveSpeed *= 1.2f;
        base.ApplyOption();
    }
}
