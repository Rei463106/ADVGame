using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStartHandler : MonoBehaviour
{
    Talking _talking;
    StartTalkAfter _talkingAfter;

    private static bool hasShownStartMessage = false;
   

    void Start()
    {
        _talking = FindAnyObjectByType<Talking>();
        _talkingAfter = FindAnyObjectByType<StartTalkAfter>();
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
        _talkingAfter.StartMessage();

    }

    public void Syuryou()
    {
        _talking.Loadpower();
        Destroy(gameObject);
    }


}
