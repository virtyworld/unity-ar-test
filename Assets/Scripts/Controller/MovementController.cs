using UnityEngine;
using UnityEngine.Events;

public class MovementController : MonoBehaviour
{
    private MovementModel movementModel;
    private MovementView movementView;
    private ItemSpawnerModel itemSpawnerModel;
    private Vector3 initialTouchWorldPosition;
    private Vector3 initialModelPosition;
    private float initialRotationAngle;

    public void Init(MovementModel movementModel, ItemSpawnerModel itemSpawnerModel, UnityEvent<ModelConfig> onItemModelSpawn)
    {
        this.movementModel = movementModel;
        this.itemSpawnerModel = itemSpawnerModel;
        onItemModelSpawn.AddListener(InitSpawnModel);
    }

    private void Update()
    {
        if (movementView != null)
        {
            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);
                HandleSingleTouch(touch);
            }
            else if (Input.touchCount == 2)
            {
                Touch touch1 = Input.GetTouch(0);
                Touch touch2 = Input.GetTouch(1);
                HandleTwoFingerRotation(touch1, touch2);
            }
        }
    }
    private void HandleSingleTouch(Touch touch)
    {
        if (touch.phase == TouchPhase.Began)
        {
            initialModelPosition = itemSpawnerModel.itemSpawnerView.transform.position;
            initialTouchWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(
                touch.position.x, touch.position.y, Camera.main.WorldToScreenPoint(transform.position).z
            ));
        }
        else if (touch.phase == TouchPhase.Moved)
        {
            Vector3 currentTouchWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(
                touch.position.x, touch.position.y, Camera.main.WorldToScreenPoint(transform.position).z
            ));

            Vector3 worldDelta = currentTouchWorldPosition - initialTouchWorldPosition;
            worldDelta.y = 0;
            movementModel.Position = initialModelPosition + worldDelta;
            movementView.UpdateView(movementModel.Position);
        }
    }
    private void HandleTwoFingerRotation(Touch touch1, Touch touch2)
    {
        if (touch1.phase == TouchPhase.Began || touch2.phase == TouchPhase.Began)
        {
            initialRotationAngle = Vector2.SignedAngle(touch2.position - touch1.position, Vector2.right);
        }
        else if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
        {
            float currentRotationAngle = Vector2.SignedAngle(touch2.position - touch1.position, Vector2.right);

            float angleDelta = currentRotationAngle - initialRotationAngle;
            movementModel.Rotation += angleDelta;
            movementView.UpdateViewRotation(movementModel.Rotation);
            initialRotationAngle = currentRotationAngle;
        }
    }
    private void InitSpawnModel(ModelConfig config)
    {
        movementModel.Config = config;

        if (itemSpawnerModel.itemSpawnerView.Config.itemName == config.itemName)
        {
            movementView = itemSpawnerModel.itemSpawnerView.GetComponent<MovementView>();
        }
    }
}

