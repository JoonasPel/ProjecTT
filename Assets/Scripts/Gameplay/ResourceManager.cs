using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResourceManager : MonoBehaviour
{
    [SerializeField]
    private DataSaveLoad dataSaverLoader;
    public static ResourceManager Instance;

    // Player resources
    private Dictionary<string, int> playerResources = new Dictionary<string, int>()
    {
        {"coalOre", 0},
        {"goldCoins", 0}
    };

    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            LoadResources();
        }
    }

    
    public bool IncreaseResource(string resourceName, int amountToIncrease)
    {
        if (amountToIncrease > 0 && playerResources.ContainsKey(resourceName))
        {
            playerResources[resourceName] += amountToIncrease;
            return true;
        }
        Debug.LogError("Can't increase playerResource. Increasing with neg value or resourceName doesn't exist");
        return false;
    }

    [Tooltip("amountToDecrease means how much LESS NOT NEW AMOUNT! DONT USE NEGATIVE VALUES. Returns False if not enough.")]
    public bool decreaseResource(string resourceName, int amountToDecrease)
    {
        if (amountToDecrease > 0 && playerResources.ContainsKey(resourceName))
        {
            if (playerResources[resourceName] >= amountToDecrease)
            {
                playerResources[resourceName] -= amountToDecrease;
                return true;
            }
            else
            {
                return false;
            }
        }
        Debug.LogError("Can't decrease playerResource. Decreasing with neg value or resourceName doesn't exist");
        return false;
    }

    private void LoadResources()
    {
        try
        {
            (playerResources["coalOre"], playerResources["goldCoins"]) =
                dataSaverLoader.LoadData();
        }
        catch (Exception errorText)
        {
            Debug.LogError(errorText);
        }       
    }

    private void SaveResources()
    {
        dataSaverLoader.SaveData(
            playerResources["coalOre"], playerResources["goldCoins"]);
    }
}