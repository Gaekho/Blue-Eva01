using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TaskBar : MonoBehaviour
{
    public GameObject currentScreen;
    public GameObject powerButton;
    public GameObject clock;
    public GameObject studioDirect;
    public GameObject communityDirect;
    public GameObject wikiDirect;

    public void SetScreen(string siteName)
    {
        switch (siteName)
        {
            case "Studio":
                Debug.Log("Studio opened");
                break;

            case "Community":
                Debug.Log("Community opened");
                break;

            case "Wiki":
                Debug.Log("Wiki opened");
                break;
        }
    }
}
