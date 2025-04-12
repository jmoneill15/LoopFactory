using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LogicScript : MonoBehaviour
{
    public int totalVehicles; //goal for player to make
    public string vehicleType; 

    public string objective;

    public GameObject gameCharacter; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //public AudioSource ; add in audio

    AudioManager audioManager;

    private void Awake()
    {
        //audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string[] vehicles;
}
