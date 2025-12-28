using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System.Numerics;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine;

public class Investigaion : MonoBehaviour
{
    const int infoNumber = 1;

    [SerializeField] private List<Button> buttonPrefab = new List<Button>(infoNumber);
    [SerializeField] private List<Transform> buttonPoint = new List<Transform>(infoNumber);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
