using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; private set; }

    [SerializeField] GameObject[] graveyardPrefabs;
    [SerializeField] int enemyCount=10;

    private Queue<GameObject> graveyardQueue = new Queue<GameObject>();

    private void Awake()
    {
        Instance = this;

        for (int i = 0; i < enemyCount; i++)
        {
            var obj = Instantiate(graveyardPrefabs[Random.Range(0, graveyardPrefabs.Length)]);
            obj.SetActive(false);
            graveyardQueue.Enqueue(obj);

        }
    }

    public void SpawnGraveyard(Transform enemy)
    {
        var obj = graveyardQueue.Dequeue();
        obj.transform.position = enemy.position;
        obj.transform.rotation = enemy.rotation;
        obj.SetActive(true);
    }
}
