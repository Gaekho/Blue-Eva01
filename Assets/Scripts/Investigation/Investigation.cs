using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System.Numerics;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;
using System.Net.Sockets;

public class Investigation : MonoBehaviour
{
    const int NumOfEvent = 3;

    private List<GameObject> memos = new List<GameObject>();

    [Header("EventsList")]
    [SerializeField] private List<Informations> InfoEventList = new List<Informations>(NumOfEvent);

    [Header("InfoUi")]
    [SerializeField] private GameObject InfoPannel;
    [SerializeField] private TMP_Text InfoDetail;

    [Header("Player")]
    [SerializeField] private Player mainPlayer;

    [Header("Memo")]
    [SerializeField] private GameObject memoPannel;
    [SerializeField] private RectTransform pannelTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            InfoPannel.SetActive(false);
            memoPannel.SetActive(false);
        }
    }

    public void InteractEvent(int eventIndex)
    {
        Informations eventInfo = InfoEventList[eventIndex];
        if (eventInfo != null)
        {
            InfoPannel.SetActive(true);
            InfoDetail.text = eventInfo.infoDetail.text;
            mainPlayer.AddNewMemo(eventInfo.memoToAdd);
            //memos.Add(eventInfo.memoToAdd.memoPrefab);
            PutMemoOnPannel(eventInfo.memoToAdd.memoPrefab);
        }
    }

    public void ShowMemos()
    {
        memoPannel.SetActive(true);
    }

    private void PutMemoOnPannel(GameObject memoToSpawn)
    {
        GameObject newMemo = Instantiate(memoToSpawn, pannelTransform);
        RectTransform memoTransform = newMemo.GetComponent<RectTransform>();
        memoTransform.anchoredPosition = new UnityEngine.Vector2(-10, 3);
        memoTransform.localScale = UnityEngine.Vector3.one;
    }
}
