using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChangeCasingUIController : MonoBehaviour
{
    [SerializeField] private List<CasingConfig> casingConfugList;
    [SerializeField] private Transform parentFolder;
    [SerializeField] private ChangeCasingUIView changeCasingUIViewPrefab;
    private ChangeCasingUIModel changeCasingUIModel;
    private List<ChangeCasingUIView> changeCasingUIViewList = new List<ChangeCasingUIView>();
    private UnityEvent<CasingConfig> onChaneCasingUI;
    private UnityEvent<CasingConfig> onButtonClick = new UnityEvent<CasingConfig>();

    public void Init(ChangeCasingUIModel changeCasingUIModel, UnityEvent<CasingConfig> onChaneCasingUI)
    {
        this.changeCasingUIModel = changeCasingUIModel;
        this.onChaneCasingUI = onChaneCasingUI;
        onButtonClick.AddListener(ButtonClick);
    }

    private void Start()
    {
        InitView();
    }
    private void InitView()
    {
        foreach (CasingConfig casingConfig in casingConfugList)
        {
            ChangeCasingUIView changeCasingUIView = Instantiate(changeCasingUIViewPrefab, parentFolder);
            changeCasingUIView.Init(changeCasingUIModel, casingConfig, onButtonClick);
            changeCasingUIViewList.Add(changeCasingUIView);
        }
    }
    private void ButtonClick(CasingConfig casingConfig)
    {
        onChaneCasingUI?.Invoke(casingConfig);
    }
}
