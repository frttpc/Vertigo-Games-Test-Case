using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
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

    public static UIManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void ChangeToResultScreen()
    {
        resultScreen.SetActive(true);


    }
}
