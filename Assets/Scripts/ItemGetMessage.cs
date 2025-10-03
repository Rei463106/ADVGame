using UnityEngine;
using static Talking;

public class ItemGetMessage : MonoBehaviour
{
    Talking _talking;
    int itemFlag;   // 今アイテムメッセージを表示中かどうか
    int enter;      // Zキー入力回数

    //itemNameを入れる
    public string itemgetname;

    void Start()
    {
        _talking = FindAnyObjectByType<Talking>();

        if (_talking == null)
        {
            Debug.LogError("Talking オブジェクトが見つかりません！");
            return;
        }

        itemFlag = 0;
        enter = 0;

        // 初期状態は非表示
        _talking.TextImage.enabled = false;
        _talking.GreenText.enabled = false;
        _talking.Kaogura.enabled = false;
    }

    void Update()
    {
        if (_talking == null) return;

        // 顔は初期化
        _talking.NormalKao.enabled = false;
        _talking.KonwakuKao.enabled = false;

        if (itemFlag == 1 && Input.GetKeyDown(KeyCode.Z))
        {
            enter++;
            if (enter == 1 && itemgetname == "Key")
            {
                _talking._state = ImageState.Normal;
                _talking.GreenText.text = "こんな大きなカギ、ポケットに入るかな…。";

            }
            else if(enter == 1 && itemgetname == "FireProtein")
            {
                _talking._state = ImageState.Normal;
                _talking.GreenText.text = "唐辛子が1万個くらい入ってそうな色。";
            }
            else if (enter == 1 && itemgetname == "AquaProtein")
            {
                _talking._state = ImageState.Normal;
                _talking.GreenText.text = "賞味期限が心配になりそうな色。";
            }
            if (enter == 2)
            {
                // メッセージボックスを閉じる
                _talking.GreenText.enabled = false;
                _talking.TextImage.enabled = false;
                _talking.Kaogura.enabled = false;
                _talking._state = ImageState.None;

                // 状態リセット
                enter = 0;
                itemFlag = 0;
                IsInConversation = false;

                _talking.Loadpower();

                Debug.Log("アイテムメッセージを閉じました");
            }
        }
    }

    // アイテム取得時に呼ばれる処理
    public void ItemMessage(string itemName)
    {
        if (_talking == null)
        {
            Debug.LogError("Talking が null のため、ItemMessage を実行できません");
            return;
        }
        if (itemName == "Key")
        {
            _talking._state = ImageState.Keye;
            itemgetname = "Key";
        }
        else if (itemName == "AquaProtein")
        {
            _talking._state = ImageState.Aqua;
            itemgetname = "AquaProtein";
        }
        else if (itemName == "FireProtein")
        {
            _talking._state = ImageState.Fire;
            itemgetname = "FireProtein";
        }

        Debug.Log("ItemMessage 呼び出し: " + itemName);

        enter = 0;
        itemFlag = 1;

        _talking.Savepower();
        _talking.GreenText.enabled = true;
        _talking.TextImage.enabled = true;
        _talking.Kaogura.enabled = true;

        _talking.GreenText.text = itemName + " を手に入れた！";

        IsInConversation = true;
    }
}
