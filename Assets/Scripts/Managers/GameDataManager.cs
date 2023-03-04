using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    private int coinsCollected = 0;
    private float playerHealth = 1f;

    private void Start()
    {
        coinsCollected = 0;
        playerHealth = 1f;
    }

    public void AddCoin ()
    {
        coinsCollected++;
        Debug.Log("Coins collected: " + coinsCollected);
    }

    public int GetCoins ()
    {
        return coinsCollected;
    }

    public void AddPlayerHealth(float val)
    {
        if (playerHealth < 1)
            playerHealth += val;

        playerHealth = Mathf.Clamp(playerHealth, 0, 1);


        Debug.Log("Player health: " + playerHealth);
    }
    public void ReducePlayerHealth(float val)
    {
        if (playerHealth > 0)
            playerHealth -= val;

        playerHealth = Mathf.Clamp(playerHealth, 0, 1);

        if (playerHealth <= 0)
        {
            Debug.Log("Player fainted -- GameOver");
        } else
        {
            Debug.Log("Player health: " + playerHealth);
        }
    }

    public float GetPlayerHealth()
    {
        return playerHealth;
    }
}
