using UnityEngine;

public class NPCFollow : MonoBehaviour
{
    public Transform targetNPC;        // drag NPC ke sini dari inspector
    public Canvas canvas;
    public Vector3 offset;

    void Update()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(targetNPC.position + offset);
        transform.position = screenPos;
    }
}
