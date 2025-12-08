using UnityEngine;
using UnityEngine.EventSystems;

public class NPCDrop : MonoBehaviour, IDropHandler
{
    public string requiredItemID;
    private bool itemAccepted = false;

    public void OnDrop(PointerEventData eventData)
    {
        if(itemAccepted) return;


        ItemDrag draggedItem = eventData.pointerDrag.GetComponent<ItemDrag>();

        if(draggedItem != null)
        {
            if(draggedItem.itemID == requiredItemID)
            {
                AcceptedItem(draggedItem);
            }else
            {
                Debug.Log("NPC : Saya tidak butuh ini");
            }
        }
    }

    private void AcceptedItem(ItemDrag AcceptedItem)
    {
        itemAccepted = true;
        Debug.Log("NPC : Terima Ksih");
        Destroy(AcceptedItem.gameObject);
        MakeNPCLeave();
    }

    private void MakeNPCLeave()
    {
        Destroy(this.gameObject);
    }

    //public void OnDrop(PointerEventData eventData)
    //{
       // var item = eventData.pointerDrag.GetComponent<ItemDrag>();
        //if (item != null)
        //{
            //Debug.Log("NPC menerima item: " + Item.itemName);
        //}
    //}

}
