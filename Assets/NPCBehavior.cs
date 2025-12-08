using UnityEngine;
using UnityEngine.UI;
using System;

public class NPCBehaviour : MonoBehaviour
{
    [Header("Gerakan")]
    public float moveSpeed = 2f;
    public Transform middlePoint;     // titik tengah
    public Transform exitPoint;       // titik keluar
    public float maxScale = 1.3f;
    public float growSpeed = 1f;

    [Header("UI Request")]
    public GameObject bubbleChat;
    public Image requestIcon;

    [Header("Item Random")]
    public Sprite[] possibleItemSprites;
    public Sprite requestedItemSprite;

    [HideInInspector]
    public Action OnNPCDone;          // callback untuk spawner

    private bool arrivedMiddle = false;
    private bool leaving = false;

    void Start()
    {
        bubbleChat.SetActive(false);

    // --- Atur middlePoint ke tengah kamera ---
    if (middlePoint != null)
    {
        Vector3 camPos = Camera.main.transform.position;
        camPos.z = 0; // NPC biasanya di z=0
        middlePoint.position = camPos;
    }

    // random item
    requestedItemSprite = possibleItemSprites[UnityEngine.Random.Range(0, possibleItemSprites.Length)];
    requestIcon.sprite = requestedItemSprite;
    }

    void Update()
    {
        if (!arrivedMiddle && !leaving)
        {
            MoveAndGrow();
        }
        else if (leaving)
        {
            LeaveArea();
        }
    }

    void MoveAndGrow()
    {
        // --- Gerak ke tengah ---
        transform.position = Vector3.MoveTowards(
            transform.position,
            middlePoint.position,
            moveSpeed * Time.deltaTime
        );

        // --- Grow ---
        if (transform.localScale.x < maxScale)
        {
            float newScale = transform.localScale.x + growSpeed * Time.deltaTime;
            transform.localScale = new Vector3(newScale, newScale, 1);
        }

        // --- Sampai ---
        if (Vector3.Distance(transform.position, middlePoint.position) < 0.05f)
        {
            arrivedMiddle = true;
            bubbleChat.SetActive(true);      // munculkan bubble
        }
    }

    // dipanggil ketika player memberi item
    public void ReceiveItem()
    {
        bubbleChat.SetActive(false);
        leaving = true;       // aktifkan fase pulang
    }

    void LeaveArea()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            exitPoint.position,
            moveSpeed * Time.deltaTime
        );

        // jika sampai di exit
        if (Vector3.Distance(transform.position, exitPoint.position) < 0.05f)
        {
            OnNPCDone?.Invoke();     // beritahu spawner
            Destroy(gameObject);
        }
    }
}
