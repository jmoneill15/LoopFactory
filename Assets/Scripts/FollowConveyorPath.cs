using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class FollowConveyorPath : MonoBehaviour
{
    public static List<FollowConveyorPath> activeItems = new List<FollowConveyorPath>();

    private LineRenderer path;
    private int currentSegment = 0;
    private float t = 0f;

    public float speed = 2f;
    public float spacing = 1f;

    public void SetPath(LineRenderer line)
    {
        path = line;
        transform.position = path.GetPosition(0);
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