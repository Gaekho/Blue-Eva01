using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TaskBar : MonoBehaviour
{
    [Header ("Screens")]
    [SerializeField] private GameObject studioScreen;
    [SerializeField] private GameObject communityScreen;
    [SerializeField] private GameObject wikiScreen;

    [Header ("UI Elements in TaskBar")]
    [SerializeField] private Text clock;
    [SerializeField] private Dropdown powerButton;
    [SerializeField] private string currentScreenName;
    
    

    private void Start()
    {
        powerButton.value = 2;
        currentScreenName = studioScreen.name;
        clock = GetComponentInChildren<Text>();
    }

    public void Update()
    {
        clock.text = TimeManager.Instance.GetTime();
    }

    public void PowerChange()
    {
        switch (powerButton.value)
        {
            case 0:
                Debug.Log("Less power mode ON");
                break;
            case 1:
                Debug.Log("Power Off");
                break;
        }
    }
}
