using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Case
{
    public class WheelManager : MonoBehaviour
    {
        [Header("Wheel")]
        [SerializeField] private Transform wheel;
        [SerializeField] [Range(2, 5)] private int spinDuration;
        [SerializeField] private Ease spinEase;

        [Header("Wheel Visuals")]
        [SerializeField] private Image wheelImage_value;
        [SerializeField] private Image pinImage_value;
        [SerializeField] private Image spinButtonImage_value;

        [Header("Wheel SOs")]
        [SerializeField] private WheelSO bronzeWheelSO;
        [SerializeField] private WheelSO silverWheelSO;
        [SerializeField] private WheelSO goldWheelSO;

        [Space]
        [SerializeField] private Sprite nonClickableSpinButton;
        private Sprite clickableSpinButton;

        private Vector3 spinRotation = Vector3.forward * 360f;

        private bool isSpinning;

        public static WheelManager Instance;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            clickableSpinButton = spinButtonImage_value.sprite;
        }

        public void Spin()
        {
            if (isSpinning) return;

            isSpinning = true;

            ChangeButtonSpriteToNonclickable();

            PrizeManager.Instance.ChooseRandomPrizeFromCurrentPool();
            int prizeIndex = PrizeManager.Instance.GetChosenPrizeIndex();

            Vector3 targetRotation = spinRotation * spinDuration + new Vector3(0, 0, prizeIndex * 45f);

            wheel.DOLocalRotate(targetRotation, spinDuration, RotateMode.FastBeyond360)
                .SetEase(spinEase)
                .SetRelative()
                .OnComplete(OnSpinComplete);
        }

        private void OnSpinComplete()
        {
            isSpinning = false;

            ChangeButtonSpriteToClickable();

            UIManager.Instance.ChangeToCardScreen();
            
            InventoryManager.Instance.AddRewardsToInventory();
            
            ResetWheelRotation();
        }

        public void ChangeWheelVisuals()
        {
            int zoneNumber = ZonesManager.Instance.currentZone + 1;

            if (zoneNumber % ZonesManager.silverZonePerNumber == 0)
            {
                if (zoneNumber == ZonesManager.maxZoneNumber)
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
            wheelImage_value.sprite = bronzeWheelSO.wheelSprite;
            pinImage_value.sprite = bronzeWheelSO.pinSprite;
        }

        public void TurnWheelSilver()
        {
            wheelImage_value.sprite = silverWheelSO.wheelSprite;
            pinImage_value.sprite = silverWheelSO.pinSprite;
        }

        public void TurnWheelGold()
        {
            wheelImage_value.sprite = goldWheelSO.wheelSprite;
            pinImage_value.sprite = goldWheelSO.pinSprite;
        }

        private void ChangeButtonSpriteToNonclickable()
        {
            spinButtonImage_value.sprite = nonClickableSpinButton;
        }

        private void ChangeButtonSpriteToClickable()
        {
            spinButtonImage_value.sprite = clickableSpinButton;
        }
    }

}
