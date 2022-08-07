using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu ( menuName = "Wave Config", fileName ="New Wave Config")] 
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enermyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float delaySpawn = 1f;
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minSpawnTime = 0.2f;

    public Transform GetStartingWaypoint()
    {
        return pathPrefab.GetChild(0);
    }
    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform item in pathPrefab)
        {
            waypoints.Add(item);
            
        }
        return waypoints;
    }
        public float getMoveSpeed()
    {
        return moveSpeed;
    }

    public int GetEnermyCount()
    {
        return enermyPrefabs.Count;

    }

    public GameObject GetEnermyPrefab(int index)
    {
        return enermyPrefabs[index];
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(delaySpawn - spawnTimeVariance,
            delaySpawn + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minSpawnTime, float.MaxValue);
    }

}
