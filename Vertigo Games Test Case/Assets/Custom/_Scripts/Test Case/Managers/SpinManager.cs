using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpinManager : MonoBehaviour
{
    public PrizePoolsSO prizePoolsSO;
    private PrizePoolSO currentPrizePoolSO;
    private Prize chosenPrize;

    [Header("Prize")]
    [SerializeField] private PrizePrefab wheelPrizePrefab;
    [SerializeField] private Transform[] prizePositions = new Transform[8];
    private List<PrizePrefab> wheelPrizeList = new();

    [Header("Wheel")]
    [SerializeField] private GameObject wheel;
    [SerializeField] [Range(2, 5)] private int spinDuration;
    [SerializeField] private Ease spinEase;

    private Vector3 spinRotation = new (0, 0, 360);
    private const int prizeCount = 8;
    private bool isSpinning;

    public static SpinManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        AssignCurrentPrizePoolSO();

        Initialize();
    }

    public void Spin()
    {
        if (isSpinning) return;
         
        isSpinning = true;

        int prizeIndex = Random.Range(0, prizeCount);
        chosenPrize = currentPrizePoolSO.prizePool[prizeIndex];

        Vector3 targetRotation = spinRotation * spinDuration + new Vector3 (0, 0, prizeIndex * 45f);

        wheel.transform.DOLocalRotate(targetRotation, spinDuration, RotateMode.FastBeyond360)
            .SetEase(spinEase)
            .SetRelative()
            .OnComplete(() =>
            {
                isSpinning = false;

                UIManager.Instance.ChangeToCardScreen(chosenPrize);

                InventoryManager.Instance.AddRewardsToInventory(chosenPrize);
            });
    }

    public void ChangeToNextZone()
    {
        AssignCurrentPrizePoolSO();
        ChangeWheelPrizeVisuals();
    }

    private void AssignCurrentPrizePoolSO()
    {
        currentPrizePoolSO = prizePoolsSO.prizePools[ZonesManager.Instance.currentZone];
    }

    private void ChangeWheelPrizeVisuals()
    {
        for (int i = 0; i < prizeCount; i++)
        {
            Prize currentPrize = currentPrizePoolSO.prizePool[i];
            wheelPrizeList[i].SetPrizeValues(currentPrize.prizeSO.prizeVisual, currentPrize.dropAmount);
        }
    }

    private void Initialize()
    {
        for (int i = 0; i < prizeCount; i++)
        {
            wheelPrizeList.Add(Instantiate(wheelPrizePrefab, prizePositions[i]));
        }
        ChangeWheelPrizeVisuals();
    }
}
