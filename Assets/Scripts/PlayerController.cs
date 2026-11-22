using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 8f;
    public float xLimit = 8f;

    void Update()
    {
        float move = 0f;

        if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed)
        {
            move = -1f;
        }
        if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed)
        {
            move = 1f;
        }

        Vector3 pos = transform.position;
        pos.x += move * speed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, -xLimit, xLimit);
        transform.position = pos;
    } 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Star"))
        {
            GameManager.Instance.AddScore(1);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Asteroid"))
        {
            GameManager.Instance.LoseLife();
            Destroy(other.gameObject);
        }
    }
}