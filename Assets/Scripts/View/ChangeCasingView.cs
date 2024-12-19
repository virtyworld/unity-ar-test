using System.Collections.Generic;
using UnityEngine;

public class ChangeCasingView : MonoBehaviour
{
    [SerializeField] private List<Renderer> parts = new List<Renderer>();

    public void ChangeCasing(CasingConfig casingConfig)
    {
        foreach (Renderer part in parts)
        {
            Material material = new Material(part.material);
            material.color = casingConfig.casingColor;
            part.material = material;
        }
    }
}
