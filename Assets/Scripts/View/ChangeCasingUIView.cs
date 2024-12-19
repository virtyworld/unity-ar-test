using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChangeCasingUIView : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Image img;

    private UnityEvent<CasingConfig> onButtonClick;
    private ChangeCasingUIModel changeCasingUIModel;
    private CasingConfig casingConfig;

    public void Init(ChangeCasingUIModel changeCasingUIModel, CasingConfig casingConfig, UnityEvent<CasingConfig> onButtonClick)
    {
        this.changeCasingUIModel = changeCasingUIModel;
        this.casingConfig = casingConfig;
        this.onButtonClick = onButtonClick;

    }
    private void Start()
    {
        button.onClick.AddListener(ButtonClick);
        SetImage();
        SetColor();
    }
    private void SetImage()
    {
        if (casingConfig.casingSprite) img.sprite = casingConfig.casingSprite;
    }
    private void SetColor()
    {
        img.color = casingConfig.casingColor;
    }
    private void ButtonClick()
    {
        onButtonClick?.Invoke(casingConfig);
    }
}
