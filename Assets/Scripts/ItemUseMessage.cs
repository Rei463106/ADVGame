using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Talking;

public class ItemUseMessage : MonoBehaviour
{
    Talking _talking;
    int itemFlag;   // 今アイテムメッセージを表示中かどうか
    int enter;      // Zキー入力回数

    void Start()
    {
        _talking = FindAnyObjectByType<Talking>();



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
            if (enter == 1)
            {
                // メッセージボックスを閉じる
                _talking.GreenText.enabled = false;
                _talking.TextImage.enabled = false;
                _talking.Kaogura.enabled = false;
                _talking._state = ImageState.None;

                // 状態リセット
                enter = 0;
                itemFlag = 0;
                StartCoroutine(ResetConversationFlag());
                IsInConversation = false;
                _talking.Loadpower();



                Debug.Log("アイテムメッセージを閉じました");
            }
        }
    }
    private IEnumerator ResetConversationFlag()
    {
        yield return null; // 1フレーム待つ
        IsInConversation = false;
    }

    // アイテム取得時に呼ばれる処理
    public void UseItemMessage(string itemname)
    {
      

        enter = 0;
        itemFlag = 1;

        _talking.Savepower();
        _talking.GreenText.enabled = true;
        _talking.TextImage.enabled = true;
        _talking.Kaogura.enabled = true;
        _talking._state = ImageState.None;
         IsInConversation = true;
        if (itemname == "Key")
        {
            _talking.GreenText.text = "左の方で、ドアが開く音がした…";
        }
        else if (itemname == "Protein")
        {
            _talking.GreenText.text = "マッチョメンが元気になったような気がした。";
        }
      
    }
}
