using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public readonly Dictionary<Sprite, int> inventory = new();

    public static InventoryManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void AddRewardsToInventory(Prize reward)
    {
        if (reward.prizeSO.name == "Bomb") return;

        if (reward.prizeSO.name == "Money")
            UIManager.Instance.IncreaseMoney(reward.dropAmount);
        else if (reward.prizeSO.name == "Gold")
            UIManager.Instance.IncreaseGold(reward.dropAmount);

        if (inventory.ContainsKey(reward.prizeSO.prizeVisual))
        {
            inventory[reward.prizeSO.prizeVisual] += reward.dropAmount;
        }
        else
        {
            inventory.Add(reward.prizeSO.prizeVisual, reward.dropAmount);
        }
    }
}
