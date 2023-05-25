using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Frttpc;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject resultScreen;

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
