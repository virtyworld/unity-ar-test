using UnityEngine;

[CreateAssetMenu(fileName = "CasingConfig", menuName = "ScriptableObjects/CasingConfig", order = 2)]
public class CasingConfig : ScriptableObject
{
    public int id;
    public Sprite casingSprite;
    public string casingName;
    public Color casingColor;
}
