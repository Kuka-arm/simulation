using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class PlaySequence : MonoBehaviour
{
    bool actionCompleted = true; // Checks if the current action is completed
    int actionCount = 0; // Keeps track of where the play sequence is at
    bool performed = false; // Checks if current action has started
    bool play = false; // Checks to see if the play sequence is started

    public Transform positionParent;
    ArmMovement armMov;

    public Color normalColor; // Unhighlighted color for the UI element
    public Color playColor; // Highlighted color for the UI element

    private void Start()
    {
        armMov = GameObject.FindGameObjectWithTag("Kuka").GetComponent<ArmMovement>();
    }

    private void LateUpdate()
    {
        CheckActionComplete(); 

        if (!play)
            return;

        if (actionCompleted)
        {
            Transform[] posNodes = positionParent.Cast<Transform>().ToArray();

            // Checks to see if saved positions exist
            if (posNodes.Length == 0)
            {
                play = false;
                return;
            }

            if (!performed) // Start performing the action
            {
                posNodes[actionCount].GetComponent<PositionData>().DoAction();

                posNodes[actionCount].GetComponent<Image>().color = playColor; // Set Color

                performed = true;
                actionCount++;
            }

            if (actionCount >= posNodes.Length)
            {
                play = false;
            }

            actionCompleted = false;
        }
    }

    // Resets the color of the ui unit
    void ResetColor()
    {
        Transform[] nodes = positionParent.Cast<Transform>().ToArray();

        if (nodes.Length == 0)
            return;

        foreach (Transform node in nodes)
        {
            node.GetComponent<Image>().color = normalColor; // Set Color
        }
    }

    // Chekcs if all the rotation parts have reached thier torations
    void CheckActionComplete()
    {
        bool completed = true;

        foreach  (Transform part in armMov.armParts)
        {
            if (!part.GetComponent<ArmPiece>().completed || armMov.gripping == 0)
            {
                completed = false;
                performed = false;
            }
        }

        actionCompleted = completed;

        if (completed)
        {
            ResetColor();
        }
    }
    
    // Called but the button to start the playback
    public void Play()
    {
        play = true;
        actionCount = 0;
        performed = false;
        actionCompleted = true;
    }
}
