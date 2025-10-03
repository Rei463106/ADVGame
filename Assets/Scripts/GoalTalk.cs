using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTalk : MonoBehaviour
{
    Talking _talking;
    GoalTalkAfter _goalTalkAfter;

    public static bool hasShownGoalMessage = false;


    void Start()
    {
        _talking = FindAnyObjectByType<Talking>();
        _goalTalkAfter = FindAnyObjectByType<GoalTalkAfter>();
        if (!hasShownGoalMessage)
        {
            // シーンが始まってから2秒後に処理を実行
            StartCoroutine(ExecuteAfterDelay());
            hasShownGoalMessage = true;
        }



    }

    private IEnumerator ExecuteAfterDelay()
    {
        yield return new WaitForSeconds(0.1f);
        _talking.Savepower();
        _goalTalkAfter.GoalMessage();

    }

    public void Syuryou()
    {
        _talking.Loadpower();
        this.gameObject.SetActive(false);
    }


}
