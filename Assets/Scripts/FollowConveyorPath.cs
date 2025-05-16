using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class FollowConveyorPath : MonoBehaviour
{
    public static List<FollowConveyorPath> activeItems = new List<FollowConveyorPath>();

    public LineRenderer path; // 👈 Make it public so other scripts can access it

    private int currentSegment = 0;
    private float t = 0f;

    public float speed = 2f;
    public float spacing = 1f;

    public void SetPath(LineRenderer line)
    {
        path = line; // 👈 Store path reference for later comparison

        // Find closest segment on the path to where the item is now
        float closestT = 0f;
        int closestSegment = 0;
        float closestDistance = Mathf.Infinity;

        for (int i = 0; i < path.positionCount - 1; i++)
        {
            Vector3 a = path.GetPosition(i);
            Vector3 b = path.GetPosition(i + 1);

            Vector3 projected = ProjectPointOnLineSegment(a, b, transform.position);
            float distance = Vector3.Distance(transform.position, projected);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestSegment = i;

                float segmentLength = Vector3.Distance(a, b);
                closestT = segmentLength > 0f ? Vector3.Distance(a, projected) / segmentLength : 0f;
            }
        }

        currentSegment = closestSegment;
        t = closestT;
    }

    private Vector3 ProjectPointOnLineSegment(Vector3 a, Vector3 b, Vector3 point)
    {
        Vector3 ab = b - a;
        float abSquared = Vector3.Dot(ab, ab);
        if (abSquared == 0f) return a;

        float t = Vector3.Dot(point - a, ab) / abSquared;
        t = Mathf.Clamp01(t);
        return a + ab * t;
    }

    void OnEnable()
    {
        activeItems.Add(this);
    }

    void OnDisable()
    {
        activeItems.Remove(this);
    }

    void Update()
    {
        if (path == null || currentSegment >= path.positionCount - 1)
            return;

        if (IsAnotherItemTooCloseAhead())
            return;

        Vector3 start = path.GetPosition(currentSegment);
        Vector3 end = path.GetPosition(currentSegment + 1);
        float segmentLength = Vector3.Distance(start, end);

        float step = speed * Time.deltaTime / segmentLength;
        t += step;
        t = Mathf.Clamp01(t);

        transform.position = Vector3.Lerp(start, end, t);

        if (t >= 1f)
        {
            currentSegment++;
            t = 0f;
        }
    }

    bool IsAnotherItemTooCloseAhead()
    {
        foreach (var other in activeItems)
        {
            if (other == this || other.path != this.path)
                continue;

            float myDist = GetGlobalPathDistance();
            float theirDist = other.GetGlobalPathDistance();

            if (theirDist > myDist && theirDist - myDist < spacing)
                return true;
        }
        return false;
    }

    float GetGlobalPathDistance()
    {
        float total = 0f;
        for (int i = 0; i < currentSegment; i++)
        {
            total += Vector3.Distance(path.GetPosition(i), path.GetPosition(i + 1));
        }
        total += Vector3.Distance(path.GetPosition(currentSegment), transform.position);
        return total;
    }
}