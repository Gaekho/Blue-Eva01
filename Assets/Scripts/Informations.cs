using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InfoType
{
    None,
    Cat
}

[CreateAssetMenu(fileName = "InteractInfomation", menuName = "Blue Eva01/Investigation/Infomation")]
public class Informations : ScriptableObject
{
    [Header("Investigation Inform")]
    [SerializeField] public InfoType infoName;
    [SerializeField] public TextAsset infoDetail;
}
