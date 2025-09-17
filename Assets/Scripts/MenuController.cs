using UnityEngine;

public class MenuController : MonoBehaviour
{
    /// <summary> /// trueの時は一時停止 /// </summary>
    bool _menuFlg = false;
    /// <summary> /// 一時停止・再開を制御するための関数の型（デリゲート）を定義 /// </summary>
    public delegate void Menu(bool isMenu);
    /// <summary>/// デリゲートを入れておくための変数 /// </summary>
    Menu _omMenuResume = default;

    /// <summary> /// 一時停止・再開を入れるデリゲートプロパティ /// </summary>
    public Menu OnMenuResume
    {
        get { return _omMenuResume; }
        set { _omMenuResume = value; }
    }
    void Update()
    {
        // 会話中はメニュー禁止
        if (Talking.IsInConversation)
            return;

        if (Input.GetKeyDown(KeyCode.X))
        {
            MenuResume();
        }
       
    }

    void MenuResume()
    {
        _menuFlg = !_menuFlg;
        //trueの時、ここに登録したものが呼び出される
        _omMenuResume(_menuFlg);
    }
}
