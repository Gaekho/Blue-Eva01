using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private TimeManager timeManager;
    [SerializeField] private Canvas rewardCanvas;
    [SerializeField] private GameObject rewardTextGroup;
    [SerializeField] private StudioUIManager studio;

    [Header("Reward Parameters")]
    [SerializeField] private TMP_Text subscriberNo;
    [SerializeField] private TMP_Text visitsNo;
    [SerializeField] private TMP_Text revenueNo;

    public bool isDayrunning;
    public bool nextDayOn;
    private RewardPanel rewardPanel;
    public Button nextDayButton;
    private GameManager() { }

    private void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        rewardPanel = rewardCanvas.GetComponentInChildren<RewardPanel>();
        nextDayButton = rewardTextGroup.GetComponentInChildren<Button>();
        nextDayButton.interactable = false;

        rewardPanel.gameObject.SetActive(false);
        rewardTextGroup.gameObject.SetActive(false);

        isDayrunning = false;

        ResetDay();
    }

   // private void Start()
   // {
   //     ResetDay();
   // }



    public void StartReward()
    {
        StartCoroutine("RewardRoutine");
    }

    public void ToNextDay()
    {
        nextDayOn = true;
    }

    private void ResetDay()
    {
        nextDayButton.interactable = false;
        nextDayOn = false;
        timeManager.SetTime(9,0);
        isDayrunning = true;
        StartCoroutine("DayRoutine");
    }

    private IEnumerator DayRoutine()
    {
        rewardTextGroup.SetActive(false);
        rewardPanel.FadeIn();
        yield return new WaitForSeconds(1f);
        rewardPanel.gameObject.SetActive(false);

        while(isDayrunning == true && TimeManager.Instance.Hour < 24)
        {
            yield return null;
        }

        StartCoroutine("RewardRoutine");
    }
    private IEnumerator RewardRoutine()
    {
        rewardPanel.gameObject.SetActive(true);
        subscriberNo.text = "+" + ValuationAPI.valuationJSON["Subscriber Growth"].ToString();
        visitsNo.text = ValuationAPI.valuationJSON["Views"].ToString();
        revenueNo.text = ValuationAPI.valuationJSON["Revenue"].ToString() + "$";

        rewardPanel.FadeOut(); 
        yield return new WaitForSeconds(1f);
        rewardTextGroup.SetActive(true);
        /* api request value and change datas */
        yield return new WaitForSeconds(3f);
        PlayerData.Subscriber += int.Parse((ValuationAPI.valuationJSON["Subscriber Growth"].ToString()));
        studio.SetSub();
        nextDayButton.interactable = true;

        while(nextDayOn == false)
        {
            yield return null;
        }
        ResetDay();
    }
}
