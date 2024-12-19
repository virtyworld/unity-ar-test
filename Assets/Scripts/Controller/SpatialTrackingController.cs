using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;

public class SpatialTrackingController : MonoBehaviour
{
    [SerializeField] private ARRaycastManager raycastManager;
    private SpatialTrackingModel spatialTrackingModel;
    private SpatialTrackingView spatialTrackingView;
    private UnityEvent<ModelConfig> onGetPositionToSpawnItem;

    public void Init(SpatialTrackingModel model, SpatialTrackingView view)
    {
        this.spatialTrackingModel = model;
        this.spatialTrackingView = view;
    }

    private void Update()
    {
        // Handle user touch input for spatial tracking
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector2 touchPosition = Input.GetTouch(0).position;

            if (TryGetTouchPosition(touchPosition, out Vector3 hitPosition))
            {
                spatialTrackingModel.CreateOrMoveSpatialTrackingTarget(hitPosition);
                spatialTrackingView.VisualizeTrackingTarget(hitPosition);
            }
        }
    }

    private bool TryGetTouchPosition(Vector2 touchPosition, out Vector3 hitPosition)
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        if (raycastManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinBounds))
        {
            hitPosition = hits[0].pose.position;
            return true;
        }

        hitPosition = Vector3.zero;
        return false;
    }

}
