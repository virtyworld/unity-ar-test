using UnityEngine;

[CreateAssetMenu(fileName = "ModelConfig", menuName = "ScriptableObjects/ModelConfig", order = 1)]
public class ModelConfig : ScriptableObject
{
    public int id;
    public string itemName;
    public string description;
    public Sprite sprite;
    public Vector3 position;
    public int movespeed;
}
