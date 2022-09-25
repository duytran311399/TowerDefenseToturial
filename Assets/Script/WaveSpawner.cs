using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoin;

    public Text WaveCoutDownTimer;

    public float timebettweenWave = 5f;
    public float Coutdown = 2f;

    public int waveCountIndex = 0;

    void Update()
    {
        if (Coutdown <= 0)
        {
            StartCoroutine(SpawnWave());
            Coutdown = timebettweenWave;
        }
        Coutdown -= Time.deltaTime;
        WaveCoutDownTimer.text = Mathf.Round(Coutdown).ToString();
    }
    IEnumerator SpawnWave()
    {
        waveCountIndex++;
        for (int i = 0; i < waveCountIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoin.position, Quaternion.identity);
    }
}
