using UnityEngine;
using System.Collections;

public class SceneStartHandler : MonoBehaviour
{
    Talking _talking;

    private void Awake()
    {
        _talking=FindAnyObjectByType<Talking>();
    }
    void Start()
    {
        // シーンが始まってから2秒後に処理を実行
        StartCoroutine(ExecuteAfterDelay());
       
    }

    private IEnumerator ExecuteAfterDelay()
    {
        yield return new WaitForSeconds(0f);

        _talking.StartMessage();

    }

   
}
