using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action
{
    Quaternion[] axisRotations;

    public Quaternion[] AxisRotations { get => axisRotations; set => axisRotations = value; }

    public Action(Quaternion[] axisRotations)
    {
        this.AxisRotations = axisRotations;
    }
    public Action() { }

    public override string ToString()
    {
        return $"{axisRotations[0]}";
    }
}
