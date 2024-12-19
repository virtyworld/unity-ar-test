using UnityEngine;
using UnityEngine.UI;


public class SpatialTrackingView : MonoBehaviour
{
    [SerializeField] private GameObject planePrefab;
    private GameObject placedPlane; // The currently placed plane
    public void VisualizeTrackingTarget(Vector3 position)
    {
        if (placedPlane == null)
        {
            // Instantiate the plane at the first position
            placedPlane = Instantiate(planePrefab, position, Quaternion.identity);
        }
        else
        {
            // Move the plane to the new position
            placedPlane.transform.position = position;
        }
    }
}
