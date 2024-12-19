using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemSpawnerController : MonoBehaviour
{
    [SerializeField] private List<ItemSpawnerView> itemPrefabs;
    [SerializeField] private Transform parentFolder;
    private ItemSpawnerModel itemSpawnerModel;


    public void Init(ItemSpawnerModel itemSpawnerModel, UnityEvent<ModelConfig> onItemModelSpawn)
    {
        this.itemSpawnerModel = itemSpawnerModel;
        onItemModelSpawn.AddListener(SpawnItem);
    }


    private void SpawnItem(ModelConfig modelConfig)
    {
        DestroyPreviousItem();
        ItemSpawnerView prefab = itemPrefabs.Find(x => modelConfig.itemName == x.Config.itemName);

        if (prefab != null)
        {
            ItemSpawnerView item = Instantiate(prefab);
            item.transform.position = modelConfig.position;
            itemSpawnerModel.itemSpawnerView = item;
        }
        else
        {
            Debug.LogWarning($"Prefab not found for item name: {modelConfig.itemName}");
        }
    }

    private void DestroyPreviousItem()
    {
        DestroyImmediate(itemSpawnerModel?.itemSpawnerView?.gameObject);
    }
}
