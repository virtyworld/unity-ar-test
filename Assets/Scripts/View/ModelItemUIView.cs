using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ModelItemUIView : MonoBehaviour
{
    [SerializeField] private ModelConfig modelConfig;
    [SerializeField] private Button button;
    [SerializeField] private Image image;

    public ModelConfig ModelConfig => modelConfig;
    private UnityEvent<ModelConfig> onItemUIClick;


    public void Init(UnityEvent<ModelConfig> onItemUIClick)
    {
        this.onItemUIClick = onItemUIClick;
    }

    private void Awake()
    {
        button.onClick.AddListener(ButtonClick);
    }

    private void Start()
    {
        SetImage();
    }
    private void ButtonClick()
    {
        onItemUIClick?.Invoke(modelConfig);
    }

    private void SetImage()
    {
        image.sprite = modelConfig.sprite;
    }
}
