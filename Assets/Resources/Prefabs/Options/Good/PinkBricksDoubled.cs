using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkBricksDoubled : Option
{
    public override void ApplyOption()
    {
        GameManager.Instance.pinkPoints *= 2;
        base.ApplyOption();

    }
}
