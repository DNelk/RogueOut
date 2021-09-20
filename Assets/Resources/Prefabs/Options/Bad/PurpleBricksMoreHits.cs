using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleBricksMoreHits : Option
{
    public override void ApplyOption()
    {
        BrickManager.Instance.purpleHP *= 2;
        base.ApplyOption();
    }
}
