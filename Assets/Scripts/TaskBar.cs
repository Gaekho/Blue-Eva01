using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TaskBar : MonoBehaviour
{
    [SerializeField] private GameObject studioScreen;
    [SerializeField] private GameObject communityScreen;
    [SerializeField] private GameObject wikiScreen;

    [SerializeField] private Text clock;

    [SerializeField] private string currentScreenName;
    
    

    private void Start()
    {
        currentScreenName = studioScreen.name;
        clock = GetComponentInChildren<Text>();
    }

    public void Update()
    {
        clock.text = TimeManager.Instance.GetTime();
    }
    public void SetScreen(string siteName)
    {
        switch (siteName)
        {
            case "Studio":
                Debug.Log("Studio opened");
                if (currentScreenName == "Studio Screen") break;
                else
                {
                    communityScreen.SetActive(false);
                    wikiScreen.SetActive(false);
                    studioScreen.SetActive(true);
                    currentScreenName = studioScreen.name;
                    break;
                }
                

            case "Community":
                Debug.Log("Community opened");
                if (currentScreenName == "Community Screen") break;
                else
                {
                    studioScreen.SetActive(false);
                    wikiScreen.SetActive(false);
                    communityScreen.SetActive(true);
                    currentScreenName = communityScreen.name;
                    break;
                }
                

            case "Wiki":
                Debug.Log("Wiki opened");
                if (currentScreenName == "Wiki Screen") break;
                else
                {
                    studioScreen.SetActive(false);
                    communityScreen.SetActive(false);
                    wikiScreen.SetActive(true);
                    currentScreenName = wikiScreen.name;
                    break;
                }
        }
    }
}
