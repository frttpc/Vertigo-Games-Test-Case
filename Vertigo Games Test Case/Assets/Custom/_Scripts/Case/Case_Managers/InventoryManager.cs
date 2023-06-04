using System.Collections.Generic;
using UnityEngine;

namespace TestCase
{
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField] private PrizeSO moneySO;
        [SerializeField] private PrizeSO goldSO;
        [SerializeField] private PrizeSO bombSO;

        public readonly Dictionary<PrizeSO, int> inventory = new();

        public static InventoryManager Instance;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            inventory.Add(goldSO, 0);
            inventory.Add(moneySO, 0);
        }

        public void AddRewardsToInventory()
        {
            Prize reward = PrizeManager.chosenPrize;

            if (reward.prizeSO == bombSO) return;

            if (inventory.ContainsKey(reward.prizeSO))
            {
                inventory[reward.prizeSO] += reward.dropAmount;
            }
            else
            {
                inventory.Add(reward.prizeSO, reward.dropAmount);
            }

            CheckToIncreaseCurrency(reward);
        }

        private void CheckToIncreaseCurrency(Prize reward)
        {
            if (reward.prizeSO == moneySO || reward.prizeSO == goldSO)
                UIManager.Instance.EditCurrency();
        }

        public int GetMoney() => inventory[moneySO];

        public int GetGold() => inventory[goldSO];

        public bool TrySpend(PrizeSO prizeSO, int amount)
        {
            if (inventory[prizeSO] > amount)
            {
                inventory[prizeSO] -= amount;
                UIManager.Instance.EditCurrency();
                return true;
            }
            else
                return false;
        }
    }

}
