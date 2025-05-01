using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TutorialManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public LogicScriptTut logic;

    public GameObject[] popUps;
    private int popUpIndex;

    public ItemSpawnerTut spawner;
    //private float quickInputDelay = 1.0f;
    //private float slowInputDelay = 3.0f;
    private float lastInputTime = 0f;
    private float inputDelay = 3.0f;
    private bool eWasReleased = false;


    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScriptTut>();
        logic.ResetTutorialIntro();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            popUps[i].SetActive(i == popUpIndex);
        }

        // Don't process input if we're still within delay time
        if (Time.time - lastInputTime < inputDelay)
            return;

        if (popUpIndex == 0)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) ||
                Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                popUpIndex++;
                lastInputTime = Time.time;
                Debug.Log(popUpIndex);
            }
        }
        else if (popUpIndex == 1)
        {
            spawner.SpawnSingleItem();
            popUpIndex++;
            lastInputTime = Time.time;
        }
       else if (popUpIndex == 2)
{
    if (!Input.GetKey(KeyCode.E))
    {
        eWasReleased = true; // Player has released E
    }

    if (eWasReleased && Input.GetKeyDown(KeyCode.E))
    {
        popUpIndex++;
        lastInputTime = Time.time;
        eWasReleased = false;
        Debug.Log(popUpIndex);
    }
}

        else if (popUpIndex == 3)
        {
            spawner.SpawnSingleItem();
            popUpIndex++;
            lastInputTime = Time.time;
        }
else if (popUpIndex == 4)
{
    if (!Input.GetKey(KeyCode.E))
    {
        eWasReleased = true;
    }

    if (eWasReleased && Input.GetKeyDown(KeyCode.E))
    {
        popUpIndex++;
        lastInputTime = Time.time;
        eWasReleased = false;
        Debug.Log(popUpIndex);
    }
}

        else if (popUpIndex == 5)
        {
            spawner.SpawnSingleItem();
            popUpIndex++;
            lastInputTime = Time.time;
            Debug.Log(popUpIndex);
        }
    }


}
