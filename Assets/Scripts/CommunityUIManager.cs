using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    private bool[] clickedFlags;

    public void MainToContents(int buttonIndex)
    {
        content.SetActive(true);
        Ctitle.text = contentsList[buttonIndex].Title;
        Ctext.text = contentsList[buttonIndex].Content;
        currentIndex = buttonIndex;
    }

    public void ToMain()
    {
        content.SetActive(false);
        currentIndex = 20;
    }

    public void ToNextContents()
    {
        currentIndex += 1;
        Ctitle.text = contentsList[currentIndex].Title;
        Ctext.text = contentsList[currentIndex].Content;
    }

    public void ToPreviousContents()
    {
        currentIndex -= 1;
        Ctitle.text = contentsList[currentIndex].Title;
        Ctext.text = contentsList[currentIndex].Content;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentIndex = 20;
        for(int i = 0; i < 2; i++)
        {
            buttonTextList[i].text = contentsList[i].Title;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
