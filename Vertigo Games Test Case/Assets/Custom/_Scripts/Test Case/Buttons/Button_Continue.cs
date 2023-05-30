using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Frttpc;

public class Button_Continue : MonoBehaviour
{
    private Button continueButton;

    private void OnValidate()
    {
        continueButton = GetComponent<Button>();
    }

    private void Awake()
    {
        continueButton.onClick.AddListener(() =>
        {
            UIManager.Instance.ChangeToSpinScreen(); 
            ZonesManager.Instance.ChangeToNextZone();
            WheelManager.Instance.ChangeWheelVisuals();
            PrizeManager.Instance.ChangeToNextPrizePool();
        });
    }
}
