using UnityEngine;

public class NeedSpawner : MonoBehaviour
{
    public static string itemName;
    private string air = itemName;
    private string beras = itemName;
    public GameObject Air;
    public GameObject Food;


    void Start()
    {
        Air.SetActive(false);
        Food.SetActive(false);
    }
    public void SpawnRandom()
    {
        int rand = Random.Range(0, 2);

        if (rand == 0)
            Air.SetActive(true);
        else
            Food.SetActive(true);
    }
}