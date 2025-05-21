using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Random = UnityEngine.Random;
using NUnit.Framework;

public class LogicScript : MonoBehaviour
{
    public int totalVehicles; //goal for player to make
    public int vehicleIndex; //array index to choose vehicle
    public string vehicleType;

    public string objective;

    public GameObject timerBackground;
    //References to drag objects within unity
    public GameObject gameCharacter;

    public GameObject whileLoopBroken;

    public GameObject whileSign;
    public GameObject whileSignText;
    public GameObject roundOverScreen;
    public GameObject roundLostScreen;
    public GameObject WhileLoop3Items;
    public GameObject WhileLoop4Items;

    public GameObject BikesImageSet;
    public GameObject PlanesImageSet;
    public GameObject CarsImageSet;




    public Text objectiveText; //players objective

    //While Loop Screen with 3 items
    public Text whileScreenMadeItem1;
    public Text whileScreenNeedItem1;

    public Text whileScreenMadeItem2;
    public Text whileScreenNeedItem2;
    public Text whileScreenMadeItem3;
    public Text whileScreenNeedItem3;

    //WHile Loop screen with 4 Items
    public Text while4ItScreenMadeItem1;
    public Text while4ItScreenNeedItem1;

    public Text while4ItScreenMadeItem2;
    public Text while4ItScreenNeedItem2;
    public Text while4ItScreenMadeItem3;
    public Text while4ItScreenNeedItem3;
    public Text while4ItScreenMadeItem4;
    public Text while4ItScreenNeedItem4;

    //For Loop Screen Totals
    public Text forScreenMade;
    public Text forScreenNeed;
    public ManualItemSpawner spawner;

    [Header("Vehicle Prefabs")]
    public GameObject bikePrefab;
    public GameObject planePrefab;
    public GameObject carPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //public AudioSource ; add in audio

    AudioManager audioManager;

    private void Awake()
    {
        //audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        UpdateObjective();
        //SpawnProduct();
    }


    public string[] vehicles;

    //Making the objectives
    public void UpdateObjective()
    {

        totalVehicles = Random.Range(2, 5); // to get 2-4
        //Debug.Log(totalVehicles);

        vehicleIndex = Random.Range(0, 3); // to get 0-2
        //Debug.Log(vehicleIndex); 
        vehicleType = vehicles[vehicleIndex];
        //Debug.Log(vehicleType);

        string strTotVehicle = totalVehicles.ToString();
        objective = strTotVehicle + " " + vehicleType;
        //Debug.Log(objective);

        objectiveText.text = objective; //Updates Object Screen

        //For screen Need vehicles set
        forScreenNeed.text = strTotVehicle;

        //Check what vehicle it is and set needed accordingly
        if (vehicleType == "Cars")
        {
            WhileLoop3Items.SetActive(false);
            WhileLoop4Items.SetActive(true);

            BikesImageSet.SetActive(false);
            PlanesImageSet.SetActive(false);
            CarsImageSet.SetActive(true);

            while4ItScreenNeedItem1.text = "1"; //Chasis
            while4ItScreenNeedItem2.text = "2"; //Door
            while4ItScreenNeedItem3.text = "1"; //Engine
            while4ItScreenNeedItem4.text = "4"; //Wheels


        }
        else if (vehicleType == "Bikes")
        {
            WhileLoop3Items.SetActive(true);
            WhileLoop4Items.SetActive(false);

            BikesImageSet.SetActive(true);
            PlanesImageSet.SetActive(false);
            CarsImageSet.SetActive(false);

            whileScreenNeedItem1.text = "1"; // Chasis
            whileScreenNeedItem2.text = "1"; // Engine
            whileScreenNeedItem3.text = "2"; // Wheels

        }
        else if (vehicleType == "Planes")
        {
            WhileLoop3Items.SetActive(true);
            WhileLoop4Items.SetActive(false);

            BikesImageSet.SetActive(false);
            PlanesImageSet.SetActive(true);
            CarsImageSet.SetActive(false);

            whileScreenNeedItem1.text = "3"; //Plane Wings
            whileScreenNeedItem2.text = "2";//Turbine
            whileScreenNeedItem3.text = "2"; // Wheels
        }
    }
    public int forLoopCounter = 0;
    //Increase For Loop Count
    public void ForLoopCounter()
    {

        forLoopCounter += 1;
        string forCount = forLoopCounter.ToString();
        forScreenMade.text = forCount;
        Debug.Log("counter updated" + forScreenMade);
    }


