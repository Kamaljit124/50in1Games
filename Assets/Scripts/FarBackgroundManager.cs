using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarBackgroundManager : MonoBehaviour
{
    public GameObject bgPrefab;
    public Transform playerTransform;
    public float spawnDistance = 30f;

    private float bgWidth;
    private float lastBGX;
    private List<GameObject> spawnedBGs = new List<GameObject>();

    private void Start()
    {
        bgWidth = bgPrefab.GetComponent<SpriteRenderer>().bounds.size.x;
        SpawnBG(0);
        SpawnBG(0 + bgWidth);
    }

    private void Update()
    {
        if (lastBGX - playerTransform.position.x < spawnDistance)
        {
            SpawnBG(lastBGX + bgWidth);
        }

        // Despawn grounds that have passed the player
        for (int i = 0; i < spawnedBGs.Count; i++)
        {
            if (spawnedBGs[i].transform.position.x + bgWidth / 2 < playerTransform.position.x - spawnDistance)
            {
                Destroy(spawnedBGs[i]);
                spawnedBGs.RemoveAt(i);
                i--;
            }
        }
    }

    private void SpawnBG(float newBGX)
    {
        GameObject newBG = Instantiate(bgPrefab, new Vector3(newBGX, transform.position.y, transform.position.z), Quaternion.identity, transform);
        spawnedBGs.Add(newBG);
        lastBGX = newBGX;

    }
}
