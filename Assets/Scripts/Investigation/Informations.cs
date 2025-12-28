using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public enum InfoType
{
    None,
    Cat
}

[CreateAssetMenu(fileName = "Community Contents", menuName = "Blue Eva01/Community/Contents", order = 0)]
public class Informations : ScriptableObject
{
    [SerializeField] public InfoType infoName;
    [SerializeField] public TextAsset infoDetail;
    [SerializeField] public Sprite buttonImage;
}
