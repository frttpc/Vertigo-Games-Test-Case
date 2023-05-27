using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private Dictionary<string, int> inventory = new();

    public static InventoryManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void AddRewardsToInventory(string reward, int amount)
    {
        if (inventory.ContainsKey(reward))
        {
            inventory[reward] += amount;
        }
        else
        {
            inventory.Add(reward, amount);
        }
    }
}
