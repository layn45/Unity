using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Prefab;
    public GameObject marioPrefab;

    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;

    public float spawnRateMario=1f;
    public float minHeightMario=0f;
    public float maxHeightMario=0f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(SpawnPipes), spawnRate, spawnRate);
        InvokeRepeating(nameof(SpawnMario), spawnRateMario, spawnRateMario);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(SpawnPipes));
        CancelInvoke(nameof(SpawnMario));
    }

    private void SpawnPipes()
    {
        GameObject pipes = Instantiate(Prefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
    private void SpawnMario()
    {
        GameObject mario = Instantiate(marioPrefab, transform.position, Quaternion.identity);
        mario.transform.position += Vector3.up * Random.Range(minHeightMario, maxHeightMario);
    }
}
