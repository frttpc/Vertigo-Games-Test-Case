using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject cardScreen;
    [SerializeField] private GameObject resultScreen;

    [Header("Win")]
    [SerializeField] private GameObject prizeResultText;
    [SerializeField] private Card defaultPrizeCard;
    [SerializeField] private Card silverPrizeCard;
    [SerializeField] private Card goldPrizeCard;
    [SerializeField] private GameObject rewardButtons;

    [Header("Lose")]
    [SerializeField] private GameObject bombResultText;
    [SerializeField] private GameObject bombCard;
    [SerializeField] private GameObject failButtons;

    [Header("Warning")]
    [SerializeField] private GameObject warning;

    [Header("Currency")]
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI goldText;

    [Header("Result")]
    [SerializeField] private PrizePrefab resultPrizePrefab;
    [SerializeField] private Transform resultPrizeParent;

    public static UIManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void ChangeToCardScreen(Prize prize)
    {
        int zoneNumber = ZonesManager.Instance.currentZone;

        cardScreen.SetActive(true);

        if(prize.prizeSO.rewardType == RewardType.Bomb)
        {
            ActivateLoseScenerio();
        }
        else
        {
            ActivateWinScenerio();

            if (zoneNumber % 5 == 0)
            { 
                if (zoneNumber == 30)
                {
                    EnableGoldCard(prize);
                }
                else
                {
                    EnableSilverCard(prize);
                }
            }
            else
            {
                EnableDefaultCard(prize);
            }
        }
    }

    public void ChangeToSpinScreen()
    {
        cardScreen.SetActive(false);

        WheelManager.Instance.ChangeWheelVisuals();
    }

    public void ChangeToResultScreen()
    {
        resultScreen.SetActive(true);
        ShowResultPrizes();
    }

    public void ActivateLoseScenerio()
    {
        bombResultText.SetActive(true);
        bombCard.SetActive(true);
        failButtons.SetActive(true);
    }

    public void DeactivateLoseScenerio()
    {
        bombResultText.SetActive(false);
        bombCard.SetActive(false);
        failButtons.SetActive(false);
    }

    public void ActivateWinScenerio()
    {
        prizeResultText.SetActive(true);
        rewardButtons.SetActive(true);
    }

    public void DeactivateWinScenerio()
    {
        prizeResultText.SetActive(false);
        rewardButtons.SetActive(false);
    }

    public void EnableGoldCard(Prize prize)
    {
        goldPrizeCard.gameObject.SetActive(true);
        goldPrizeCard.SetCardValues(prize.prizeSO.prizeVisual, prize.dropAmount);
    }

    public void EnableSilverCard(Prize prize)
    {
        silverPrizeCard.gameObject.SetActive(true);
        silverPrizeCard.SetCardValues(prize.prizeSO.prizeVisual, prize.dropAmount);
    }

    public void EnableDefaultCard(Prize prize)
    {
        defaultPrizeCard.gameObject.SetActive(true);
        defaultPrizeCard.SetCardValues(prize.prizeSO.prizeVisual, prize.dropAmount);
    }

    public void IncreaseMoney(int amount)
    {
        moneyText.text = (Int32.Parse(moneyText.text) + amount).ToString();
    }

    public void IncreaseGold(int amount)
    {
        goldText.text = (Int32.Parse(goldText.text) + amount).ToString();
    }

    public void ShowResultPrizes()
    {
        int length = InventoryManager.Instance.inventory.Count;

        Dictionary<Sprite, int>.KeyCollection keys = InventoryManager.Instance.inventory.Keys;

        foreach (var key in keys)
        {
            PrizePrefab newResultPrize = Instantiate(resultPrizePrefab, resultPrizeParent);
            //newResultPrize.SetPrizeValues(key, InventoryManager.Instance.inventory.TryGetValue(key));
        }
    }
}
