using UnityEngine;
using UnityEngine.Events;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private ModelItemController modelItemController;
    [SerializeField] private ItemSpawnerController itemSpawnerController;
    [SerializeField] private ModelItemUIController modelItemUIController;
    [SerializeField] private SpatialTrackingController spatialTrackingController;
    [SerializeField] private MovementController movementController;
    [SerializeField] private ChangeCasingController changeCasingController;
    [SerializeField] private ChangeCasingUIController changeCasingUIController;
    [SerializeField] private PlayAnimationUIController playAnimationUIController;
    [SerializeField] private PlayModelAnimationController playModelAnimationController;

    [Header("spatialTrackingView")]
    [SerializeField] private SpatialTrackingView spatialTrackingViewPrefab;
    [SerializeField] private Transform parentSpatialTrackingFolder;

    private UnityEvent<ModelConfig> onItemUIClick = new UnityEvent<ModelConfig>();
    private UnityEvent<ModelConfig> onSpawnItem = new UnityEvent<ModelConfig>();
    private UnityEvent<CasingConfig> onClickToChangeCasingUI = new UnityEvent<CasingConfig>();
    private UnityEvent<CasingConfig> onChaneCasingInModelSpawned = new UnityEvent<CasingConfig>();
    private UnityEvent onPlayAnimationUIButtonClick = new UnityEvent();
    private UnityEvent onPlayModelAnimation = new UnityEvent();

    private ItemSpawnerModel itemSpawnerModel;
    private SpatialTrackingModel spatialTrackingModel;


    private void Awake()
    {
        onItemUIClick.AddListener(SpawnItem);
        onClickToChangeCasingUI.AddListener(ChaneCasingInModelSpawned);
        onPlayAnimationUIButtonClick.AddListener(PlayAnimationButtonClick);

        InitModelSpawnMenu();
        InitSpatialTracking();
        InitItemSpawn();
        InitMovement();
        InitChangeCasing();
        InitChangeCasingUI();
        InitPlayModelAnimation();
        InitPlayAnimationUI();
    }

    private void InitModelSpawnMenu()
    {
        modelItemUIController.Init(onItemUIClick);
    }
    private void InitSpatialTracking()
    {
        spatialTrackingModel = new SpatialTrackingModel();
        SpatialTrackingView stw = Instantiate(spatialTrackingViewPrefab, parentSpatialTrackingFolder, false);
        spatialTrackingController.Init(spatialTrackingModel, stw);
    }
    private void InitItemSpawn()
    {
        itemSpawnerModel = new ItemSpawnerModel();
        itemSpawnerController.Init(itemSpawnerModel, onSpawnItem);
    }
    private void InitMovement()
    {
        MovementModel movementModel = new MovementModel();
        movementController.Init(movementModel, itemSpawnerModel, onSpawnItem);
    }

    private void InitChangeCasingUI()
    {
        ChangeCasingUIModel changeCasingUIModel = new ChangeCasingUIModel();
        changeCasingUIController.Init(changeCasingUIModel, onClickToChangeCasingUI);
    }
    private void InitChangeCasing()
    {
        ChangeCasingModel changeCasingModel = new ChangeCasingModel();
        changeCasingController.Init(changeCasingModel, itemSpawnerModel, onChaneCasingInModelSpawned);
    }
    private void InitPlayModelAnimation()
    {
        PlayModelAnimationModel playModelAnimationModel = new PlayModelAnimationModel();
        playModelAnimationController.Init(playModelAnimationModel, itemSpawnerModel, onPlayModelAnimation, onSpawnItem);
    }
    private void InitPlayAnimationUI()
    {
        PlayAnimationUIModel playAnimationUIModel = new PlayAnimationUIModel();
        playAnimationUIController.Init(playAnimationUIModel, itemSpawnerModel, onPlayAnimationUIButtonClick, onSpawnItem);
    }

    /// <summary>
    /// Spawn an item based on the given model config.
    /// If Spatial Tracking is enabled, the item's position will be set to the spawn position with spatial tracking.
    /// </summary>
    /// <param name="modelConfig">The model config of the item to spawn.</param>
    private void SpawnItem(ModelConfig modelConfig)
    {
        modelConfig.position = spatialTrackingModel.GetSpawnPositionWithSpatialTracking();
        onSpawnItem?.Invoke(modelConfig);
    }
    /// <summary>
    /// Change the casing of an item that has been spawned by the spawner.
    /// </summary>
    /// <param name="casingConfig">The casing config of the casing to change to.</param>
    private void ChaneCasingInModelSpawned(CasingConfig casingConfig)
    {
        onChaneCasingInModelSpawned?.Invoke(casingConfig);
    }
    private void PlayAnimationButtonClick()
    {
        onPlayModelAnimation?.Invoke();
    }

}
