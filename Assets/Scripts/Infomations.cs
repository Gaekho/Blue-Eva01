using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InfoType
{
    important,
    trash
}

[CreateAssetMenu(fileName = "InteractInfomation", menuName = "Blue Eva01/Investigation/Infomation")]
public class Infomations : ScriptableObject
{
    [Header("Investigation Inform")]
    [SerializeField] public InfoType type;
    [SerializeField] private int index;
    [SerializeField] private TextAsset infoDetail;
    [SerializeField] public MemoType memoName;
}
