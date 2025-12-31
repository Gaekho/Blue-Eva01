using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardPanel : MonoBehaviour
{
    public Animator panelAnimator;
    public Dropdown powerButton;
    public Image myimage;
    public void Start()
    {
        panelAnimator = GetComponent<Animator>();
        myimage = GetComponent<Image>();
    }

    public void FadeOut()
    {
     //   this.gameObject.SetActive(true);
        panelAnimator.SetTrigger("Fade Out");
     
    }

    public void FadeIn()
    {
        panelAnimator.SetTrigger("Fade In");
    }

    public void NextDay()
    {
        GameManager.Instance.ToNextDay();
    }

}
