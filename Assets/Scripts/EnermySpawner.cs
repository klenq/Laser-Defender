using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermySpawner : MonoBehaviour
{
    WaveConfigSO currentWave;
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float delayWaves = 0.5f;
    [SerializeField] bool isLooping = true;



    void Start()
    {

        StartCoroutine(SpawnWaves());
        
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }
    IEnumerator SpawnWaves()
    {
        do
        {
            foreach (WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnermyCount(); i++)
                {
                    Instantiate(currentWave.GetEnermyPrefab(i),
                            currentWave.GetStartingWaypoint().position,
                            Quaternion.Euler(0,0,180),
                            transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSecondsRealtime(delayWaves);
            }
        } while (isLooping);
        //foreach (WaveConfigSO wave in waveConfigs)
        //{
        //    currentWave = wave;
        //    for (int i = 0; i < currentWave.GetEnermyCount(); i++)
        //    {
        //        Instantiate(currentWave.GetEnermyPrefab(i),
        //                currentWave.GetStartingWaypoint().position,
        //                Quaternion.identity,
        //                transform);
        //        yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
        //    }
        //    yield return new WaitForSecondsRealtime(delayWaves);
        //}


    }
}

