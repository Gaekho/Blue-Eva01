using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private TimeManager timeManager;
    [SerializeField] private Canvas rewardCanvas;

    public bool isDayrunning;
    private RewardPanel rewardPanel;
    private GameManager() { }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        rewardPanel = rewardCanvas.GetComponentInChildren<RewardPanel>();
        rewardPanel.gameObject.SetActive(false);

    }

    

    public void StartReward()
    {
        StartCoroutine("RewardRoutine");
    }

    private void ResetDay()
    {
        timeManager.SetTime(0,0);
        isDayrunning = true;
    }

    private IEnumerator DayRoutine()
    {
        ResetDay();
        while(isDayrunning == true)
        {
            yield return null;
        }
        
    }
    private IEnumerator RewardRoutine()
    {
        rewardPanel.gameObject.SetActive(true);
        rewardPanel.FadeOut();
        yield return new WaitForSeconds(5f);
        rewardPanel.gameObject.SetActive(false);
    }
}
