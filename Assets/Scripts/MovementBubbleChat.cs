using UnityEngine;

public class MovementBubbleChat : MonoBehaviour
{
    public Vector3 targetPosition;
    public float speed = 2f;

    public float scaleSpeed = 0.1f;   // seberapa cepat membesar
    public float maxScale = 0.5f;       // ukuran terbesar
    public GameObject BubbleChat;
    public bool hasArrived = false;
    public NeedSpawner needSpawner;

    void Start() // ← ini harus kapital S !!!
    {
        BubbleChat.SetActive(false);
        
    }

    void Update()
    {
    // gerak NPC
    transform.position = Vector3.MoveTowards(
        transform.position,
        targetPosition,
        speed * Time.deltaTime
    );
    

    // scale effect
    if (transform.localScale.x < maxScale)
    {
       
        float newScale = transform.localScale.x + scaleSpeed * Time.deltaTime;
        transform.localScale = new Vector3(newScale, newScale, 1);
    }
    else
    {

    }

    if (!hasArrived && transform.localScale.x >= maxScale)
    {
        hasArrived = true;
        BubbleChat.SetActive(true);
        needSpawner.SpawnRandom();

    }
}
}
