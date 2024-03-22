 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICarSpawnManager : MonoBehaviour
{
    public GameObject SpawnPoint;
    public bool IsSpawn;
    public GameObject AI;

    public void Start()
    {
        StartCoroutine(SpawnTime());
    }

    public void Update()
    {
        if (IsSpawn)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        IsSpawn = false;
        Instantiate(AI, SpawnPoint.transform.position, Quaternion.identity);
        StartCoroutine(SpawnTime());
    }

    IEnumerator SpawnTime()
    {
        yield return new WaitForSeconds(10f);
        IsSpawn = true;
    }
}
