using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    public GameObject npcPrefab;
    public Transform spawnPoint;
    public float spawnDelay = 2f;

    private bool canSpawn = true;

    void Update()
    {
        if (canSpawn)
        {
            SpawnNPC();
        }
    }

    void SpawnNPC()
    {
        canSpawn = false;
        Instantiate(npcPrefab, spawnPoint.position, Quaternion.identity);
        Invoke(nameof(EnableSpawn), spawnDelay);
    }

    void EnableSpawn()
    {
        canSpawn = true;
    }
}
