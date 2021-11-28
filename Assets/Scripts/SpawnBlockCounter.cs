using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using TMPro;

public class SpawnBlockCounter : MonoBehaviour
{
    public static int totalBlocks,blockCounter, spawnQueue =0;
    public TextMeshProUGUI spawnText;
    public int queue = -1;
    public GameObject[] counters;

    // Start is called before the first frame update
    void Start()
    {
        counters = GameObject.FindGameObjectsWithTag("Counters");   
    }

    // Update is called once per frame
    void Update()
    {
        totalBlocks = BlockSpawner.totalBlocks;
        blockCounter = BlockSpawner.blockCounter;
        spawnQueue = (totalBlocks - blockCounter);

        if (spawnQueue != queue)
        {
            queue = spawnQueue;

            foreach (GameObject counter in counters)
            {
                counter.GetComponent<TextMeshProUGUI>().text = queue.ToString();
            }
        }
    }
}
