using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    private int coinsCollected = 0;

    public void AddCoin ()
    {
        coinsCollected++;
    }

    public int GetCoins ()
    {
        return coinsCollected;
    }
}
