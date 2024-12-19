using UnityEngine;

public class SpatialTrackingModel
{
    public Transform SpatialTrackingTarget { get; private set; }

    public void CreateOrMoveSpatialTrackingTarget(Vector3 position)
    {
        if (SpatialTrackingTarget == null)
        {
            // Create a new spatial tracking target
            GameObject targetObject = new GameObject("SpatialTrackingTarget");
            SpatialTrackingTarget = targetObject.transform;
        }

        SpatialTrackingTarget.position = position;
    }

    public Vector3 GetSpawnPositionWithSpatialTracking()
    {
        if (SpatialTrackingTarget != null)
        {
            return SpatialTrackingTarget.position;
        }

        // Default fallback position if no tracking target is set
        return Vector3.zero;
    }
}
