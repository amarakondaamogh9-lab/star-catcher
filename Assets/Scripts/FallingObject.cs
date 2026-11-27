using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public float fallSpeed = 3f;
    public float speedMultiplier = 1f;
    public int points = 1;
    public static float worldSpeed = 1f;

    void Update()
    {
        Move();

        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void Move()
    {
        transform.Translate(Vector3.down * fallSpeed * speedMultiplier * worldSpeed * Time.deltaTime, Space.World);
    }
}