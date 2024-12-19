using UnityEngine;

public class MovementView : MonoBehaviour
{
    public void UpdateView(Vector3 position)
    {
        transform.position = position;
    }
}