    //Increase while loop counter
    public int whileCounterIt1 = 0;
    public int whileCounterIt2 = 0;
    public int whileCounterIt3 = 0;
    public int whileCounterIt4 = 0;
    public void WhileLoopCounterIt1()
    {
        whileCounterIt1 += 1;
        string whileIt1Count = whileCounterIt1.ToString();

        if ((vehicleType == "Bikes") || (vehicleType == "Planes"))
        {
            whileScreenMadeItem1.text = whileIt1Count;
            Debug.Log("while loop item 1 counter updated " + whileScreenMadeItem1.text);
        }
        else if (vehicleType == "Cars")
        {
            while4ItScreenMadeItem1.text = whileIt1Count;
            Debug.Log("while loop item 1 counter updated " + while4ItScreenMadeItem1.text);
        }
    }

    public void WhileLoopCounterIt2()
    {
        whileCounterIt2 += 1;
        string whileIt2Count = whileCounterIt2.ToString();

        if ((vehicleType == "Bikes") || (vehicleType == "Planes"))
        {
            whileScreenMadeItem2.text = whileIt2Count;
            Debug.Log("while loop item 2 counter updated " + whileScreenMadeItem2.text);
        }
        else if (vehicleType == "Cars")
        {
            while4ItScreenMadeItem2.text = whileIt2Count;
            Debug.Log("while loop item 2 counter updated " + while4ItScreenMadeItem2.text);
        }

    }
    public void WhileLoopCounterIt3()
    {
        whileCounterIt3 += 1;
        string whileIt3Count = whileCounterIt3.ToString();

        if ((vehicleType == "Bikes") || (vehicleType == "Planes"))
        {
            whileScreenMadeItem3.text = whileIt3Count;
            Debug.Log("while loop item 3 counter updated " + whileScreenMadeItem3.text);
        }
        else if (vehicleType == "Cars")
        {
            while4ItScreenMadeItem3.text = whileIt3Count;
            Debug.Log("while loop item 3 counter updated " + while4ItScreenMadeItem3.text);
        }

    }
    public void WhileLoopCounterIt4()
    {
        whileCounterIt4 += 1;
        string whileIt4Count = whileCounterIt4.ToString();
        if (vehicleType == "Cars")
        {
            while4ItScreenMadeItem4.text = whileIt4Count;
            Debug.Log("while loop item 4 counter updated " + while4ItScreenMadeItem4.text);
        }

    }
    public bool CheckProduction()
    {
        if (vehicleType == "Bikes")
        {
            return TryProduce(new[] {
            (whileCounterIt1, (Action<int>)(val => {
                whileCounterIt1 = val;
                whileScreenMadeItem1.text = val.ToString();
            }), whileScreenNeedItem1),

            (whileCounterIt2, (Action<int>)(val => {
                whileCounterIt2 = val;
                whileScreenMadeItem2.text = val.ToString();
            }), whileScreenNeedItem2),

            (whileCounterIt3, (Action<int>)(val => {
                whileCounterIt3 = val;
                whileScreenMadeItem3.text = val.ToString();
            }), whileScreenNeedItem3)
        });
        }
        else if (vehicleType == "Planes")
        {
            return TryProduce(new[] {
            (whileCounterIt1, (Action<int>)(val => {
                whileCounterIt1 = val;
                whileScreenMadeItem1.text = val.ToString();
            }), whileScreenNeedItem1),

            (whileCounterIt2, (Action<int>)(val => {
                whileCounterIt2 = val;
                whileScreenMadeItem2.text = val.ToString();
            }), whileScreenNeedItem2),

            (whileCounterIt3, (Action<int>)(val => {
                whileCounterIt3 = val;
                whileScreenMadeItem3.text = val.ToString();
            }), whileScreenNeedItem3)
        });
        }
        else if (vehicleType == "Cars")
        {
            return TryProduce(new[] {
            (whileCounterIt1, (Action<int>)(val => {
                whileCounterIt1 = val;
                while4ItScreenMadeItem1.text = val.ToString();
            }), while4ItScreenNeedItem1),

            (whileCounterIt2, (Action<int>)(val => {
                whileCounterIt2 = val;
                while4ItScreenMadeItem2.text = val.ToString();
            }), while4ItScreenNeedItem2),

            (whileCounterIt3, (Action<int>)(val => {
                whileCounterIt3 = val;
                while4ItScreenMadeItem3.text = val.ToString();
            }), while4ItScreenNeedItem3),

            (whileCounterIt4, (Action<int>)(val => {
                whileCounterIt4 = val;
                while4ItScreenMadeItem4.text = val.ToString();
            }), while4ItScreenNeedItem4)
        });
        }

        return false;
    }


