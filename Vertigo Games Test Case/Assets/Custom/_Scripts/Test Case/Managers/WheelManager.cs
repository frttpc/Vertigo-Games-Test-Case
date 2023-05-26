using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Frttpc;

public class WheelManager : MonoBehaviour
{
    [SerializeField] private Image wheel_value;
    [SerializeField] private Image pin_value;

    [Header("Bronze Wheel")]
    [SerializeField] private Sprite bronzeWheelSprite;
    [SerializeField] private Sprite bronzePinSprite;

    [Header("Silver Wheel")]
    [SerializeField] private Sprite silverWheelSprite;
    [SerializeField] private Sprite silverPinSprite;

    [Header("Gold Wheel")]
    [SerializeField] private Sprite goldWheelSprite;
    [SerializeField] private Sprite goldPinSprite;

    public static WheelManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void TurnWheelBronze()
    {
        wheel_value.sprite = bronzeWheelSprite;
        pin_value.sprite = bronzePinSprite;
    }
    
    public void TurnWheelSilver()
    {
        wheel_value.sprite = silverWheelSprite;
        pin_value.sprite = silverPinSprite;
    }

    public void TurnWheelGold()
    {
        wheel_value.sprite = goldWheelSprite;
        pin_value.sprite = goldPinSprite;
    }
}