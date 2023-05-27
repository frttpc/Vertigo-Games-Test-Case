using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Frttpc;

public class ZonesManager : MonoBehaviour
{
    [Header("Zone Prefabs")]
    [SerializeField] private Zone normalZonePrefab;
    [SerializeField] private Zone safeZonePrefab;

    [Space]
    [SerializeField] private Transform zonesParent;
    [SerializeField] [Range(0, 1)] private float gapBetweenZones;

    [Header("Switch")]
    [SerializeField] [Range(0, 2)] private float switchDuration;
    [SerializeField] private Ease switchEase;

    public static ZonesManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        int length = SpinManager.Instance.prizePoolListSO.prizePoolList.Count;
        Zone newZone;

        for (int i = 0; i < length; i++)
        {
            Vector3 pos = new (gapBetweenZones * i, 0, 0);

            if (i % 5 == 0)
                newZone = Instantiate(safeZonePrefab, pos, Quaternion.identity, zonesParent);
            else
                newZone = Instantiate(normalZonePrefab, pos, Quaternion.identity, zonesParent);

            newZone.SetZoneNumber(i + 1);

            newZone.transform.localPosition = pos;
        }
    }

    public void ChangeToNextZone()
    {
        zonesParent.transform.DOLocalMoveX(zonesParent.transform.position.x - gapBetweenZones, switchDuration).SetEase(switchEase).SetRecyclable();
    }
}
