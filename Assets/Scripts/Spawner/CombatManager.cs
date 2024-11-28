using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public EnemySpawner[] enemySpawners;
    public float timer = 0;
    [SerializeField] private float waveInterval = 5f;
    public int waveNumber = 0;
    public int totalEnemies = 0;
    public int EnemyRemain = 0;
    public int EnemyToKill = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartWave();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (EnemySpawner enemySpawner in enemySpawners)
        {
            totalEnemies += enemySpawner.totalKillWave;
        }
        
        if(totalEnemies == 0 || totalEnemies == EnemyToKill)
        {
            foreach (EnemySpawner enemySpawner in enemySpawners)
            {
                enemySpawner.IncreaseSpawnCount();
            }
            StartWave();
        }
    }

    //kasih waktu buat ganti wave
    public void StartWave()
    {
        StartCoroutine(StartWaveCoroutine());
    }

    private IEnumerator StartWaveCoroutine()
    {
        yield return new WaitForSeconds(waveInterval);
        foreach (EnemySpawner enemySpawner in enemySpawners)
        {
            enemySpawner.StartSpawning();
        }
        foreach (EnemySpawner enemySpawner in enemySpawners)
        {
            EnemyToKill += enemySpawner.minimumKillsToIncreaseSpawnCount;
        }
        waveNumber++;
    }

    public int GetWave()
    {
        return waveNumber;
    }

    public int GetEnemyLeft()
    {
        EnemyRemain = 0;
        foreach (EnemySpawner enemySpawner in enemySpawners)
        {
            totalEnemies += enemySpawner.transform.childCount;
        }
        return EnemyRemain;
    }
    
    public int GetEnemyKilled()
    {
        return totalEnemies * waveNumber;
    }
}
