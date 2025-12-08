using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NPCSpawner : MonoBehaviour
{
    public GameObject npcPrefab;
    public Transform spawnPoint;
    public float spawnDelay = 2f;

    private GameObject currentNPC;
    private bool canSpawn = false;
    public Action OnNPCDone;

    private void Start()
    {
        canSpawn = true;
    }

    private void Update()
    {
        // hanya spawn kalau tidak ada NPC dan spawner siap
        if (canSpawn && currentNPC == null)
        {
            SpawnNPC();
        }
    }

    private void SpawnNPC()
    {
        canSpawn = false;

        // buat NPC baru
        currentNPC = Instantiate(npcPrefab, spawnPoint.position, Quaternion.identity);

        // ambil skrip NPCBehaviour
        NPCBehaviour npc = currentNPC.GetComponent<NPCBehaviour>();

        // hubungkan callback

        // delay spawn berikutnya
        Invoke(nameof(EnableSpawn), spawnDelay);
    }

    private void EnableSpawn()
    {
        canSpawn = true;
    }

    private void OnNPCFinished()
    {
        // beri tahu bahwa NPC sudah hilang
        currentNPC = null;
    }
    
}
