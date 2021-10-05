using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfStatement : Action
{
    public IfStatement(int ifStatement, Color color) : base(ifStatement, color)
    {
    }

    public override void DoAction(Transform kuka, int index)
    {
        Debug.Log("Man");
    }
}
