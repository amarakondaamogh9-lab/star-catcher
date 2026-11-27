using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager Instance;

    public GameObject shieldVisual;
    public float slowDuration = 5f;

    bool hasShield;
    float slowTimer;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        shieldVisual.SetActive(false);
        FallingObject.worldSpeed = 1f;
    }

    void Update()
    {
        if (slowTimer > 0f)
        {
            slowTimer -= Time.deltaTime;

            if (slowTimer <= 0f)
            {
                FallingObject.worldSpeed = 1f;
            }
        }
    }

    public void Activate(PowerUpType type)
    {
        if (type == PowerUpType.Shield)
        {
            hasShield = true;
            shieldVisual.SetActive(true);
        }
        else if (type == PowerUpType.SlowMotion)
        {
            slowTimer = slowDuration;
            FallingObject.worldSpeed = 0.5f;
        }
    }

    public bool UseShield()
    {
        if (hasShield)
        {
            hasShield = false;
            shieldVisual.SetActive(false);
            return true;
        }

        return false;
    }
}