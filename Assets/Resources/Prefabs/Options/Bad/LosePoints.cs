using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosePoints : Option
{
    public override void ApplyOption()
    {
        GameManager.Instance.losePoints = true;
        base.ApplyOption();
    }
}
