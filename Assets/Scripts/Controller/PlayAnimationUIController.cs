using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayAnimationUIController : MonoBehaviour
{
    [SerializeField] private PlayAnimationUIView playAnimationUIView;

    private PlayAnimationUIModel playAnimationUIModel;
    private ItemSpawnerModel itemSpawnerModel;
    private UnityEvent onPlayAnimationUIButtonClick;
    private UnityEvent onPlayButtonClick = new UnityEvent();
    private UnityEvent<bool> onStateButton = new UnityEvent<bool>();

    public void Init(PlayAnimationUIModel playAnimationUIModel, ItemSpawnerModel itemSpawnerModel,
     UnityEvent onPlayAnimationUIButtonClick, UnityEvent<ModelConfig> onSpawnItemSpawn)
    {
        this.playAnimationUIModel = playAnimationUIModel;
        this.onPlayAnimationUIButtonClick = onPlayAnimationUIButtonClick;
        this.itemSpawnerModel = itemSpawnerModel;
        onPlayButtonClick.AddListener(ButtonClick);
        playAnimationUIView.Init(onPlayButtonClick, onStateButton);
        onSpawnItemSpawn.AddListener(CheckExistAnimatorInCurrentObject);
    }
    private void Start()
    {
        CheckExistAnimatorInCurrentObject(null);
    }
    private void CheckExistAnimatorInCurrentObject(ModelConfig modelConfig)
    {
        Animator animator = itemSpawnerModel?.itemSpawnerView?.GetComponent<Animator>();

        if (animator == null) onStateButton?.Invoke(false);
        else onStateButton?.Invoke(true);
    }

    private void ButtonClick()
    {
        onPlayAnimationUIButtonClick?.Invoke();
    }
}
