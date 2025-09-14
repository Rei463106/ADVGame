//これを書かないとコルーチンが使えない
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoading2 : MonoBehaviour
{
    Talking _talking;

    void Start()
    {
        _talking = FindAnyObjectByType<Talking>();
    }

    void Update()
    {

    }

    //こうすることで、インスペクターから指定できる？
    public void SceneChange(string scenename)
    {
        SceneManager.LoadScene(scenename);
       // StartCoroutine(ExecuteAfterDelay());
    }

    //private IEnumerator ExecuteAfterDelay()
    //{
    //    yield return new WaitForSeconds(2f);
    //    _talking.StartMessage();
    //}



}
