using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCBehaviour : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Transform exitPoint;
    public Image requestIcon;
    public Sprite requestedItemSprite;

    private bool received = false;
    private bool leaving = false;

    void Start()
    {
        requestIcon.sprite = requestedItemSprite;
    }

    void Update()
    {
        if (!received)
        {
            // jalan ke tengah
            transform.position = Vector3.MoveTowards(
                transform.position,
                new Vector3(0, transform.position.y, 0),
                moveSpeed * Time.deltaTime
            );
        }
        else if (leaving)
        {
            // keluar
            transform.position = Vector3.MoveTowards(
                transform.position,
                exitPoint.position,
                moveSpeed * Time.deltaTime
            );

            if (Vector3.Distance(transform.position, exitPoint.position) < 0.1f)
            {
                Destroy(gameObject);
            }
        }
    }

    public void ReceiveItem()
    {
        received = true;
        leaving = true;
        requestIcon.gameObject.SetActive(false);
        Debug.Log("Terima kasih!");
    }
}
