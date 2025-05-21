using UnityEngine;
using System;

public class PlayerPickup : MonoBehaviour
{
    public KeyCode pickupKey = KeyCode.E;
    public float pickupRange = 3f;
    public LayerMask itemLayer;
    public Transform holdPoint;
    public AudioManager audioManager;
    private GameObject carriedItem;
    private GameObject highlightedItem = null;
    private Color originalColor;
    public LineRenderer[] conveyorPaths;
    public LineRenderer forBelt;
    public LineRenderer whileBelt;
    private readonly string[] allowedCraftedTags = { "Bike", "Plane", "Car" };

    void Update()
    {
        HighlightNearestItem();

        if (Input.GetKeyDown(pickupKey))
        {
            if (carriedItem == null)
                TryPickup();
            else
                DropItem();
        }

    }

    void TryPickup()
    {
        if (highlightedItem != null && highlightedItem.CompareTag("ConveyorItem"))
        {
            carriedItem = highlightedItem;

            Rigidbody2D rb = carriedItem.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
                rb.angularVelocity = 0;
                rb.bodyType = RigidbodyType2D.Kinematic;
            }

            carriedItem.transform.SetParent(holdPoint);
            carriedItem.transform.localPosition = Vector3.zero;
            carriedItem.transform.localRotation = Quaternion.identity;

            FollowConveyorPath followScript = carriedItem.GetComponent<FollowConveyorPath>();
            if (followScript != null)
            {
                followScript.enabled = false;
            }

            SpriteRenderer sr = highlightedItem.GetComponent<SpriteRenderer>();
            if (sr != null) sr.color = originalColor;

            highlightedItem = null;

            if (audioManager != null)
                audioManager.PlaySFX(audioManager.pickup);

            Debug.Log("Picked up: " + carriedItem.name);
        }
        else
        {
            Debug.Log("No highlighted item to pick up");
        }
    }

    public void ForceDropHeldItem(GameObject item)
    {
        if (carriedItem == item)
            carriedItem = null;
    }

    void DropItem()
    {
        if (carriedItem)
        {
            FollowConveyorPath followScript = carriedItem.GetComponent<FollowConveyorPath>();
            ConveyorItem itemData = carriedItem.GetComponent<ConveyorItem>();
            LineRenderer nearestBelt = FindClosestConveyor();

            // 🧪 Debug info
            Debug.Log($"🧪 Dropping item: {carriedItem.name}, isCrafted: {itemData?.isCrafted}");

            // 🚫 Block uncrafted items from the for belt
            if (nearestBelt == forBelt && itemData != null && !itemData.isCrafted)
            {
                Debug.Log("⛔ Cannot place uncrafted item on the for belt!");

                HelperBotThinking helperBot = FindFirstObjectByType<HelperBotThinking>();
                if (helperBot != null)
                    helperBot.ShowThought("You need to craft that first!");

                return; // keep holding the item
            }

            // ✅ Passed checks — drop the item
            carriedItem.transform.SetParent(null);

            Rigidbody2D rb = carriedItem.GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.bodyType = RigidbodyType2D.Dynamic;

            if (followScript != null)
            {
                followScript.enabled = false;

                if (nearestBelt != null)
                    followScript.SetPath(nearestBelt);

                followScript.enabled = true;
            }

            if (audioManager != null)
                audioManager.PlaySFX(audioManager.drop);

            Debug.Log("Dropped: " + carriedItem.name);
            carriedItem = null;
            
            if (nearestBelt == whileBelt && itemData != null && !itemData.isCrafted)
            {
                Debug.Log("⛔ Cannot place uncrafted item on the while belt!");

                HelperBotThinking helperBot = FindFirstObjectByType<HelperBotThinking>();
                if (helperBot != null)
                    helperBot.ShowThought("Wrong item in processor!");

                return; // keep holding the item
            }
            
        }
    }


    void HighlightNearestItem()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, pickupRange, itemLayer);

        float closestDistance = Mathf.Infinity;
        GameObject nearest = null;

        foreach (Collider2D hit in hits)
        {
            float dist = Vector2.Distance(transform.position, hit.transform.position);
            if (dist < closestDistance)
            {
                closestDistance = dist;
                nearest = hit.gameObject;
            }
        }

        if (highlightedItem != null && highlightedItem != nearest)
        {
            SpriteRenderer sr = highlightedItem.GetComponent<SpriteRenderer>();
            if (sr != null) sr.color = originalColor;
            highlightedItem = null;
        }

        if (nearest != null && nearest != carriedItem)
        {
            SpriteRenderer sr = nearest.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                if (highlightedItem != nearest)
                {
                    originalColor = sr.color;
                    sr.color = new Color(1f, 0.2f, 0.2f); // red highlight
                    highlightedItem = nearest;
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, pickupRange);
    }

    LineRenderer FindClosestConveyor()
    {
        float closestDist = Mathf.Infinity;
        LineRenderer closest = null;

        foreach (var path in conveyorPaths)
        {
            for (int i = 0; i < path.positionCount; i++)
            {
                float dist = Vector3.Distance(transform.position, path.GetPosition(i));
                if (dist < closestDist)
                {
                    closestDist = dist;
                    closest = path;
                }
            }
        }

        return closest;
    }
}