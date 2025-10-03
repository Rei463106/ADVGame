using UnityEngine;

public class ItemGet : MonoBehaviour
{
    BoxHyouji _boxHyouji;
    ItemGetMessage _itemGetMessage;

    public string itemName;
    public string collidename;

    // シーンをまたいだら復活しないためのフラグ
    public static int notitem;
    public static int notitem2;
    public static int notitem3;

    [SerializeField] AudioClip _audioClip5;

    AudioSource _audioSource;

    void Start()
    {
        _boxHyouji = FindAnyObjectByType<BoxHyouji>();
        _itemGetMessage = FindAnyObjectByType<ItemGetMessage>();
        _audioSource=GetComponent<AudioSource>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        collidename = collision.gameObject.name;

        // すでに取得済みなら何もしない
        if ((collidename == "Key" && notitem == 1) ||
            (collidename == "AquaProtein" && notitem2 == 1) ||
            (collidename == "FireProtein" && notitem3 == 1))
            return;


        if (collidename == "Key")
        {
            notitem = 1;

            Itemgets();
            _itemGetMessage.ItemMessage(collidename);
            AudioSource.PlayClipAtPoint(_audioClip5, transform.position);
            Destroy(collision.gameObject); // 無効化

        }
        else if (collidename == "AquaProtein")
        {
            notitem2 = 1;

            Itemgets();
            _itemGetMessage.ItemMessage(collidename);
            AudioSource.PlayClipAtPoint(_audioClip5, transform.position);
            Destroy(collision.gameObject);
        }
        else if (collidename == "FireProtein")
        {
            notitem3 = 1;

            Itemgets();
            _itemGetMessage.ItemMessage(collidename);
            AudioSource.PlayClipAtPoint(_audioClip5, transform.position);
            Destroy(collision.gameObject);
        }
    }


    public void Itemgets()
    {
        // アイテム名を取得（オブジェクト名をそのまま使う）
        itemName = collidename;

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
