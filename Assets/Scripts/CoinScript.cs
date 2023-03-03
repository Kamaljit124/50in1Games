using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private GameDataManager gameDataManager;

    private void Start()
    {
        gameDataManager = FindObjectOfType<GameDataManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            gameDataManager.AddCoin();
            Debug.Log("Coins: " + gameDataManager.GetCoins());
            gameObject.SetActive(false);
        }
    }
}
