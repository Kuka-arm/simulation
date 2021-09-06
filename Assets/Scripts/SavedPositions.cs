using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class SavedPositions : MonoBehaviour
{
    public GameObject positionNode; // Reference of the spawned UI prefab
    public Transform positionParent; // Reference of the saved position parent

    // Update the saved point UI
    public void UpdateUI(Action[] position)
    {
        Transform[] posNodes = positionParent.Cast<Transform>().ToArray();

        if (posNodes.Length != 0) // Update existing positions
        {
            for (int i = 0; i < posNodes.Length; i++) // Update any existing ones
            {
                if (position[i].Grip == 0)
                {
                    // Assign new data
                    posNodes[i].GetComponent<PositionData>().nodeAction = new Position(position[i].AxisRotations);
                    posNodes[i].GetComponent<PositionData>().index = i;


                    // Change text
                    posNodes[i].GetComponentInChildren<TextMeshProUGUI>().text = $"Action {i + 1}: Position";
                } 
                else if( position[i].Grip == 1)
                {
                    posNodes[i].GetComponent<PositionData>().nodeAction = new Grip(position[i].Grip);
                    posNodes[i].GetComponent<PositionData>().index = i;


                    // Change text
                    posNodes[i].GetComponentInChildren<TextMeshProUGUI>().text = $"Action {i + 1}: Grip Close";
                }
                else if (position[i].Grip == 2)
                {
                    posNodes[i].GetComponent<PositionData>().nodeAction = new Grip(position[i].Grip);
                    posNodes[i].GetComponent<PositionData>().index = i;


                    // Change text
                    posNodes[i].GetComponentInChildren<TextMeshProUGUI>().text = $"Action {i + 1}: Grip Open";
                }
            }

            if (position.Length - posNodes.Length > 0) // If there are still movements and all the old one have been updated, add new ones
            {
                for (int i = posNodes.Length; i < position.Length; i++)
                {
                    SpawnNewNode(position, i);
                }
            } 
            else
            {
                for (int i = posNodes.Length; i < position.Length; i++)
                {
                    Destroy(posNodes[i]);
                }
            }
        }
        else // Add new positions
        {
            for (int i = 0; i < position.Length; i++) 
            {
                SpawnNewNode(position, i);
            }
        }
    }

    void SpawnNewNode(Action[] position, int index)
    {
        if (position[index].Grip == 0)
        {
            // Create Position Node
            GameObject newPosNode = Instantiate(positionNode, positionParent);

            // Assign Data
            newPosNode.GetComponent<PositionData>().nodeAction = new Position(position[index].AxisRotations);
            newPosNode.GetComponent<PositionData>().index = index;

            // Change text
            newPosNode.GetComponentInChildren<TextMeshProUGUI>().text = $"Action {index + 1}: Position";
        }
        else if (position[index].Grip == 1)
        {
            // Create Position Node
            GameObject newPosNode = Instantiate(positionNode, positionParent);

            // Assign Data
            newPosNode.GetComponent<PositionData>().nodeAction = new Grip(position[index].Grip);
            newPosNode.GetComponent<PositionData>().index = index;

            // Change text
            newPosNode.GetComponentInChildren<TextMeshProUGUI>().text = $"Action {index + 1}: Grip Close";
        }
        else if (position[index].Grip == 2)
        {
            // Create Position Node
            GameObject newPosNode = Instantiate(positionNode, positionParent);

            // Assign Data
            newPosNode.GetComponent<PositionData>().nodeAction = new Grip(position[index].Grip);
            newPosNode.GetComponent<PositionData>().index = index;

            // Change text
            newPosNode.GetComponentInChildren<TextMeshProUGUI>().text = $"Action {index + 1}: Grip Open";
        }
    }
}
