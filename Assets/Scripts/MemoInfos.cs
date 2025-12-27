using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MemoType
{
    None,           //안정성을 위해 넣어둔 초기화값
    Cat
}

[CreateAssetMenu(fileName = "MemoInformation", menuName = "Blue Eva01/Investigation/Memos")]
public class MemoInfos : ScriptableObject
{
    [SerializeField] public MemoType memoName;
    [SerializeField] public GameObject memoPrefab;
}
