using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    // default ground prefab
    public GameObject defaultGroundPrefab;
    // other ground prefabs
    public List<GameObject> normalGroundPrefabs;
    public List<GameObject> rewardGroundPrefabs;

    private int groundStep = 0; // ground step is used to calculate how many ground prefabs are spawned. 0th is for defauult ground

    public Transform playerTransform;
    public float spawnDistance = 30f;

    private float groundWidth;
    private float lastGroundX;
    private List<GameObject> spawnedGrounds = new List<GameObject>();

    private void Start()
    {
        //groundPrefabs = new List<GameObject>();
        // if(normalGroundPrefabs != null)
        //     normalGroundPrefabs.Insert(0, defaultGroundPrefab);   // insert(instead of add) a default/simple ground prefab to list

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
        GameObject newGround = null;
        
        if(groundStep < 2)
        {
            newGround = Instantiate(defaultGroundPrefab);
            Vector3 newGroundPos = new Vector3(newGroundX, transform.position.y, transform.position.z);
            newGround.transform.position = newGroundPos;
            newGround.transform.SetParent(transform);
        }
        else 
        {
            newGround = GroundFromPattern3G1R(groundStep, normalGroundPrefabs, rewardGroundPrefabs);
            Vector3 newGroundPos = new Vector3(newGroundX, transform.position.y, transform.position.z);
            newGround.transform.position = newGroundPos;
            newGround.transform.SetParent(transform);
        }
        groundStep++;
        
        spawnedGrounds.Add(newGround);
        lastGroundX = newGroundX;
    }

    // random - 3 normal ground and 1 reward ground
    // 3G1R pattern - spawn reward ground every 4th step
    private GameObject GroundFromPattern3G1R (int step, List<GameObject> normalGrounds, List<GameObject> rewardGrounds)
    {
        GameObject g = null;

        if (step % 4 == 0)
        {
            // spawn random reward ground
            int groundId = Random.Range(0, rewardGrounds.Count);
            g = Instantiate(rewardGrounds[groundId]);
        }
        else
        {
            // spawn rendom normal ground
            int groundId = Random.Range(0, normalGrounds.Count);
            g = Instantiate(normalGrounds[groundId]);
        }

        return g;
    }
}
