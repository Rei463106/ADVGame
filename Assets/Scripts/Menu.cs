using UnityEngine;

public class Menu : MonoBehaviour
{
    MenuController _controller = default;
    BoxHyouji _boxHyouji = default;
    Cursor _cursor = default;
    Talking _talking;

    private void Awake()
    {
        _controller = GameObject.FindObjectOfType<MenuController>();
        _boxHyouji = GameObject.FindObjectOfType<BoxHyouji>();
        _cursor = GameObject.FindObjectOfType<Cursor>();
        _talking = GameObject.FindObjectOfType<Talking>();

        for (int i = 0; i < _boxHyouji._menuBox.Length; i++)
        {
            _boxHyouji._menuBox[i].enabled = false;
            _boxHyouji._menuText[i].enabled = false;

        }
        _boxHyouji._menuHaikei.enabled = false;
        _cursor._cursorImage.enabled = false;
    }
    void OnEnable()
    {
        //プロパティのところに書き込む？？
        _controller.OnMenuResume += MenuResume;
    }

    private void OnDisable()
    {
        _controller.OnMenuResume -= MenuResume;
    }

    //これを新たに登録したので、ここに処理を書く。
    //さらに細かい処理は次のメソッドへ。
    void MenuResume(bool isPause)
    {
        if (isPause)
        {
            Pause();
            _talking.Savepower();
        }
        else
        {
            Resume();
            _talking.Loadpower();
        }
    }

    public void Pause()
    {
        //メニューを開く。
        //とりあえず画像を表示させる。
        Debug.Log("メニューを開きました");
        //画像を表示するための計算を別のスクリプトで行う！！

        _boxHyouji.Hyouji();

    }
    public void Resume()
    {

        Debug.Log("メニューを閉じました");
        _boxHyouji.Hihyouji();
    }
}
