using UnityEngine;

public class ItemGet : MonoBehaviour
{
    BoxHyouji _boxHyouji;
    public string itemName;

    //シーンをまたいだら生成しない
    static public int notitem;
    static public int notitem2;
    static public int notitem3;

    void Start()
    {
        _boxHyouji = FindAnyObjectByType<BoxHyouji>();
    }

    private void Update()
    {
        if (notitem == 1)
        {
            GameObject _Keys = GameObject.Find("Key");
            Destroy(_Keys);
        }
        if (notitem2 == 1)
        {
            GameObject _Keys2 = GameObject.Find("AquaProtein");
            Destroy(_Keys2);

        }
        if (notitem3 == 1)
        {
            GameObject _Keys3 = GameObject.Find("FireProtein");
            Destroy(_Keys3);
        }
    }
    //プレイヤーがぶつかってきたら飛ぶようにする。
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && this.gameObject.name == "Key")
        {
            notitem = 1;
            Itemgets();
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player" && this.gameObject.name == "AquaProtein")
        {
            notitem2 = 1;
            Itemgets();
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Player" && gameObject.name == "FireProtein")
        {
            notitem3 = 1;
            Itemgets();
            Destroy(gameObject);
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

