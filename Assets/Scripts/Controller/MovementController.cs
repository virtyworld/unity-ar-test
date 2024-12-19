using UnityEngine;
using UnityEngine.Events;

public class MovementController : MonoBehaviour
{
    private MovementModel movementModel;
    private MovementView movementView;
    private ItemSpawnerModel itemSpawnerModel;

    Vector3 initialTouchWorldPosition; // To store the initial world position
    Vector3 initialModelPosition;      // To store the model's position when interaction begins
    bool isInteracting = false;        // Interaction state flag

    public void Init(MovementModel movementModel, ItemSpawnerModel itemSpawnerModel, UnityEvent<ModelConfig> onItemModelSpawn)
    {
        this.movementModel = movementModel;
        this.itemSpawnerModel = itemSpawnerModel;
        onItemModelSpawn.AddListener(InitModel);
    }

    private void Update()
    {


        if (movementView != null)
        {
            // Touch input handling
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    // Initialize positions when interaction starts
                    initialTouchWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.WorldToScreenPoint(transform.position).z));
                    initialModelPosition = movementModel.Position;
                    isInteracting = true;
                }
                else if (touch.phase == TouchPhase.Moved && isInteracting)
                {
                    // Current touch world position
                    Vector3 currentTouchWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.WorldToScreenPoint(transform.position).z));

                    // Calculate delta from initial touch
                    Vector3 worldDelta = currentTouchWorldPosition - initialTouchWorldPosition;

                    // Apply movement only to x and z axes (or x and y for 2D)
                    worldDelta.y = 0;

                    // Update model position based on delta
                    movementModel.Position = initialModelPosition + worldDelta;
                    movementView.UpdateView(movementModel.Position);
                }
                else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    isInteracting = false;
                }
            }

            // Mouse input handling
            if (Input.GetMouseButtonDown(0))
            {
                // Initialize positions when mouse interaction starts
                Vector3 mousePosition = Input.mousePosition;
                initialTouchWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z));
                initialModelPosition = movementModel.Position;
                isInteracting = true;
            }
            else if (Input.GetMouseButton(0) && isInteracting)
            {
                // Current mouse world position
                Vector3 mousePosition = Input.mousePosition;
                Vector3 currentMouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z));

                // Calculate delta from initial touch
                Vector3 worldDelta = currentMouseWorldPosition - initialTouchWorldPosition;

                // Apply movement only to x and z axes (or x and y for 2D)
                worldDelta.y = 0;

                // Update model position based on delta
                movementModel.Position = initialModelPosition + worldDelta;
                movementView.UpdateView(movementModel.Position);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                isInteracting = false;
            }
        }

    }

    private void InitModel(ModelConfig config)
    {
        movementModel.Config = config;

        if (itemSpawnerModel.itemSpawnerView.Config.itemName == config.itemName)
        {
            movementView = itemSpawnerModel.itemSpawnerView.GetComponent<MovementView>();
        }

    }
}

