using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
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
        
    }

    private GameObject memoWithText = GameObject.Find("OnlyMemos_0");
    private GameObject memoWithoutText = GameObject.Find("OnlyMemos_1");

    public Transform spawnPoint;

    public void OnButtonClicked_WithText()
    {
        SpawnObject(memoWithText);
    }

    public void OnButtonClicked_WithoutText()
    {
        SpawnObject(memoWithoutText);
    }
    
    private void SpawnObject(GameObject inTarget)
    {
        Instantiate(inTarget, spawnPoint);
    }
}
