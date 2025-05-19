using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class TrashScript : MonoBehaviour
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        ConveyorItem item = other.GetComponent<ConveyorItem>();
        if (item != null)
        {
            Debug.Log($"✅ Detected item Trashed : {item.itemType}");
            itemsInZone.Add(item);
            item.gameObject.SetActive(false); // Hide, but keep tracking

            PlayerPickup pickup = FindFirstObjectByType<PlayerPickup>();
            if (pickup != null)
            {
                pickup.ForceDropHeldItem(item.gameObject);
            }

            // ✅ Reward stamina
            PlayerMovement player = FindFirstObjectByType<PlayerMovement>();
            if (player != null)
            {
                player.BoostStamina(2f); // Boost amount can be adjusted
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
    }}
