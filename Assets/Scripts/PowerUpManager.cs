using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager Instance;

    public GameObject shieldVisual;
    
    bool hasShield;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        shieldVisual.SetActive(false);
    }

    public void Activate(PowerUpType type)
    {
        if (type == PowerUpType.Shield)
        {
            hasShield = true;
            shieldVisual.SetActive(true);
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