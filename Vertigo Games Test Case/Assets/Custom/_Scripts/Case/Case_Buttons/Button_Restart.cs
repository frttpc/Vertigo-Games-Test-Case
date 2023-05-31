using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Restart : MonoBehaviour
{
    private Button restartButton;

    private void OnValidate()
    {
        SetButton();
    }

    private void Awake()
    {
        SetButton();

        restartButton.onClick.AddListener(SceneManager.RestartScene);
    }

    private void SetButton()
    {
        restartButton = GetComponent<Button>();
    }
}
