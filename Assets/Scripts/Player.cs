using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private List<MemoInfos> memos = new List<MemoInfos>();

    public void AddNewMemo(MemoInfos newMemo)
    {
        memos.Add(newMemo);     //¸Þ¸ð È¹µæ½Ã ÀúÀå
    }

    public MemoInfos GetMemos(int memoIndex)
    {
        return memos[memoIndex];
    }

    public int GetNumOfMemos()
    {
        return memos.Count;
    }
}