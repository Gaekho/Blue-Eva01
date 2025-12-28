using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowingInformation : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [SerializeField] private TMP_Text infoText;

    public void ActivateInfo(TextAsset infoDetail)
    {
        infoText.text = infoDetail.text;
        gameObject.SetActive(true);
    }


}
