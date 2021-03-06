using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [Header("References")]
    public GameObject blockPrefab;
    public Transform blockSpawnPoint;
    public Transform blockParent;

    public static int totalBlocks =0, blockCounter =0;

    public void Update()
    {
        if (Input.GetKey(KeyCode.ScrollLock))
        {
            Instantiate(blockPrefab, blockSpawnPoint.position, Quaternion.identity, transform);
        }
    }

    public void SpawnBlock(int number)
    {
        StartCoroutine(spawnUserAmount(number));
    }
    IEnumerator spawnUserAmount(int numberBlocks)
    {
        int count = 0;
        int counter = 0;

        totalBlocks = numberBlocks;

        while (counter < numberBlocks)
        {
            blockCounter = counter;
            Transform[] spawnBlocks = blockParent.Cast<Transform>().ToArray();
            count = spawnBlocks.Length;

            if (count < 11)
            {
                yield return new WaitForSeconds(1f);
                GameObject newblock = Instantiate(blockPrefab, blockSpawnPoint.position, blockSpawnPoint.rotation, transform);
                Color newColor = new Color(Random.value, Random.value, Random.value, 1.0f);
                Renderer renderer = newblock.GetComponentInChildren<Renderer>();
                renderer.material.color = newColor;

                counter++;       
            }
            else
            {
                yield return new WaitForSeconds(1f);
            }
        }
        blockCounter++;
    }
}
