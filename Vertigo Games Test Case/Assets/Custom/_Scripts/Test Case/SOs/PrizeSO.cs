using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Frttpc;

[CreateAssetMenu(fileName = "PrizeSO", menuName = "Scriptable Objects/PrizeSO")]
public class PrizeSO : ScriptableObject
{
    public string prizeName;
    public Sprite prizeVisual;
}
