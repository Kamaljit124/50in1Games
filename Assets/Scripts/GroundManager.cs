using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    // default ground prefab
    public GameObject defaultGroundPrefab;
    // other ground prefabs
    public List<GameObject> groundPrefabs;
    public Transform playerTransform;
    public float spawnDistance = 30f;

    private float groundWidth;
    private float lastGroundX;
    private List<GameObject> spawnedGrounds = new List<GameObject>();

    private void Start()
    {
        //groundPrefabs = new List<GameObject>();
        if(groundPrefabs != null)
            groundPrefabs.Insert(0, defaultGroundPrefab);   // insert(instead of add) a default/simple ground prefab to list

        groundWidth = defaultGroundPrefab.GetComponent<SpriteRenderer>().bounds.size.x;

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
        int groundId = 0;
        if (newGroundX > 0) groundId = Random.Range(0, groundPrefabs.Count);

        GameObject newGround = Instantiate(groundPrefabs[groundId], new Vector3(newGroundX, transform.position.y, transform.position.z), Quaternion.identity, transform);
        spawnedGrounds.Add(newGround);
        lastGroundX = newGroundX;
    }
}
