using UnityEngine;
using UnityEngine.InputSystem;

public class DebugKeys : MonoBehaviour
{
    public bool debugEnabled = true;

    void Update()
    {
        if (!debugEnabled)
        {
            return;
        }

        if (Keyboard.current.kKey.wasPressedThisFrame)
        {
            GameManager.Instance.AddScore(10);
        }

        if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            GameManager.Instance.AddLife();
        }

        if (Keyboard.current.gKey.wasPressedThisFrame)
        {
            GameManager.Instance.GameOver();
        }
    }
}