using UnityEngine;
using TMPro;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager Instance;

    public GameObject shieldVisual;
    public TextMeshProUGUI powerUpText;
    public float slowDuration = 5f;
    public float magnetDuration = 5f;
    public float magnetRadius = 5f;
    public float magnetStrength = 8f;

    bool hasShield;
    float slowTimer;
    float magnetTimer;

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

        if (magnetTimer > 0f)
        {
            magnetTimer -= Time.deltaTime;
            PullStars();
        }
        
        UpdatePowerUpText();
    }

    void PullStars()
    {
        GameObject[] stars = GameObject.FindGameObjectsWithTag("Star");

        foreach (GameObject star in stars)
        {
            float distance = Vector3.Distance(star.transform.position, transform.position);

            if (distance < magnetRadius)
            {
                star.transform.position = Vector3.MoveTowards(
                    star.transform.position,
                    transform.position,
                    magnetStrength * Time.deltaTime
                );
            }
        }
    }

    void UpdatePowerUpText()
    {
        string text = "";

        if (hasShield)
        {
            text += "<color=#00E5FF>SHIELD</color>\n";
        }

        if (slowTimer > 0f)
        {
            text += "<color=#76FF03>SLOW " + Mathf.CeilToInt(slowTimer) + "s</color>\n";
        }

        if (magnetTimer > 0f)
        {
            text += "<color=#FF4081>MAGNET " + Mathf.CeilToInt(magnetTimer) + "s</color>\n";
        }

        powerUpText.text = text;
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
        else if (type == PowerUpType.Magnet)
        {
            magnetTimer = magnetDuration;
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