using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    public Player mainPlayer;

    public List<GameObject> playerMemos = new List<GameObject>();

    public GameObject infoScreen;


    private void InfoScreenUnactivate()
    {
        infoScreen.SetActive(false);
    }


    [Header("Info List")]
    public List<Informations> informations = new List<Informations>(10);

    [SerializeField] private TMP_Text Ctext;

    public void InfoActivated_Cat()
    {
        Informations showingInfo = informations.Find(x => x.infoName == InfoType.Cat);
        if (showingInfo != null)
        {
            infoScreen.SetActive(true);
            Ctext.text = showingInfo.infoDetail.text;

        }
    }
}
