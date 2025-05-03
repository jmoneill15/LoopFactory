using UnityEngine;
using TMPro;
using System.Collections;
using System.Linq;
public class ItemSpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    public GameObject[] itemPrefabs; // Array of different item prefabs
    public LineRenderer conveyorPath;

    public float spawnDelay = 4f;
    private float timer;

    private float fullTimer = 0f;
    private bool isFull = false;
    public float timeBeforePenalty = 20f;

    public HealthManager healthManager; // Assign in Inspector
    public int maxItemsOnBelt = 10; 

    public TextMeshProUGUI conveyorTimerText;
    public GameObject conveyorTimerPanel;

    private Coroutine blinkCoroutine;
    private bool isBlinking = false;

    public LogicScript logic;


    void Awake()
    {
        if (conveyorTimerPanel != null)
            conveyorTimerPanel.SetActive(false);
        logic.timerBackground.SetActive(false);
    }

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        timer = spawnDelay;

        if (conveyorTimerText != null)
            conveyorTimerText.text = "";

        if (conveyorTimerPanel != null)
            conveyorTimerPanel.SetActive(false);

        logic.timerBackground.SetActive(false);
    }

    IEnumerator BlinkText()
    {
        isBlinking = true;
        while (isFull && conveyorTimerText != null)
        {
            conveyorTimerText.color = Color.red;
            yield return new WaitForSeconds(0.6f);
            conveyorTimerText.color = Color.black;
            yield return new WaitForSeconds(0.6f);
        }
        isBlinking = false;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        int currentItemCount = FollowConveyorPath.activeItems.Where(i => i != null && i.path == this.conveyorPath).Count();
        bool isActuallyFull = currentItemCount >= maxItemsOnBelt;

        if (!isActuallyFull)
        {
            if (timer <= 0f)
            {
                SpawnRandomItem();
                timer = spawnDelay;
            }

            // ✅ Reset when belt has space
            if (isFull)
            {
                isFull = false;
                fullTimer = 0f;

                if (conveyorTimerText != null)
                    conveyorTimerText.text = "";

                if (blinkCoroutine != null)
                {
                    StopCoroutine(blinkCoroutine);
                    blinkCoroutine = null;
                    conveyorTimerText.color = Color.black;
                    conveyorTimerText.color = Color.red;
                }

                logic.timerBackground.SetActive(false);
            }
        }
        else
        {
            // 🚨 Belt is full
            if (!isFull)
            {
                isFull = true;
                fullTimer = timeBeforePenalty;

                if (!isBlinking && conveyorTimerText != null)
                    blinkCoroutine = StartCoroutine(BlinkText());

                logic.timerBackground.SetActive(true);
            }
            else
            {
                fullTimer -= Time.deltaTime;

                if (conveyorTimerText != null)
                    conveyorTimerText.text = $"CLEAR SPACE! {Mathf.CeilToInt(fullTimer)}s LEFT!";

                if (fullTimer <= 0f)
                {
                    FindFirstObjectByType<HealthManager>()?.LoseHeart();
                    ClearAllItems();

                    fullTimer = 0f;
                    timer = spawnDelay;
                    isFull = false;

                    if (conveyorTimerText != null)
                        conveyorTimerText.text = "";

                    if (blinkCoroutine != null)
                    {
                        StopCoroutine(blinkCoroutine);
                        blinkCoroutine = null;
                        conveyorTimerText.color = Color.white;
                    }

                    logic.timerBackground.SetActive(false);
                }
            }

            // Retry spawn if blocked
            if (timer <= 0f)
                timer = 0.2f;
        }
    }

    void ClearAllItems()
    {
        GameObject[] items = GameObject.FindGameObjectsWithTag("ConveyorItem");
        foreach (GameObject item in items)
        {
            Destroy(item);
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

    // private bool IsSpaceAvailable()
    // {
    //     if (itemPrefabs.Length == 0 || conveyorPath == null)
    //         return false;

    //     Vector3 spawnPos = conveyorPath.GetPosition(0);
    //     float safeSpacing = 1.5f;

    //     foreach (var item in FollowConveyorPath.activeItems)
    //     {
    //         if (item == null || item.gameObject == null || !item.gameObject.activeInHierarchy)
    //             continue;

    //         float dist = Vector3.Distance(item.transform.position, spawnPos);
    //         if (dist < safeSpacing)
    //             return false;
    //     }

    //     return true;
    // }


}