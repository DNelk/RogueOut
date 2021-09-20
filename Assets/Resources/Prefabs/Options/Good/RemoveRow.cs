using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveRow : Option
{
    public override void ApplyOption()
    {
        BrickManager.Instance.rows--;
        base.ApplyOption();
    }
}
