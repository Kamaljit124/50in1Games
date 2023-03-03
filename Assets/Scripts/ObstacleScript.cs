using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    [Range(0f, 1f)]
    public float hitValue = 0.2f;

    private GameDataManager gameDataManager;
    private UIManager uiManager;

    private void Start()
    {
        gameDataManager = FindObjectOfType<GameDataManager>();
        uiManager = FindObjectOfType<UIManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            gameDataManager.ReducePlayerHealth(hitValue);
            uiManager.UpdatePlayerHealthUI();
        }
    }
}
