using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone3 : MonoBehaviour
{
    private int currentColor, length;
    public LayerMask layer;
    Color[] colors = new Color[] { Color.green, Color.red, Color.blue, Color.yellow };

    void Start()
    {
        currentColor = 2; //Blue
        length = colors.Length;
        GetComponent<Renderer>().material.color = colors[currentColor];
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layer))
            {
                currentColor = (currentColor + 1) % length;
                hit.transform.GetComponent<Renderer>().material.color = colors[currentColor];
            }
        }
    }

    public static int counter = 0;

    /*
        void OnGUI()
        {
            GUI.Box(new Rect(100, 100, 250, 30), "Blocks Placed In Zone 1:" + counter.ToString());
        }
    */
    void OnTriggerEnter(Collider blockTrigger)
    {
        if (blockTrigger.transform.name == "woodenBlock(Clone)")
        {
            //Debug.Log("A block entered a placement area");
            counter += 1;
        }
    }

    /*
        void OnTriggerStay(Collider blockTrigger)
        {
            if (blockTrigger.transform.name == "woodenBlock(Clone)")
            {
                //Debug.Log("Block" + counter.ToString() + " has entered placement area"); //TODO Change wording, blocks do not have unique numbers
            }
        }
    */

    void OnTriggerExit(Collider blockTrigger)
    {
        if (blockTrigger.transform.name == "woodenBlock(Clone)")
        {
            //Debug.Log("Block" + counter.ToString() + "has left placement area");
            counter -= 1;
        }
    }
}