    // Helper method to reduce repetition
    private bool TryProduce((int counter, Action<int> updateUI, Text need)[] items)
    {
        // Check if all materials are sufficient
        foreach (var (counter, _, need) in items)
        {
            if (counter < int.Parse(need.text))
                return false;
        }

        // Subtract materials and update counters + UI
        for (int i = 0; i < items.Length; i++)
        {
            var (counter, updateUI, need) = items[i];
            int needAmount = int.Parse(need.text);
            counter -= needAmount;
            updateUI(counter); // This will update both the value and UI
            items[i] = (counter, updateUI, need); // update tuple (if needed later)
        }

        SpawnProduct();
        return true;
    }



    //checks if a machine was fully made
    /*
    public bool CheckProduction(){
    if (vehicleType == "Bikes")
    {
        if ((int.Parse(whileScreenMadeItem1.text) >= int.Parse(whileScreenNeedItem1.text)) &&
            (int.Parse(whileScreenMadeItem2.text) >= int.Parse(whileScreenNeedItem2.text)) &&
            (int.Parse(whileScreenMadeItem3.text) >= int.Parse(whileScreenNeedItem3.text)))
        {
            whileScreenMadeItem1.text = (int.Parse(whileScreenMadeItem1.text) - int.Parse(whileScreenNeedItem1.text)).ToString();
            whileScreenMadeItem2.text = (int.Parse(whileScreenMadeItem2.text) - int.Parse(whileScreenNeedItem2.text)).ToString();
            whileScreenMadeItem3.text = (int.Parse(whileScreenMadeItem3.text) - int.Parse(whileScreenNeedItem3.text)).ToString();
            SpawnProduct();
            return true;
        }
        else
        {
            return false;
        }
    }
    else if (vehicleType == "Planes")
    {
 if ((int.Parse(whileScreenMadeItem1.text) >= int.Parse(whileScreenNeedItem1.text)) &&
            (int.Parse(whileScreenMadeItem2.text) >= int.Parse(whileScreenNeedItem2.text)) &&
            (int.Parse(whileScreenMadeItem3.text) >= int.Parse(whileScreenNeedItem3.text)))
        {
            whileScreenMadeItem1.text = (int.Parse(whileScreenMadeItem1.text) - int.Parse(whileScreenNeedItem1.text)).ToString();
            whileScreenMadeItem2.text = (int.Parse(whileScreenMadeItem2.text) - int.Parse(whileScreenNeedItem2.text)).ToString();
            whileScreenMadeItem3.text = (int.Parse(whileScreenMadeItem3.text) - int.Parse(whileScreenNeedItem3.text)).ToString();
            SpawnProduct();
            return true;
        }
        else
        {
            return false;
        }
    }
    else if (vehicleType == "Cars")
    {
        if ((int.Parse(while4ItScreenMadeItem1.text) >= int.Parse(while4ItScreenNeedItem1.text)) &&
            (int.Parse(while4ItScreenMadeItem2.text) >= int.Parse(while4ItScreenNeedItem2.text)) &&
            (int.Parse(while4ItScreenMadeItem3.text) >= int.Parse(while4ItScreenNeedItem3.text)) &&
            (int.Parse(while4ItScreenMadeItem4.text) >= int.Parse(while4ItScreenNeedItem4.text)))
        {
            while4ItScreenMadeItem1.text = (int.Parse(while4ItScreenMadeItem1.text) - int.Parse(while4ItScreenNeedItem1.text)).ToString();
            while4ItScreenMadeItem2.text = (int.Parse(while4ItScreenMadeItem2.text) - int.Parse(while4ItScreenNeedItem2.text)).ToString();
            while4ItScreenMadeItem3.text = (int.Parse(while4ItScreenMadeItem3.text) - int.Parse(while4ItScreenNeedItem3.text)).ToString();
            while4ItScreenMadeItem4.text = (int.Parse(while4ItScreenMadeItem4.text) - int.Parse(while4ItScreenNeedItem4.text)).ToString();
            SpawnProduct();
            return true;
        }
        else
        {
            return false;
        }
    }
    return false;
}
*/

