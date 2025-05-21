using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Random = UnityEngine.Random;
using NUnit.Framework;

public class LogicScriptTut : MonoBehaviour
{
    public int totalVehicles; //goal for player to make
    public string vehicleType;

    public string objective;
    //References to drag objects within unity
    public GameObject gameCharacter;
    public GameObject roundOverScreen;

    public GameObject roundLostScreen;

    public GameObject tutorialIntroScreen;
    public GameObject WhileLoop3Items;

    public GameObject BikesImageSet;


    public Text objectiveText; //players objective

    //While Loop Screen with 3 items
    public Text whileScreenMadeItem1;
    public Text whileScreenNeedItem1;

    public Text whileScreenMadeItem2;
    public Text whileScreenNeedItem2;
    public Text whileScreenMadeItem3;
    public Text whileScreenNeedItem3;


    //For Loop Screen Totals
    public Text forScreenMade;
    public Text forScreenNeed;
    public ManualItemSpawner spawner;

    [Header("Vehicle Prefabs")]
    public GameObject bikePrefab;

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

        totalVehicles = 1;
        //Debug.Log(totalVehicles);

        //Debug.Log(vehicleIndex); 
        vehicleType = "Bike";
        //Debug.Log(vehicleType);

        string strTotVehicle = totalVehicles.ToString();
        objective = strTotVehicle + " " + vehicleType;
        //Debug.Log(objective);

        objectiveText.text = objective; //Updates Object Screen

        //For screen Need vehicles set
        forScreenNeed.text = strTotVehicle;

        if (vehicleType == "Bike")
        {
            whileScreenNeedItem1.text = "1"; // Chasis
            whileScreenNeedItem2.text = "1"; // Engine
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
    public void WhileLoopCounterIt1()
    {
        whileCounterIt1 += 1;
        string whileIt1Count = whileCounterIt1.ToString();

        if (vehicleType == "Bike")
        {
            whileScreenMadeItem1.text = whileIt1Count;
            Debug.Log("while loop item 1 counter updated " + whileScreenMadeItem1.text);
        }
    }

    public void WhileLoopCounterIt2()
    {
        whileCounterIt2 += 1;
        string whileIt2Count = whileCounterIt2.ToString();

        if (vehicleType == "Bike")
        {
            whileScreenMadeItem2.text = whileIt2Count;
            Debug.Log("while loop item 2 counter updated " + whileScreenMadeItem2.text);
        }

    }
    public void WhileLoopCounterIt3()
    {
        whileCounterIt3 += 1;
        string whileIt3Count = whileCounterIt3.ToString();

        if (vehicleType == "Bike")
        {
            whileScreenMadeItem3.text = whileIt3Count;
            Debug.Log("while loop item 3 counter updated " + whileScreenMadeItem3.text);
        }

    }
    public bool CheckProduction()
    {
        if (vehicleType == "Bike")
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



    public void CheckIfMaterial(string material)
    {
        if (vehicleType == "Bike")
        {
            if (material == "BikeChassis")
            {
                WhileLoopCounterIt1();
            }
            else if (material == "Engine")
            {
                WhileLoopCounterIt2();
            }
            else if (material == "Tire")
            {
                WhileLoopCounterIt3();
            }

        }
    }

    public void SpawnProduct()
    {
        GameObject prefabToSpawn = null;
        string vehicle = vehicleType;

        switch (vehicle)
        {
            case "Bike":
                prefabToSpawn = bikePrefab;
                break;

            default:
                Debug.LogWarning("Unknown vehicle type: " + vehicleType);
                return;
        }
        spawner.SpawnItem(prefabToSpawn);

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

    public void StartTutorial()
    {
        tutorialIntroScreen.SetActive(false);
        //Debug.Log("Closed intro screen");
    }

    public void ResetTutorialIntro()
    {
        tutorialIntroScreen.SetActive(true);
    }

    public void PlayerDiedScreen()
    {
        roundLostScreen.SetActive(true); 
    }

}
