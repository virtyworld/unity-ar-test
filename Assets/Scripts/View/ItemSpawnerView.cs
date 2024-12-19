using UnityEngine;

public class ItemSpawnerView : MonoBehaviour
{
    [SerializeField] private ModelConfig itemModelConfig;

    public ModelConfig Config => itemModelConfig;
}
