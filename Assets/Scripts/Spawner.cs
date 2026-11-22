using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject starPrefab;
    public GameObject asteroidPrefab;
    public float spawnInterval = 1f;
    public float xRange = 8f;
    [Range(0f, 1f)] public float asteroidChance = 0.3f;

    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;
            Spawn();
        }
    }

    void Spawn()
    {
        float x = Random.Range(-xRange, xRange);
        Vector3 pos = new Vector3(x, 6f, 0f);

        GameObject prefab;
        if (Random.value < asteroidChance)
        {
            prefab = asteroidPrefab;
        }
        else
        {
            prefab = starPrefab;
        }

        Instantiate(prefab, pos, Quaternion.identity);
    }
}