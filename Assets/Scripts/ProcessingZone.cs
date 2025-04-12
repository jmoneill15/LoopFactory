using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class ProcessingZone : MonoBehaviour
{
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

    public LogicScript logic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ConveyorItem item = other.GetComponent<ConveyorItem>();
        if (item != null)
        {
            Debug.Log($"✅ Detected item: {item.itemType}");
            itemsInZone.Add(item);
            item.gameObject.SetActive(false); // Hide, but keep tracking
            logic.CheckIfMaterial(item.itemType.ToString());
            logic.CheckProduction();
            //TryCraft();
        }
        else
        {
            Debug.Log($"❌ Not a valid item: {other.name}");
        }
    }

   /* void TryCraft()
    {
        Dictionary<ItemType, int> inventory = new Dictionary<ItemType, int>();

        foreach (var item in itemsInZone)
        {
            if (!inventory.ContainsKey(item.itemType))
                inventory[item.itemType] = 0;

            inventory[item.itemType]++;
        }

        foreach (var recipe in recipes)
        {
            if (MatchesRecipe(inventory, recipe))
            {
                List<ConveyorItem> matchedItems = ConsumeItems(recipe);

                // Spawn the crafted product
                GameObject product = Instantiate(recipe.resultPrefab, transform.position, Quaternion.identity);

                // Attach it to conveyor path
                FollowConveyorPath path = product.GetComponent<FollowConveyorPath>();
                if (path != null && outputPath != null)
                {
                    path.SetPath(outputPath);
                }
                else
                {
                    Debug.LogWarning("⚠️ Crafted object missing FollowConveyorPath or outputPath not assigned.");
                }

                Debug.Log($"✅ Crafted: {recipe.name}");
                return;
            }
        }
    }*/

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