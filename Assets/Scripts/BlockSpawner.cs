using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    // made these variables global
    public static int count = 0;
    public static int counter = 0;

    [Header("References")]
    public GameObject blockPrefab;
    public Transform blockSpawnPoint;

    public void Update()
    {
        if (Input.GetKey(KeyCode.ScrollLock))
        {
            Instantiate(blockPrefab, blockSpawnPoint.position, Quaternion.identity, transform);
        }
    }

    public void SpawnBlock()
    {
<<<<<<< Updated upstream
        GameObject newblock = Instantiate(blockPrefab, blockSpawnPoint.position, blockSpawnPoint.rotation, transform);
=======
        StartCoroutine(spawnUserAmount(number));
    }
    IEnumerator spawnUserAmount(int numberBlocks)
    {


        while (counter < numberBlocks)
        {
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
>>>>>>> Stashed changes
    }
}
