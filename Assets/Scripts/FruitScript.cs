using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitScript : MonoBehaviour
{
    [Range(0f, 1f)]
    public float healingValue = 0.2f;
    
    private GameDataManager gameDataManager;
    private UIManager uiManager;

    void Start()
    {
        gameDataManager = FindObjectOfType<GameDataManager>();
        uiManager = FindObjectOfType<UIManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            gameDataManager.AddPlayerHealth(healingValue);
            uiManager.UpdatePlayerHealthUI();
            gameObject.SetActive(false);
        }
    }
}
