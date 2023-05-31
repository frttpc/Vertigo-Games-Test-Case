using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Restart : MonoBehaviour
{
    private Button restartButton;

    private void OnValidate()
    {
        restartButton = GetComponent<Button>();
    }

    private void Awake()
    {
        restartButton.onClick.AddListener(SceneManager.RestartScene);
    }
}
