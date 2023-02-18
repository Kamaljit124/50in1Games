using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public GameObject groundPrefab;
    public Transform playerTransform;
    public float spawnDistance = 30f;

    private float groundWidth;
    private float lastGroundX;
    private List<GameObject> spawnedGrounds = new List<GameObject>();

    private void Start()
    {
        groundWidth = groundPrefab.GetComponent<SpriteRenderer>().bounds.size.x;
        SpawnGround(0);
        SpawnGround(0 + groundWidth);
    }

    private void Update()
    {
        if (lastGroundX - playerTransform.position.x < spawnDistance)
        {
            SpawnGround(lastGroundX + groundWidth);
        }

        // Despawn grounds that have passed the player
        for (int i = 0; i < spawnedGrounds.Count; i++)
        {
            if (spawnedGrounds[i].transform.position.x + groundWidth / 2 < playerTransform.position.x - spawnDistance)
            {
                Destroy(spawnedGrounds[i]);
                spawnedGrounds.RemoveAt(i);
                i--;
            }
        }
    }

    private void SpawnGround(float newGroundX)
    {
        GameObject newGround = Instantiate(groundPrefab, new Vector3(newGroundX, transform.position.y, transform.position.z), Quaternion.identity, transform);
        spawnedGrounds.Add(newGround);
        lastGroundX = newGroundX;
    }
}
