using UnityEngine;

public class PlayModelAnimationView : MonoBehaviour
{
    private Animator animator;
    public Animator Animator => animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void OpenAnimation()
    {
        Debug.Log($"OpenAnimation {animator}");
        if (animator != null) animator.Play("Open");
    }
    public void CloseAnimation()
    {
        Debug.Log($"CloseAnimation {animator}");
        if (animator != null) animator.Play("Close");
    }
}
