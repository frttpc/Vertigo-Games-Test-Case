using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject cardScreen;
    [SerializeField] private GameObject resultScreen;

    [Header("Win")]
    [SerializeField] private GameObject prizeResultText;
    [SerializeField] private GameObject defaultPrizeCard;
    [SerializeField] private GameObject silverPrizeCard;
    [SerializeField] private GameObject goldPrizeCard;
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

    public void ChangeToCardScreen()
    {
        cardScreen.SetActive(true);
    }

    public void ChangeToSpinScreen()
    {
        cardScreen.SetActive(false);
    }

    public void ChangeToResultScreen()
    {
        resultScreen.SetActive(true);
    }
}
