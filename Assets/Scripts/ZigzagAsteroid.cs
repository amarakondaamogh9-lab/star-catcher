using UnityEngine;

public class ZigzagAsteroid : FallingObject
{
    public float zigzagWidth = 1.5f;
    public float zigzagSpeed = 3f;

    float startX;
    float startTime;

    void Start()
    {
        startX = transform.position.x;
        startTime = Time.time;
    }

    protected override void Move()
    {
        base.Move();

        float timeAlive = Time.time - startTime;

        Vector3 pos = transform.position;
        pos.x = startX + Mathf.Sin(timeAlive * zigzagSpeed) * zigzagWidth;
        transform.position = pos;
    }
}