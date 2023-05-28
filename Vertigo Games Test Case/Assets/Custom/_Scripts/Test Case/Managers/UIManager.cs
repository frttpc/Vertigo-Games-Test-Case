using System.Collections;
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

    public static UIManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void ChangeToCardScreen(Prize prize, int zoneNumber)
    {
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
    }

    public void ChangeToResultScreen()
    {
        resultScreen.SetActive(true);
    }

    public void ActivateLoseScenerio()
    {
        bombResultText.SetActive(true);
        bombCard.SetActive(true);
        failButtons.SetActive(true);
    }

    public void ActivateWinScenerio()
    {
        prizeResultText.SetActive(true);
        rewardButtons.SetActive(true);
    }

    public void EnableGoldCard(Prize prize)
    {
        goldPrizeCard.gameObject.SetActive(true);
    }

    public void EnableSilverCard(Prize prize)
    {
        silverPrizeCard.gameObject.SetActive(true);
    }

    public void EnableDefaultCard(Prize prize)
    {
        defaultPrizeCard.gameObject.SetActive(true);
    }

}
