using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "MemoInformation", menuName = "Blue Eva01/Investigation/Memos")]
public class MemoInfos : ScriptableObject
{
    [SerializeField] public InfoType memoName;
    [SerializeField] public GameObject memoPrefab;
}
