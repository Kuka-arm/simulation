using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountBlocks : MonoBehaviour
{
    public static int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 250, 100), "Blocks Placed In All Zones:" + counter.ToString() + "\n" + "Blocks Placed In Zone 1:" + Zone1.counter.ToString() + "\n" + "Blocks Placed In Zone 2:" + Zone2.counter.ToString() + "\n" + "Blocks Placed In Zone 3:" + Zone3.counter.ToString() + "\n" + "Blocks Placed In Zone 4:" + Zone4.counter.ToString());
    }
}
