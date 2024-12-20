using UnityEngine;

public class SpatialTrackingView : MonoBehaviour
{
    [SerializeField] private GameObject planePrefab;
    private GameObject placedPlane;
    public void VisualizeTrackingTarget(Vector3 position)
    {
        if (placedPlane == null) placedPlane = Instantiate(planePrefab, position, Quaternion.identity);
        else placedPlane.transform.position = position;
    }
}
