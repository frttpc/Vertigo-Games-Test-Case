using System.Collections.Generic;
using System;
using UnityEngine;

namespace Case
{
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField] private PrizeSO moneySO;
        [SerializeField] private PrizeSO goldSO;
        [SerializeField] private PrizeSO bombSO;

        public readonly Dictionary<string, Prize> inventory = new(StringComparer.OrdinalIgnoreCase);

        public static InventoryManager Instance;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            inventory.Add(goldSO.rewardType.ToString(), new Prize(goldSO, 0));
            inventory.Add(moneySO.rewardType.ToString(), new Prize(moneySO, 0));
        }

        public void AddRewardsToInventory()
        {
            Prize reward = PrizeManager.chosenPrize;

            if (reward.prizeSO == bombSO) return;

            if (inventory.ContainsKey(reward.prizeSO.rewardType.ToString()))
            {
                inventory[reward.prizeSO.rewardType.ToString()] += reward;
            }
            else
            {
                inventory.Add(reward.prizeSO.rewardType.ToString(), reward);
            }

            CheckToIncreaseCurrency(reward);
        }

        private void CheckToIncreaseCurrency(Prize reward)
        {
            if (reward.prizeSO == moneySO || reward.prizeSO == goldSO)
                UIManager.Instance.EditCurrency();
        }

        public int GetMoney() => inventory[moneySO.rewardType.ToString()].dropAmount;

        public int GetGold() => inventory[goldSO.rewardType.ToString()].dropAmount;

        public bool TrySpend(PrizeSO prizeSO, int amount)
        {
            if (inventory[prizeSO.rewardType.ToString()].dropAmount > amount)
            {
                inventory[prizeSO.rewardType.ToString()] -= new Prize(prizeSO, amount);
                UIManager.Instance.EditCurrency();
                return true;
            }
            else
                return false;
        }
    }
}
