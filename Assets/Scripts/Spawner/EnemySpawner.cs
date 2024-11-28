using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    public Enemy spawnedEnemy;

    [SerializeField] public int minimumKillsToIncreaseSpawnCount = 2;
    public int totalKill = 0;
    public int totalKillWave = 0;

    [SerializeField] private float spawnInterval = 2f;

    [Header("Spawned Enemies Counter")]
    public int spawnCount = 2;
    public int defaultSpawnCount = 2;
    public int spawnCountMultiplier = 1;
    public int multiplierIncreaseCount = 1;

    public CombatManager combatManager;


    public bool isSpawning = false;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start Spawning");
        Debug.Log(StartCoroutine(SpawnEnemy()));
        gameObject.SetActive(true);
        Debug.Log(StartCoroutine(SpawnEnemy()));
    }

    void Awake()
    {
        Debug.Log("Start Spawning");
        Debug.Log(StartCoroutine(SpawnEnemy()));
        gameObject.SetActive(true);
        Debug.Log(StartCoroutine(SpawnEnemy()));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //kalau kill minimal sudah terpenuhi, maka tambahin spawn count
    public void IncreaseSpawnCount()
    {
        defaultSpawnCount += spawnCountMultiplier;
        spawnCount = defaultSpawnCount;
        minimumKillsToIncreaseSpawnCount = defaultSpawnCount;
        spawnCountMultiplier += multiplierIncreaseCount;
        totalKillWave = 0;
    }

    public void StartSpawning()
    {
        if (!gameObject.activeInHierarchy)
        {
            gameObject.SetActive(true);
        }
        isSpawning = true;
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (isSpawning)
        {
            if (spawnCount > 0)
            {
                Enemy enemy = Instantiate(spawnedEnemy, transform.position, transform.rotation);
                
                spawnCount--;
            }

            yield return new WaitForSeconds(spawnInterval);

        }
    }


}
