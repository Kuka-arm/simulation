using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCounter : MonoBehaviour
{
    int totalBlocks, counter, display;
    //public TextMeshProUGUI spawnText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (BlockSpawner.count != null && BlockSpawner.counter != null)
        {
            totalBlocks = BlockSpawner.count;
            counter = BlockSpawner.counter;

            if (totalBlocks > 9 || display > 9)
            {
                display = (totalBlocks - counter);
            }
            else 
                display = 0;
        }
    }
}
