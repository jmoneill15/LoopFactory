using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemSpawnerTut : MonoBehaviour
{
    [Header("Spawner Settings")]
    public GameObject[] itemPrefabs;
    public LineRenderer conveyorPath;

    public float timeBetweenItems = 1f;

    public int index = 0;

    // Public function to spawn a single item (for individual tutorial steps)
    public void SpawnSingleItem()
    {
        if (index >= itemPrefabs.Length)
        {
            Debug.LogWarning("No more items to spawn.");
            return;
        }

        SpawnItem(index);
        index++;
    }

    // Public function to spawn multiple items in sequence
    public void SpawnMultipleItems(int count)
    {
        StartCoroutine(SpawnMultipleCoroutine(count));
    }

    private IEnumerator SpawnMultipleCoroutine(int count)
    {
        for (int i = 0; i < count; i++)
        {
            if (index >= itemPrefabs.Length)
            {
                Debug.LogWarning("Ran out of prefabs during batch spawn.");
                yield break;
            }

            SpawnItem(index);
            index++;
            yield return new WaitForSeconds(timeBetweenItems);
        }
    }

    private void SpawnItem(int prefabIndex)
    {
        if (itemPrefabs.Length == 0 || conveyorPath == null)
            return;

        Vector3 spawnPos = conveyorPath.GetPosition(0);
        GameObject newItem = Instantiate(itemPrefabs[prefabIndex], spawnPos, Quaternion.identity);
        newItem.tag = "ConveyorItem";
        newItem.layer = LayerMask.NameToLayer("ConveyorItem");

        FollowConveyorPath follow = newItem.GetComponent<FollowConveyorPath>();
        if (follow != null)
        {
            follow.SetPath(conveyorPath);
        }

        Debug.Log("Spawned item at index " + prefabIndex);
    }
}

