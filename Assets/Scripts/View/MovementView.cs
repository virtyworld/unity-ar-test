using UnityEngine;

public class MovementView : MonoBehaviour
{
    public void UpdateView(Vector3 position)
    {
        transform.position = position;
    }
    public void UpdateViewRotation(float rotationY)
    {
        transform.rotation = Quaternion.Euler(0, rotationY, 0);
    }
}

