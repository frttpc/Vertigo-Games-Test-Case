using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject cardScreen;
    [SerializeField] private GameObject resultScreen;

    [Header("Win")]
    [SerializeField] private GameObject prizeText;
    [SerializeField] private Card defaultPrizeCard;
    [SerializeField] private Card silverPrizeCard;
    [SerializeField] private Card goldPrizeCard;
    [SerializeField] private GameObject rewardButtons;

    [Header("Lose")]
    [SerializeField] private GameObject bombText;
    [SerializeField] private GameObject bombCard;
    [SerializeField] private GameObject failButtons;

    [Header("Warning")]
    [SerializeField] private GameObject warning;
    [SerializeField] [Range(0.5f, 2)] private float warningDuration;

    [Header("Currency")]
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI goldText;

    public static UIManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (warning.activeSelf)
        {
            if (warningDuration < 0)
            {
                DisableWarning();
            }
            else
            {
                warningDuration -= Time.deltaTime;
            }
        }
    }

    public void ChangeToCardScreen()
    {
        cardScreen.SetActive(true);
        ActivateNeeded();
    }

    public void ChangeToSpinScreen()
    {
        cardScreen.SetActive(false);
        DeactivateAll();
    }

    public void ChangeToResultScreen()
    {
        resultScreen.SetActive(true);
    }

    private void ActivateLoseScenerio()
    {
        bombText.SetActive(true);
        bombCard.SetActive(true);
        failButtons.SetActive(true);
    }

    private void DeactivateLoseScenerio()
    {
        bombText.SetActive(false);
        bombCard.SetActive(false);
        failButtons.SetActive(false);
    }

    private void ActivateWinScenerio()
    {
        prizeText.SetActive(true);
        rewardButtons.SetActive(true);
    }

    private void DeactivateWinScenerio()
    {
        prizeText.SetActive(false);
        rewardButtons.SetActive(false);
    }

    private void EnableGoldCard(Prize prize)
    {
        goldPrizeCard.gameObject.SetActive(true);
        goldPrizeCard.SetCardValues(prize.prizeSO.prizeVisual, prize.dropAmount);
    }

    private void EnableSilverCard(Prize prize)
    {
        silverPrizeCard.gameObject.SetActive(true);
        silverPrizeCard.SetCardValues(prize.prizeSO.prizeVisual, prize.dropAmount);
    }

    private void EnableDefaultCard(Prize prize)
    {
        defaultPrizeCard.gameObject.SetActive(true);
        defaultPrizeCard.SetCardValues(prize.prizeSO.prizeVisual, prize.dropAmount);
    }

    public void EditCurrency()
    {
        goldText.text = InventoryManager.Instance.GetGold().ToString();
        moneyText.text = InventoryManager.Instance.GetMoney().ToString();
    }

    public void EnableWarning()
    {
        warning.SetActive(true);
    }

    private void DisableWarning()
    {
        warning.SetActive(false);
    }

    private void ActivateNeeded()
    {
        int zoneNumber = ZonesManager.Instance.currentZone;
        Prize prize = PrizeManager.chosenPrize;

        if (prize.prizeSO.rewardType == RewardType.Bomb)
        {
            ActivateLoseScenerio();
        }
        else
        {
            ActivateWinScenerio();

            if (zoneNumber % 5 == 0 || zoneNumber == 1)
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

    private void DeactivateAll()
    {
        DeactivateLoseScenerio();
        DeactivateWinScenerio();
        defaultPrizeCard.gameObject.SetActive(false);
        silverPrizeCard.gameObject.SetActive(false);
        goldPrizeCard.gameObject.SetActive(false);
    }

    public enum UIState
    {
        Spin,
        Bomb,
        DefaultPrize,
        SilverPrize,
        GoldPrize,
        Lose,
        Win
    }
}
