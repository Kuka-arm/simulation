using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Action
{
    [SerializeField]
    Quaternion[] axisRotations;

    [SerializeField]
    int grip; // 0 = nothing, 1 = close, 2 = open

    public Quaternion[] AxisRotations { get => axisRotations; set => axisRotations = value; }
    public int Grip { get => grip; set => grip = value; }

    public Action(Quaternion[] axisRotations)
    {
        this.axisRotations = axisRotations;
        this.grip = 0;
    }

    public Action(int grip)
    {
        this.grip = grip;
    }

    public Action() { }

    public virtual void DoAction(Transform kuka, int index)
    {
    }
}
