using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Frttpc;

public class WheelManager : MonoBehaviour
{
    [SerializeField] private Image wheel;
    [SerializeField] private Image pin;

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
        wheel.sprite = bronzeWheelSprite;
        pin.sprite = bronzePinSprite;
    }
    
    public void TurnWheelSilver()
    {
        wheel.sprite = silverWheelSprite;
        pin.sprite = silverPinSprite;
    }

    public void TurnWheelGold()
    {
        wheel.sprite = goldWheelSprite;
        pin.sprite = goldPinSprite;
    }
}
