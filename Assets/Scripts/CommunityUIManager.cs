using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class CommunityUIManager : MonoBehaviour
{
    [Header("Contents Object")]
    [SerializeField] private GameObject content;
    [SerializeField] private TMP_Text Ctitle;
    [SerializeField] private TMP_Text Ctext;

    [Header("Contents List")]
    [SerializeField] private List<CommunityContents> contentsList = new List<CommunityContents>(20);

    [Header("Button UI")]
    [SerializeField] private List<TMP_Text> buttonTextList = new List<TMP_Text>(20);
    [SerializeField] private Color defaultColor = Color.black;
    [SerializeField] private Color clickedColor = Color.red;
    [SerializeField] private int currentIndex;

    private bool[] clickedFlags = new bool[20];

    

    void Start()
    {
        currentIndex = 20;
        for(int i = 0; i < 20; i++)
        {
            buttonTextList[i].text = contentsList[i].Title;
            clickedFlags[i] = false;
        }
    }

    void Update()
    {
        
    }

#region public methods
    public void MainToContents(int buttonIndex)
    {
        content.SetActive(true);
        Ctitle.text = contentsList[buttonIndex].Title;
        Ctext.text = contentsList[buttonIndex].Content;
        currentIndex = buttonIndex;

        CheckVisited();
    }

    public void ToMain()
    {
        content.SetActive(false);
        currentIndex = 20;
    }

    public void ToNextContents()
    {
        if (currentIndex == 19) return;

        currentIndex += 1;
        Ctitle.text = contentsList[currentIndex].Title;
        Ctext.text = contentsList[currentIndex].Content;

        CheckVisited();
    }

    public void ToPreviousContents()
    {
        if (currentIndex == 0) return;

        currentIndex -= 1;
        Ctitle.text = contentsList[currentIndex].Title;
        Ctext.text = contentsList[currentIndex].Content;

        CheckVisited();
    }

    public void CheckVisited()
    {
        if (clickedFlags[currentIndex] == true)
        {
            return;
        }
        else
        {
            clickedFlags[currentIndex] = true;
            buttonTextList[currentIndex].color = clickedColor;
        }
    }
    
#endregion
}
