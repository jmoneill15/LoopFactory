using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    public GameObject[] itemPrefabs; // Array of different item prefabs
    public LineRenderer conveyorPath;

    public float spawnDelay = 4f;
    private float timer;

    void Start()
    {
        timer = spawnDelay;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            if (IsSpaceAvailable())
            {
                SpawnRandomItem();
                timer = spawnDelay;
            }
            else
            {
                // Try again soon if it was blocked
                timer = 0.2f; // Retry sooner than full delay
            }
        }
    }

    void SpawnRandomItem()
    {
        // Pick a random prefab
        int index = Random.Range(0, itemPrefabs.Length);
        GameObject selectedPrefab = itemPrefabs[index];

        // Spawn at start of conveyor
        Vector3 spawnPos = conveyorPath.GetPosition(0);
        GameObject newItem = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);
        newItem.tag = "ConveyorItem"; // <- in case prefab lost its tag
        newItem.layer = LayerMask.NameToLayer("ConveyorItem"); 

        // Assign the path to the item
        FollowConveyorPath follow = newItem.GetComponent<FollowConveyorPath>();
        if (follow != null)
        {
            follow.SetPath(conveyorPath);
        }
    }
    private bool IsSpaceAvailable()
    {
        if (itemPrefabs.Length == 0 || conveyorPath == null)
            return false;

        Vector3 spawnPos = conveyorPath.GetPosition(0);
        float safeSpacing = 1.5f; // same as item spacing, adjust if needed

        foreach (var item in FollowConveyorPath.activeItems)
        {
            if (item == null || item.gameObject == null)
                continue;

            float dist = Vector3.Distance(item.transform.position, spawnPos);
            if (dist < safeSpacing)
            {
                return false; // too close to spawn point
            }
        }

        return true; // space is clear
    }
}