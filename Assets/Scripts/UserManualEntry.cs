using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class UserManualEntry : ScriptableObject
{
    public string title;
    public Sprite image;
    public string description;
    public Orientation orientation;
}
