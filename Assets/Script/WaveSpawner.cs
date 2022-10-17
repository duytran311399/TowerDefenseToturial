using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoin;

    public Text WaveCoutDownTimer;
    public Text WaveIndex;
    public Text Zenny;

    public float timebettweenWave = 5f;
    public float coutntDown = 2f;

    public int waveCountIndex = 0;

    void Update()
    {
        if (coutntDown <= 0)
        {
            StartCoroutine(SpawnWave());
            coutntDown = timebettweenWave;
        }
        coutntDown -= Time.deltaTime;
        coutntDown = Mathf.Clamp(coutntDown, 0f, Mathf.Infinity);
        WaveCoutDownTimer.text = string.Format("{0:00.00}", coutntDown);
        WaveIndex.text = "Wave: " + waveCountIndex.ToString();
        Zenny.text = "$" + PlayerStart.Zenny.ToString();
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
