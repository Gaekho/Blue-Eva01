using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TaskBar : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float test = 10f;
    private Image backGround;
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        backGround = GetComponentInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnPointerEnter(PointerEventData data)
    {
        backGround.color = new Color(0, 0, 0, 0.4f);
    }
    public void OnPointerExit(PointerEventData data)
    {
        backGround.color = new Color(0, 0, 0, 0);
    }
}
