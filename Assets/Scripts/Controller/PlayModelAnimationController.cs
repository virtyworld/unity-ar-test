using UnityEngine;
using UnityEngine.Events;

public class PlayModelAnimationController : MonoBehaviour
{
    private PlayModelAnimationModel playModelAnimationModel;
    private ItemSpawnerModel itemSpawnerModel;
    private PlayModelAnimationView playModelAnimationView;

    public void Init(PlayModelAnimationModel playModelAnimationModel, ItemSpawnerModel itemSpawnerModel,
    UnityEvent onPlayModelAnimation, UnityEvent<ModelConfig> onSpawnItemSpawn)
    {
        this.playModelAnimationModel = playModelAnimationModel;
        this.itemSpawnerModel = itemSpawnerModel;
        onPlayModelAnimation.AddListener(PlayAnimation);
        onSpawnItemSpawn.AddListener(GetPlayModelAnimationView);
    }

    private void GetPlayModelAnimationView(ModelConfig modelConfig)
    {
        playModelAnimationView = itemSpawnerModel?.itemSpawnerView?.GetComponent<PlayModelAnimationView>();
    }
    private void PlayAnimation()
    {
        AnimatorStateInfo currentClip = CheckAnimation();

        if (playModelAnimationView != null)
        {
            if (currentClip.IsName("Idle") || currentClip.IsName("Close")) playModelAnimationView.OpenAnimation();
            else playModelAnimationView.CloseAnimation();
        }
        else playModelAnimationView = itemSpawnerModel.itemSpawnerView.GetComponent<PlayModelAnimationView>();


    }
    private AnimatorStateInfo CheckAnimation()
    {
        return playModelAnimationView.Animator.GetCurrentAnimatorStateInfo(0);
    }
}
