using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using TMPro;

public class SpawnBlockCounter : MonoBehaviour
{
    public static int totalBlocks,blockCounter, spawnQueue =0;
    public TextMeshProUGUI spawnText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totalBlocks = BlockSpawner.totalBlocks;
        blockCounter = BlockSpawner.blockCounter;
        spawnQueue = (totalBlocks - blockCounter);
    }
}