    public bool CheckIfMaterial(string material)
    {
        if (vehicleType == "Bikes")
        {
            if (material == "BikeChassis") { WhileLoopCounterIt1(); return true; }
            else if (material == "Engine") { WhileLoopCounterIt2(); return true; }
            else if (material == "Tire") { WhileLoopCounterIt3(); return true; }
        }
        else if (vehicleType == "Planes")
        {
            if (material == "PlaneWings") { WhileLoopCounterIt1(); return true; }
            else if (material == "Turbine") { WhileLoopCounterIt2(); return true; }
            else if (material == "Tire") { WhileLoopCounterIt3(); return true; }
        }
        else if (vehicleType == "Cars")
        {
            if (material == "CarChassis") { WhileLoopCounterIt1(); return true; }
            else if (material == "CarDoor") { WhileLoopCounterIt2(); return true; }
            else if (material == "Engine") { WhileLoopCounterIt3(); return true; }
            else if (material == "Tire") { WhileLoopCounterIt4(); return true; }
        }

        // ❌ No matching material found for the current vehicle type
        return false;
    }

    public void SpawnProduct()
    {
        GameObject prefabToSpawn = null;
        string vehicle = vehicleType;

        switch (vehicle)
        {
            case "Bikes":
                prefabToSpawn = bikePrefab;
                break;
            case "Planes":
                prefabToSpawn = planePrefab;
                break;
            case "Cars":
                prefabToSpawn = carPrefab;
                break;
            default:
                Debug.LogWarning("Unknown vehicle type: " + vehicleType);
                return;
        }
        GameObject newItem = spawner.SpawnItem(prefabToSpawn);
        if (newItem != null)
        {
            ConveyorItem itemData = newItem.GetComponent<ConveyorItem>();
            if (itemData != null)
            {
                itemData.isCrafted = true;
                itemData.itemType = (ItemType)Enum.Parse(typeof(ItemType), vehicleType); // Optional, unless u wanna play with item types
            }
        }
    }

    //Checdks if the round is done
    public void CheckIfRoundIsOver()
    {
        if (int.Parse(forScreenMade.text) == int.Parse(forScreenNeed.text))
        {
            //calls exit screen
            roundOverScreen.SetActive(true);
        }
    }

    public void PlayerDiedScreen()
    {
        roundLostScreen.SetActive(true);
    }

    public void WhileLoopBroke()
    {
        whileLoopBroken.SetActive(true);
        whileSign.SetActive(false);
        whileSignText.SetActive(false);

    }

    public void WhileLoopFixed()
    {
        whileLoopBroken.SetActive(false);
        whileSign.SetActive(true);
        whileSignText.SetActive(true);
    }

}
