using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    [Range(0, 1)]
    [SerializeField] private float lerpValue = 0f;

    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Transform item;
    [SerializeField] private float speed = 0.2f; // How fast the item moves along the belt

    void Update()
    {
        if (item == null || lineRenderer == null || lineRenderer.positionCount < 2)
            return;

        lerpValue += speed * Time.deltaTime;
        lerpValue = Mathf.Clamp01(lerpValue); // stops at the end for now

        item.transform.position = Vector3.Lerp(
            lineRenderer.GetPosition(0),
            lineRenderer.GetPosition(1),
            lerpValue
        );
    }
}
