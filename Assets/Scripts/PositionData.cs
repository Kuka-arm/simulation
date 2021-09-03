using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionData : MonoBehaviour
{
    public Quaternion[] axisRotations = new Quaternion[6]; // Saved rotations of a saved position
    public int index; // Saved index of a rotation

    Transform kuka; // Reference to the kuka arm

    void Start()
    {
        kuka = GameObject.FindGameObjectWithTag("Kuka").transform;
    }

    // Rotates the arm to the target location
    public void DoAction()
    {
        kuka.GetComponent<ArmMovement>().actions[index].DoAction(kuka, index);
    }
}
