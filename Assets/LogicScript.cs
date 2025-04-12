using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Random = UnityEngine.Random;

public class LogicScript : MonoBehaviour
{
    public int totalVehicles; //goal for player to make
    public int vehicleIndex; //array index to choose vehicle
    public string vehicleType; 

    public string objective;
    //References to drag objects within unity
    public GameObject gameCharacter; 
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //public AudioSource ; add in audio

    AudioManager audioManager;

    private void Awake()
    {
        //audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        UpdateObjective();
    }


    public string[] vehicles;

    //Making the objectives
    public void UpdateObjective(){

        totalVehicles = Random.Range(2, 5); // to get 2-4
        //Debug.Log(totalVehicles);

        vehicleIndex = Random.Range(0, 3); // to get 0-2
        //Debug.Log(vehicleIndex); 
        vehicleType = vehicles[vehicleIndex];
        //Debug.Log(vehicleType);

        string strTotVehicle= totalVehicles.ToString();
        objective = strTotVehicle + " " + vehicleType;
        //Debug.Log(objective);

        objectiveText.text = objective; //Updates Object Screen

        //For screen Need vehicles set
        forScreenNeed.text = strTotVehicle;

        //Check what vehicle it is and set needed accordingly
        if(vehicleType == "Cars"){
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
        else if(vehicleType == "Bikes"){
            WhileLoop3Items.SetActive(true);
            WhileLoop4Items.SetActive(false);
            
            BikesImageSet.SetActive(true);
            PlanesImageSet.SetActive(false);
            CarsImageSet.SetActive(false);

            whileScreenNeedItem1.text = "1"; // Chasis
            whileScreenNeedItem2.text = "1"; // Engine
            whileScreenNeedItem3.text = "2"; // Wheels

        }
        else if(vehicleType == "Planes"){
            WhileLoop3Items.SetActive(false);
            WhileLoop4Items.SetActive(true);

            BikesImageSet.SetActive(false);
            PlanesImageSet.SetActive(true);
            CarsImageSet.SetActive(false);

            while4ItScreenNeedItem1.text = "1"; //Engine
            while4ItScreenNeedItem2.text = "3"; //Plane Wings
            while4ItScreenNeedItem3.text = "2"; //Turbine
            while4ItScreenNeedItem4.text = "2"; //Wheels
        }
    }

    //Increase For Loop Count
    public void ForLoopCounter(){

    }


    //Increase while loop counter
    public void WhileLoopCounter(){


    }

    //checks if a machine was fully made
    public void CheckProduction(){

    }


}
