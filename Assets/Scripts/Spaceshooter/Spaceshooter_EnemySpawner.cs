using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceshooter_EnemySpawner : MonoBehaviour
{
    [SerializeField] public static Spaceshooter_EnemySpawner instance;
    [SerializeField] int maxSpawns;
    [SerializeField] int currentSpawns;
    [SerializeField] float spawnCooldown;
    [SerializeField] float spawnCounter;
    [SerializeField] float baseSpawnChance;
    [SerializeField] float currentSpawnChance;

    [SerializeField] GameObject tempEnemyPrefab;

    float worldWidth;
    float worldHeight;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Vector2 screenbounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        worldWidth = screenbounds.x;
        worldHeight = screenbounds.y;
    }

    // Update is called once per frame
    void Update()
    {
        spawnCounter += Time.deltaTime;
        if (spawnCounter >= spawnCooldown && currentSpawns < maxSpawns)
        {
            //Change this to use Spawner physical bounds
            TrySpawn(worldWidth -Random.Range(0.75f, 5f), Random.Range(0, worldHeight));
            spawnCounter = 0;
        }
    }

    void TrySpawn(float xPos, float yPos)
    {
        if (Random.Range(0, 100) < currentSpawnChance)
        {
            Instantiate(tempEnemyPrefab, new Vector3(xPos, yPos, 0), Quaternion.identity);
            currentSpawns++;
            currentSpawnChance = baseSpawnChance;
        }
        else
            currentSpawnChance += 25;
    }
}
