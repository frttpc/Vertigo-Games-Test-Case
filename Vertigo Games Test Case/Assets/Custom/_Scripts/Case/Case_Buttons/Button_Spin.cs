using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Frttpc;

public class Button_Spin : MonoBehaviour
{
    private Button spinButton;

    private void OnValidate()
    {
        spinButton = GetComponent<Button>();
    }

    private void Awake()
    {
        spinButton.onClick.AddListener(() =>
        {
            WheelManager.Instance.Spin();
        });
    }
}
