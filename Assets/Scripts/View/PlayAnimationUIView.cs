using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayAnimationUIView : MonoBehaviour
{
    [SerializeField] private Button button;

    private UnityEvent onPlayButtonClick;

    public void Init(UnityEvent onPlayButtonClick, UnityEvent<bool> onStateButton)
    {
        this.onPlayButtonClick = onPlayButtonClick;
        onStateButton.AddListener(ChangeButtonState);
    }
    private void Start()
    {
        button.onClick.AddListener(ButtonClick);
    }
    private void ChangeButtonState(bool value)
    {
        button.gameObject.SetActive(value);
    }
    private void ButtonClick()
    {
        onPlayButtonClick?.Invoke();
    }
}
