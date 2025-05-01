using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using System.Linq;


public class ProcessingZoneTut : MonoBehaviour
{

    //public GameObject roundOverScreen;

    [System.Serializable]
    public class RecipeIngredient
    {
        public ItemType itemType;
        public int count;
    }

    [System.Serializable]
    public class Recipe
    {
        public string name;
        public List<RecipeIngredient> ingredients = new List<RecipeIngredient>();
        public GameObject resultPrefab;
    }

    public List<Recipe> recipes = new List<Recipe>(); // Set up in Inspector
    private List<ConveyorItem> itemsInZone = new List<ConveyorItem>();

    public LineRenderer outputPath; // Assign in inspector for output conveyor

    public LogicScriptTut logic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScriptTut>();
    }
 private void OnTriggerEnter2D(Collider2D other)
{
    ConveyorItem item = other.GetComponent<ConveyorItem>();
    if (item == null)
    {
        Debug.Log($"❌ Not a valid item: {other.name}");
        return;
    }

    string[] allowedTypes = { "Bike"};

        if (!allowedTypes.Contains(item.itemType.ToString()))
        {
            Debug.Log($"✅ Detected item: {item.itemType}");
            itemsInZone.Add(item);
            item.gameObject.SetActive(false); // Hide, but keep tracking
            logic.CheckIfMaterial(item.itemType.ToString());
            bool wasProduced = logic.CheckProduction();
/*
            if (!wasProduced)
            {
                Debug.Log("❌ Wrong item entered — deducting health.");
                //FindFirstObjectByType<HealthManager>()?.LoseHeart();
            }
            */
        }
        else
    {
        // Let allowed items pass through
        Debug.Log($"↪️ Allowed item passed through: {item.itemType}");
        itemsInZone.Add(item);
        item.gameObject.SetActive(true); // Optionally, leave it active
        logic.CheckIfMaterial(item.itemType.ToString());
    }
}


    public bool MatchesRecipe(Dictionary<ItemType, int> inventory, Recipe recipe)
    {
        foreach (var ingredient in recipe.ingredients)
        {
            if (!inventory.ContainsKey(ingredient.itemType) || inventory[ingredient.itemType] < ingredient.count)
                return false;
        }
        return true;
    }

    List<ConveyorItem> ConsumeItems(Recipe recipe)
    {
        List<ConveyorItem> removed = new List<ConveyorItem>();

        foreach (var ingredient in recipe.ingredients)
        {
            int toRemove = ingredient.count;
            for (int i = itemsInZone.Count - 1; i >= 0 && toRemove > 0; i--)
            {
                if (itemsInZone[i].itemType == ingredient.itemType)
                {
                    removed.Add(itemsInZone[i]);
                    Destroy(itemsInZone[i].gameObject);
                    itemsInZone.RemoveAt(i);
                    toRemove--;
                }
            }
        }

        return removed;
    }
}
