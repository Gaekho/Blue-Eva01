using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ContentsType
{
    important, trash
}

[CreateAssetMenu(fileName ="Community Contents", menuName = "Blue Eva01/Community/Contents", order = 0)]
public class CommunityContents : ScriptableObject
{
    [Header("Contents Setting")]
    [SerializeField] private ContentsType type;
    [SerializeField] private int index;
    [SerializeField] private string title;
    [SerializeField] private string content;

    #region Cache
    public ContentsType Type => type;
    public int Index => index;
    public string Title => title;
    public string Content => content;
    #endregion
}
