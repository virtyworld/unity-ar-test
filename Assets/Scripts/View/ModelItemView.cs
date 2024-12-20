using UnityEngine;

public class ModelItemView : MonoBehaviour
{
    [SerializeField] private ModelConfig itemModelConfig;

    public ModelConfig ItemModelConfig { get => itemModelConfig; set => itemModelConfig = value; }
}
