using UnityEngine;

public class ItemGet : MonoBehaviour
{
    BoxHyouji _boxHyouji;
    public string itemName;


    void Start()
    {
        _boxHyouji = FindAnyObjectByType<BoxHyouji>();
    }
    //プレイヤーがぶつかってきたら飛ぶようにする。
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Itemgets();
        }
    }

    public void Itemgets()
    {
        // アイテム名を取得（オブジェクト名をそのまま使う）
        itemName = this.gameObject.name;

        // BoxHyouji の _menuText の中で空いているスロットを探す
        for (int i = 0; i < _boxHyouji._menuText.Length; i++)
        {
            if (_boxHyouji._menuText[i] != null && string.IsNullOrEmpty(_boxHyouji._menuText[i].text))
            {
                _boxHyouji._menuText[i].text = itemName;  // 名前を代入

                break; // 1つ埋めたら終了
            }
        }
    }
}

