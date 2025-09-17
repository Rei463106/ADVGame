using UnityEngine;
using static Talking;

public class StartTalkAfter : MonoBehaviour
{

    /// <summary>
    /// エンターを押した回数
    /// </summary>
    int enter;

    //スタート画面でのフラグ
    int startflag;

    //二度と動かないようにするために使う
    private static bool hasShownStartMessage = false;

    Talking _talking;
    SceneStartHandler _sceneHandler;
    DoorIdou _doorIdou;


    void Start()
    {
        _talking = FindAnyObjectByType<Talking>();
        _sceneHandler = FindAnyObjectByType<SceneStartHandler>();
        _doorIdou = FindAnyObjectByType<DoorIdou>();

        if (!hasShownStartMessage)
        {
            StartMessage();
            hasShownStartMessage = true;
        }
        startflag = 0;
        enter = 0;


        _talking.TextImage.enabled = false;
        _talking.GreenText.enabled = false;
        _talking.Kaogura.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        _talking.NormalKao.enabled = false;
        _talking.KonwakuKao.enabled = false;

        if (startflag == 1 && Input.GetKeyDown(KeyCode.Return))
        {
            enter++;
            if (enter == 1)
            {
                _talking.GreenText.text = "確か私はおつかいをしていたような気がするけど…。";
            }
            else if (enter == 2)
            {
                _talking.GreenText.text = "とりあえずあそこで倒れてる人にでも聞いてみるか。";
            }
            else if (enter == 3)
            {
                _talking.GreenText.enabled = false;
                _talking.TextImage.enabled = false;
                _talking.Kaogura.enabled = false;
                _talking._state = ImageState.None;
                _sceneHandler.Syuryou();
                enter = 0;
                startflag = 0;
                IsInConversation = false;

                _doorIdou.Tashizan();
            }

        }

        //ここから顔グラの処理

        // 顔を一旦全部非表示にする

        if (_talking._state == ImageState.None)
        {
            _talking.NoImage.enabled = true;
        }
        else if (_talking._state == ImageState.Normal)
        {
            _talking.NormalKao.enabled = true;
        }
        else if (_talking._state == ImageState.Konwaku)
        {
            _talking.KonwakuKao.enabled = true;

        }
    }
    public void StartMessage()
    {
       
        _talking.GreenText.enabled = true;
        _talking.TextImage.enabled = true;
        _talking.Kaogura.enabled = true;
        _talking._state = ImageState.Normal;
        _talking.GreenText.text = "…。あれ？ここどこ？";
        startflag = 1;
        IsInConversation = true;
    }
}
