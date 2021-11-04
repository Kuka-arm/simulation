using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualEntry : ScriptableObject
{
    public Sprite image;
    public string description;
    public Orientation orientation;

}

public enum Orientation
    {
        vertical,
        horizontal
    }
