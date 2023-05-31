using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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

    [Header("Wheel")]
    [SerializeField] private Transform wheel;
    [SerializeField] [Range(2, 5)] private int spinDuration;
    [SerializeField] private Ease spinEase;

    private Vector3 spinRotation = Vector3.forward * 360f;

    private bool isSpinning;

    public static WheelManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void Spin()
    {
        if (isSpinning) return;

        isSpinning = true;

        PrizeManager.Instance.ChooseRandomPrizeFromCurrentPool();
        int prizeIndex = PrizeManager.Instance.GetChosenPrizeIndex();

        Vector3 targetRotation = spinRotation * spinDuration + new Vector3(0, 0, prizeIndex * 45f);

        wheel.DOLocalRotate(targetRotation, spinDuration, RotateMode.FastBeyond360)
            .SetEase(spinEase)
            .SetRelative()
            .OnComplete(() =>
            {
                isSpinning = false;

                UIManager.Instance.ChangeToCardScreen();

                InventoryManager.Instance.AddRewardsToInventory();

                ResetWheelRotation();
            });
    }

    public void ChangeWheelVisuals()
    {
        int zoneNumber = ZonesManager.Instance.currentZone + 1;

        if (zoneNumber % 5 == 0)
        {
            if(zoneNumber == 30)
            {
                TurnWheelGold();
            }
            else
            {
                TurnWheelSilver();
            }

        }
        else
        {
            TurnWheelBronze();
        }
    }

    public void ResetWheelRotation()
    {
        wheel.eulerAngles = Vector3.zero;
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
