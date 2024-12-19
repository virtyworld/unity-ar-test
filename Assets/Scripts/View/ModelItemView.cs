using UnityEngine;
using UnityEngine.UI;
using System;

public class ModelItemView : MonoBehaviour
{
    [SerializeField] private ModelConfig itemModelConfig;

    public ModelConfig ItemModelConfig { get => itemModelConfig; set => itemModelConfig = value; }
    private ModelItemController modelItemController;
    private ModelItemModel modelItemModel;
    private Action<ModelConfig> onItemSpawnClick;

    public void Init()
    {

    }



    // Update is called once per frame
    void Update()
    {

    }


}
