using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Frttpc;

public class Button_Quit : MonoBehaviour
{
    private Button quitButton;

    private void OnValidate()
    {
        quitButton = GetComponent<Button>();
    }

    private void Awake()
    {
        quitButton.onClick.AddListener(() =>
        {
            UIManager.Instance.ChangeToResultScreen();
            PrizeManager.Instance.ShowResultPrizes();
        });
    }
}
