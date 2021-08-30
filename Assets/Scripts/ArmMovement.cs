using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArmMovement : MonoBehaviour
{
    public Transform[] armParts; // References to the arm parts
    public TMP_InputField r1, r2, r3, r4, r5, r6; // References to the input fields

    public List<Action> actions = new List<Action>(); // All the saved actions

    SavedPositions savedPoints; // Reference to the saved Positions parent

    // To apply rotation direction
    bool positive = true;

    void Start()
    {
        // Gets the saved Positions Parent
        savedPoints = GameObject.FindGameObjectWithTag("SavedPoints").GetComponent<SavedPositions>();
    }

    void Update()
    {
        // Checks for input to rotate arm parts
        if (Input.GetKey(KeyCode.LeftShift))
        {
            // To switch direction
            if (Input.GetKeyDown(KeyCode.R))
            {
                positive = !positive;
            }

            // Key 1-6 to rotate the arm by 15 degrees
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                RotateArm(armParts[0], 15);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                RotateArm(armParts[1], 15);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                RotateArm(armParts[2], 15);
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                RotateArm(armParts[3], 15);
            }

            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                RotateArm(armParts[4], 15);
            }

            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                RotateArm(armParts[5], 15);
            }
        }

        // Input to save and load points
        if (Input.GetKeyDown(KeyCode.Comma))
        {
            SavePoint();
        }
    }

    // What the buttons use to rotate the arm
    public void RotateArm(Transform part)
    {
        float degree = 0;
        float buffer = 0f;

        // Check what input field is being used
        switch (int.Parse(part.tag))
        {
            case 1:
                if (r1.text == string.Empty)
                    return;

                buffer = float.Parse(r1.text);
                break;
            case 2:
                if (r2.text == string.Empty)
                    return;

                buffer = float.Parse(r2.text);
                break;
            case 3:
                if (r3.text == string.Empty)
                    return;

                buffer = float.Parse(r3.text);
                break;
            case 4:
                if (r4.text == string.Empty)
                    return;

                buffer = float.Parse(r4.text);
                break;
            case 5:
                if (r5.text == string.Empty)
                    return;

                buffer = float.Parse(r5.text);
                break;
            case 6:
                if (r6.text == string.Empty)
                    return;

                buffer = float.Parse(r6.text);
                break;
        }

        // Checks which way the arm should rotate
        if (positive)
        {
            degree = part.localRotation.eulerAngles.z + buffer;
        }
        else
        {
            degree = part.localRotation.eulerAngles.z - buffer;
        }

        // Rotates arm
        part.GetComponent<ArmPiece>().target = Quaternion.Euler(part.localRotation.eulerAngles.x, part.localRotation.eulerAngles.y, degree);
    }

    // Rotation that the keys use
    public void RotateArm(Transform part, float deg)
    {
        float degree = 0;

        if (positive)
        {
            degree = part.localRotation.eulerAngles.z + deg;
        }
        else
        {
            degree = part.localRotation.eulerAngles.z - deg;
        }

        part.GetComponent<ArmPiece>().target = Quaternion.Euler(part.localRotation.eulerAngles.x, part.localRotation.eulerAngles.y, degree);
    }

    // Switch the positive bool
    public void EnablePositive()
    {
        positive = true;
    }

    public void DisablePositive()
    {
        positive = false;
    }

    // Resets the arm to its origin position
    public void ResetArm()
    {
        foreach (Transform part in armParts)
        {
            part.GetComponent<ArmPiece>().ResetRotation();
        }
    }

    // Save arms current position
    public void SavePoint()
    {
        Quaternion[] newRotations = new Quaternion[6];

        for (int i = 0; i < armParts.Length; i++)
        {
            newRotations[i] = armParts[i].GetComponent<ArmPiece>().target;
        }

        actions.Add(new Action(newRotations));

        savedPoints.UpdateUI(actions.ToArray());
    }

    // Rotates to the target location
    public void GoToPos(int posIndex)
    {
        Quaternion[] targetRotation = actions[posIndex].AxisRotations;

        for (int i = 0; i < armParts.Length; i++)
        {
            armParts[i].GetComponent<ArmPiece>().target = targetRotation[i];
        }
    }
}
