using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using System.Linq;
using NUnit.Framework;

public class PackingZoneTut : MonoBehaviour
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



    if (item != null)
    {
        string itemName = item.itemType.ToString();

        // ✅ Allow only items matching the current vehicle type
        if (itemName == "Bike") 
        {
            Debug.Log($"✅ Correct item for {logic.vehicleType}: {itemName}");
            itemsInZone.Add(item);
            item.gameObject.SetActive(false); // Hide, but keep tracking
            logic.ForLoopCounter();
            logic.CheckIfRoundIsOver();
        }
        else
        {
            Debug.Log($"❌ Wrong item: {itemName} is not for {logic.vehicleType}");
        }
    }
    else
    {
        Debug.Log($"❌ Not a valid item: {other.name}");
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
