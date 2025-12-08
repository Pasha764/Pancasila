using UnityEngine;
using UnityEngine.EventSystems;

public class NPCDrop : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        var item = eventData.pointerDrag.GetComponent<ItemDrag>();
        if (item != null)
        {
            Debug.Log("NPC menerima item: " + Item.itemName);
        }
    }
}
