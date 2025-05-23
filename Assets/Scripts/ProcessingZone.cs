using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using System.Linq;
using System.Threading.Tasks;


public class ProcessingZone : MonoBehaviour
{

    //public GameObject roundOverScreen;

    public bool isBroken = false;
    public bool canProcess = true;
    public Animator processorAnimator;

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

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
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
    private async Task OnTriggerEnter2D(Collider2D other)
    {

        ConveyorItem item = other.GetComponent<ConveyorItem>();
        if (item == null) return;

        // 🔁 Add to list regardless of canProcess
        if (!itemsInZone.Contains(item))
            itemsInZone.Add(item);

        if (!canProcess)
        {
            Debug.Log("🚫 Processor is currently disabled.");
            return;
        }
        Debug.Log("🎯 Processor received something.");

        
        if (item == null)
        {
            Debug.Log($"❌ Not a valid item: {other.name}");
            return;
        }

        string[] allowedFinalProducts = { "Bike", "Car", "Plane" };

        if (allowedFinalProducts.Contains(item.itemType.ToString()))
        {
            Debug.Log($"↪️ Final product passed through: {item.itemType}");
            return;
        }

        Debug.Log($"✅ Detected item: {item.itemType}");
        itemsInZone.Add(item);
        item.gameObject.SetActive(false); // Hide visually
        audioManager.PlaySFX(audioManager.correctPart);
        //item.gameObject.SetActive(false); // Hide visually

        

        // ✅ Check if it’s a valid ingredient for the current recipe
        //bool isValid = recipes.Any(recipe => recipe.ingredients.Any(ingredient => ingredient.itemType == item.itemType));
        bool isValid = logic.CheckIfMaterial(item.itemType.ToString());

        if (!isValid)
        {   HelperBotThinking helperBot = FindFirstObjectByType<HelperBotThinking>();
            Destroy(item.gameObject);
            canProcess = false;
            logic.WhileLoopBroke();
            BreakProcessor();
            Debug.Log("❌ Not part of recipe — losing a heart");
            
            //HelperBotThinking helperBot = FindFirstObjectByType<HelperBotThinking>();
            if (helperBot != null)
            {
                helperBot.ShowThoughtLonger("Wrong Item! Remember while loops only repeatedly accepts correct items. Item broke the belt, hold Q for 4 seconds to fix loop. ");
            }
            FindFirstObjectByType<HealthManager>()?.LoseHeart();
        }
        else
        {
            bool wasCrafted = logic.CheckProduction();
            if (wasCrafted)
            {
                audioManager.PlaySFX(audioManager.itemSuccessfullyCrafted);
                Debug.Log("🎉 A vehicle was crafted!");
            }

        }

    }
    

    public void BreakProcessor()
    {
        if (!canProcess) return; // Already disabled

        canProcess = false;
        //processorAnimator?.SetTrigger("Broken");
        Debug.Log("💥 BreakProcessor() called — Processor is now disabled.");
    }

    public void FixProcessor()
    {
        canProcess = true;
        //processorAnimator?.SetTrigger("Fixed");
        Debug.Log("✅ Processor is re-enabled!");
        
    }
    
    /*
        private void OnTriggerEnter2D(Collider2D other)
        {
            ConveyorItem item = other.GetComponent<ConveyorItem>();
            if (item != null)
            {
                Debug.Log($"✅ Detected item: {item.itemType}");
                itemsInZone.Add(item);
                item.gameObject.SetActive(false); // Hide, but keep tracking
                logic.CheckIfMaterial(item.itemType.ToString());
                bool wasProduced = logic.CheckProduction();
                /*if(wasProduced == true){
                    roundOverScreen.SetActive(true);
                }
                //TryCraft();
            }
            else
            {
                Debug.Log($"❌ Not a valid item: {other.name}");
            }
        }
    */
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