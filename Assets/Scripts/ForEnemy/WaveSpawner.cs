using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public int waveNumber = 0;
    public int enemySpawnAmount = 0;
    public int enemiesKilled = 0;

    [SerializeField] private Transform _spawnerPosition;
    [SerializeField] private GameObject[] spawners; //масив спавнерів
    [SerializeField] private GameObject enemy;//префаб ворога
    [SerializeField] private GameObject boss;
    [SerializeField] private int PerWaveAmount;//кількість ворогів у хвилі
    [SerializeField] private int addEnemyToWave; //додаємо до кожної хвилі по Х ворогів

    public float timer;
    public float timerMax;

    public bool spawn;
    private int spawned;

    [SerializeField] private bool bossKilled;

    private void Start()
    {
        bossKilled = false;

        spawners = new GameObject[18];//кількість спавнерів

        for (int i = 0; i < spawners.Length; i++)
        {
            spawners[i] = transform.GetChild(i).gameObject;
        } //отримуємо спавнери

        StartWave();
    }
    private void Update()
    {
        transform.SetPositionAndRotation(_spawnerPosition.position, _spawnerPosition.rotation);

        if (enemiesKilled >= enemySpawnAmount)
        {
           if(waveNumber % 2 == 0) 
           {
                if(bossKilled == false)
                {
                    int spawnerID = Random.Range(0, spawners.Length);//спавнимо ворога на рандомному спавнері

                    Instantiate(boss, spawners[spawnerID]
                    .transform.position, spawners[spawnerID]
                    .transform.rotation);
                    bossKilled=true;

                    NextWave();

                }

           }else

            NextWave();
        }

        if (spawn) 
        {
            timer--;

            if (timer <= 0) 
            {
                SpawnEnemy();
                spawned++;

                timer = timerMax;
            }

           //if (spawned == enemySpawnAmount) 
            {
               // spawn = false;
            }
        }
    }
    void SpawnEnemy()
    {
        int spawnerID  = Random.Range(0, spawners.Length);//спавнимо ворога на рандомному спавнері
       
            Instantiate(enemy, spawners[spawnerID]
            .transform.position, spawners[spawnerID]
            .transform.rotation);     
    }

    void StartWave()
    {
        //почати хвилю
        waveNumber = 1;
        enemySpawnAmount = PerWaveAmount;
        enemiesKilled = 0;
        //спавн ворогів

        spawn = true;
        // SpawnEnemy();
    }

    public void NextWave()
    {
        //наступні хвилі
        waveNumber++;
        enemySpawnAmount += addEnemyToWave;
        enemiesKilled = 0;

        spawn = true;
        // SpawnEnemy();
    }
}
