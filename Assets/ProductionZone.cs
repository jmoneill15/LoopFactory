using UnityEngine;

public class ProductionZone : MonoBehaviour
{
     [Header("Production Spawner Settings")]
    public GameObject[] productPrefabs; // Array of different item prefabs
    public LineRenderer conveyorPath;
    
    public LogicScript logic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
/*
    public void SpawnProductionItem(){
        int index;
        string vehicle = logic.vehicleType; 
        if(vehicle == "Bikes"){
            index = 0;
        }
        else if(vehicle == "Planes"){
            index = 1;
        }
        else if(vehicle == "Cars"){
            index = 2;
        }

        GameObject selectedPrefab = productPrefabs[index];

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

    }*/
}
