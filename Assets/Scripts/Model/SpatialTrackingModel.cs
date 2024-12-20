using UnityEngine;

public class SpatialTrackingModel
{
    public Transform SpatialTrackingTarget { get; private set; }

    public void CreateOrMoveSpatialTrackingTarget(Vector3 position)
    {
        if (SpatialTrackingTarget == null)
        {
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

        return Vector3.zero;
    }
}
