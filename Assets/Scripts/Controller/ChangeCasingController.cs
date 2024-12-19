using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ChangeCasingController : MonoBehaviour
{
    private ChangeCasingModel changeCasingModel;
    private ItemSpawnerModel itemSpawnerModel;
    private ChangeCasingView changeCasingView;

    public void Init(ChangeCasingModel changeCasingModel, ItemSpawnerModel itemSpawnerModel, UnityEvent<CasingConfig> onChaneCasingInModelSpawn)
    {
        this.changeCasingModel = changeCasingModel;
        this.itemSpawnerModel = itemSpawnerModel;
        onChaneCasingInModelSpawn.AddListener(ChangeCasing);
    }
    private void ChangeCasing(CasingConfig casingConfig)
    {
        if (changeCasingView != null)
        {
            changeCasingView.ChangeCasing(casingConfig);
        }
        else
        {
            changeCasingView = itemSpawnerModel.itemSpawnerView.GetComponent<ChangeCasingView>();

            if (changeCasingView != null) changeCasingView.ChangeCasing(casingConfig);
        }
        Debug.Log("ChangeCasing");
    }
}
