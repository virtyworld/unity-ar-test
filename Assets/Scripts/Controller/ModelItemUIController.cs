using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ModelItemUIController : MonoBehaviour
{
    [SerializeField] private List<ModelItemUIView> modelItemUIView;
    [SerializeField] private Transform parentFolder;
    private UnityEvent<ModelConfig> onItemUIClick;
    private Dictionary<ModelItemUIView, ModelItemUIModel> modelItemUIDictionary = new Dictionary<ModelItemUIView, ModelItemUIModel>();

    public void Init(UnityEvent<ModelConfig> onItemUIClick)
    {
        this.onItemUIClick = onItemUIClick;
    }


    private void Start()
    {
        SpawnItems();
    }

    private void SpawnItems()
    {
        foreach (ModelItemUIView item in modelItemUIView)
        {
            ModelItemUIView modelItemUIView = Instantiate(item, parentFolder, false); // Set parent directly in Instantiate
            modelItemUIView.Init(onItemUIClick); // Initialize immediately
            ModelItemUIModel modelItemUIModel = new ModelItemUIModel(modelItemUIView.ModelConfig);
            modelItemUIDictionary.Add(modelItemUIView, modelItemUIModel);
        }
    }
}
