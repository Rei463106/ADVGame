using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTalk : MonoBehaviour
{
    Talking _talking;
    GoalTalkAfter _goalTalkAfter;

    private static bool hasShownStartMessage = false;


    void Start()
    {
        _talking = FindAnyObjectByType<Talking>();
        _goalTalkAfter = FindAnyObjectByType<GoalTalkAfter>();
        if (!hasShownStartMessage)
        {
            // シーンが始まってから2秒後に処理を実行
            StartCoroutine(ExecuteAfterDelay());
            hasShownStartMessage = true;
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
