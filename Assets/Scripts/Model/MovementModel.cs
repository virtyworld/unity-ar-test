using UnityEngine;


public class MovementModel
{
    public Vector3 Position { get; set; }
    public float Rotation { get; set; }
    public float Speed { get; set; }
    public ModelConfig Config { get; set; }

    public void UpdatePosition(Vector3 direction)
    {
        Position += direction * Speed * Time.deltaTime;
    }
}

