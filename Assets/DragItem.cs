using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 startPos;
    private Canvas canvas;
    Transform parentAfterDrag;

    void Start()
    {
        startPos = transform.position;
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling(); 
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        GameObject hit = GetNPCUnderMouse();

        if (hit != null)
        {
            NPCBehaviour npc = hit.GetComponent<NPCBehaviour>();
            ItemData item = GetComponent<ItemData>();

            if (npc != null && item != null)
            {
                if (item.itemName == npc.requestedItemSprite.name)
                {
                    npc.ReceiveItem();
                }
            }
        }

        // balik ke posisi awal
        transform.position = startPos;
    }

    GameObject GetNPCUnderMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

        if (hit.collider != null)
            return hit.collider.gameObject;

        return null;
    }
}
