using UnityEngine;

public class GoldenStar : FallingObject
{
    public float spinSpeed = 180f;

    protected override void Move()
    {
        base.Move();
        transform.Rotate(0f, 0f, spinSpeed * Time.deltaTime);
    }
}