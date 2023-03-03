using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameDataManager gameDataManager;

    public Slider healthSlider;

    private void Start()
    {
        gameDataManager = FindObjectOfType<GameDataManager>();
        healthSlider.value = gameDataManager.GetPlayerHealth();
    }

    public void UpdatePlayerHealthUI ()
    {
        healthSlider.value = gameDataManager.GetPlayerHealth();
    }
}
