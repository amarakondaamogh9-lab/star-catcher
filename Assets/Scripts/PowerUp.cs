using UnityEngine;

public enum PowerUpType
{
    Shield,
    SlowMotion,
    Magnet
}

public class PowerUp : FallingObject
{
    public PowerUpType type;
}