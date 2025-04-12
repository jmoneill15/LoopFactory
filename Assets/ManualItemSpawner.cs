using UnityEngine;


public class ManualItemSpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    public LineRenderer conveyorPath;
    public float spacingCheck = 1.5f;

    // Optional: to reference the last spawn
    public GameObject lastSpawnedItem;

    public void SpawnItem(GameObject prefab)
    {
        if (prefab == null || conveyorPath == null)
        {
            Debug.LogWarning("Missing prefab or conveyorPath");
            return;
        }

        if (!IsSpaceAvailable())
        {
            Debug.Log("Spawn blocked: not enough space");
            return;
        }

        Vector3 spawnPos = conveyorPath.GetPosition(0);
        GameObject newItem = Instantiate(prefab, spawnPos, Quaternion.identity);
        newItem.tag = "ConveyorItem";
        newItem.layer = LayerMask.NameToLayer("ConveyorItem");

        FollowConveyorPath follow = newItem.GetComponent<FollowConveyorPath>();
        if (follow != null)
        {
            follow.SetPath(conveyorPath);
        }

        lastSpawnedItem = newItem;
    }

    private bool IsSpaceAvailable()
    {
        Vector3 spawnPos = conveyorPath.GetPosition(0);

        foreach (var item in FollowConveyorPath.activeItems)
        {
            if (item == null) continue;

            float dist = Vector3.Distance(item.transform.position, spawnPos);
            if (dist < spacingCheck)
                return false;
        }

        return true;
    }
}

