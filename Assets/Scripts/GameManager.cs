using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private TimeManager timeManager;
    [SerializeField] private Canvas rewardCanvas;
    [SerializeField] private GameObject rewardTextGroup;

    public bool isDayrunning;
    public bool nextDayOn;
    private RewardPanel rewardPanel;
    public Button nextDayButton;
    private GameManager() { }

    private void Awake()
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
    }

    private void Start()
    {
        ResetDay();
    }



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
        rewardPanel.FadeOut();
        yield return new WaitForSeconds(1f);
        rewardTextGroup.SetActive(true);
        /* api request value and change datas */
        yield return new WaitForSeconds(3f);
        nextDayButton.interactable = true;

        while(nextDayOn == false)
        {
            yield return null;
        }
        ResetDay();
    }
}
