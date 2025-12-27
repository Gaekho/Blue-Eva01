using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor;
using UnityEngine;

public class Investigaion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            InfoScreenUnactivate();
        }
    }

    public GameObject memoWithText;
    public GameObject memoWithoutText;

    Transform spawnPoint;

    public Player mainPlayer;

    public void OnButtonClicked_WithText()
    {
        mainPlayer.AddNewMemo(memoWithText);
    }

    public void OnButtonClicked_WithoutText()
    {
        mainPlayer.AddNewMemo(memoWithoutText);
    }

    private float memoGap = 3.0f;

    private UnityEngine.Vector3 memoOffset = new UnityEngine.Vector3(-7.0f, 3.0f, 0.0f);

    public List<GameObject> playerMemos = new List<GameObject>();

    public GameObject infoScreen;


    public void OnButtonClicked_ShowMemos()
    {
        int memosNumber = mainPlayer.GetNumOfMemos();
        for(int i = 0; i < memosNumber; i++)
        {
            playerMemos.Add(mainPlayer.GetMemos(i));
            Instantiate(playerMemos[i], memoOffset, UnityEngine.Quaternion.identity);
            memoOffset.x += memoGap;
        }
    }

    public void OnButtonClicked_DeleteMemos()
    {
        infoScreen.SetActive(true);
    }

    private void InfoScreenUnactivate()
    {
        infoScreen.SetActive(false);
    }
}
