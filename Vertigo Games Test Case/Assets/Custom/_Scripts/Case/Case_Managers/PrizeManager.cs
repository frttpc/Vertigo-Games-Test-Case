using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PrizeManager : MonoBehaviour
{
    public PrizePoolsSO prizePoolsSO;
    public static PrizePoolSO currentPrizePoolSO;
    public static Prize chosenPrize;
    int prizeIndex;

    [Header("Wheel Prize")]
    [SerializeField] private PrizePrefab wheelPrizePrefab;
    [SerializeField] private Transform[] prizePositions = new Transform[8];
    private List<PrizePrefab> wheelPrizeList = new();

    [Header("Result Prize")]
    [SerializeField] private PrizePrefab resultPrizePrefab;
    [SerializeField] private Transform resultPrizeParent;

    public const int prizeCount = 8;

    public static PrizeManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        AssignCurrentPrizePoolSO();

        Initialize();
    }

    private void Initialize()
    {
        for (int i = 0; i < prizeCount; i++)
        {
            wheelPrizeList.Add(Instantiate(wheelPrizePrefab, prizePositions[i]));
        }
        ChangeWheelPrizeVisuals();
    }

    private void ChangeWheelPrizeVisuals()
    {
        for (int i = 0; i < prizeCount; i++)
        {
            Prize currentPrize = currentPrizePoolSO.prizePool[i];
            wheelPrizeList[i].SetPrizeValues(currentPrize.prizeSO.prizeVisual, currentPrize.dropAmount);
        }
    }

    public void ChangeToNextPrizePool()
    {
        AssignCurrentPrizePoolSO();
        ChangeWheelPrizeVisuals();
    }

    public void ChooseRandomPrizeFromCurrentPool()
    {
        prizeIndex = Random.Range(0, prizeCount);
        chosenPrize = currentPrizePoolSO.prizePool[prizeIndex];
    }

    public int GetChosenPrizeIndex()
    {
        return prizeIndex;
    }

    private void AssignCurrentPrizePoolSO()
    {
        currentPrizePoolSO = prizePoolsSO.prizePools[ZonesManager.Instance.currentZone];
    }

    public void ShowResultPrizes()
    {
        Dictionary<PrizeSO, int>.KeyCollection keys = InventoryManager.Instance.inventory.Keys;

        foreach (var key in keys)
        {
            PrizePrefab newResultPrize = Instantiate(resultPrizePrefab, resultPrizeParent);
            newResultPrize.SetPrizeValues(key.prizeVisual, InventoryManager.Instance.inventory[key]);
        }
    }

}
