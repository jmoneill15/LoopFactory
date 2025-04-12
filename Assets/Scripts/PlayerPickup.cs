using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public KeyCode pickupKey = KeyCode.E;
    public float pickupRange = 3f;
    public LayerMask itemLayer;
    public Transform holdPoint;

    private GameObject carriedItem;
    private GameObject highlightedItem = null;
    private Color originalColor;
    public LineRenderer[] conveyorPaths;

    void Update()
    {
        if (Input.GetKeyDown(pickupKey))
        {
            if (carriedItem == null)
                TryPickup();
            else
                DropItem();
        }

        HighlightNearestItem();
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
           

            Debug.Log("Picked up: " + carriedItem.name);
        }
        else
        {
            Debug.Log("No highlighted item to pick up");
        }
    }

    void DropItem()
    {
        if (carriedItem)
        {
            carriedItem.transform.SetParent(null);

            Rigidbody2D rb = carriedItem.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
            }

            FollowConveyorPath followScript = carriedItem.GetComponent<FollowConveyorPath>();
            if (followScript != null)
            {
                followScript.enabled = false;

                LineRenderer nearestBelt = FindClosestConveyor();
                if (nearestBelt != null)
                    followScript.SetPath(nearestBelt);

                followScript.enabled = true;
            }

            Debug.Log("Dropped: " + carriedItem.name);
            carriedItem = null;
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