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
    public static bool hasShownStartAfterMessage = false;

    Talking _talking;
    SceneStartHandler _sceneHandler;
    DoorIdou _doorIdou;

    bool inConversation = false;


    void Start()
    {
        _talking = FindAnyObjectByType<Talking>();
        _sceneHandler = FindAnyObjectByType<SceneStartHandler>();
        _doorIdou = FindAnyObjectByType<DoorIdou>();

        if (!hasShownStartAfterMessage)
        {
            StartMessage();
            hasShownStartAfterMessage = true;
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
        //if (!inConversation)
        //{
        //    _talking.NormalKao.enabled = false;
        //    _talking.KonwakuKao.enabled = false;
        //    _talking.MacchoKao.enabled = false;
        //    _talking.TankobuKao.enabled = false;

        //}

        if (startflag == 1 && Input.GetKeyDown(KeyCode.Z))
        {
            enter++;
            if (enter == 1)
            {
                _talking.GreenText.text = "私ってば美少女だから、誘拐されたに違いないわね。";
            }
            else if (enter == 2)
            {
                _talking.GreenText.text = "…とりあえず、あのマッチョに話しかけてみようかな。";
                   
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

        //if (_talking._state == ImageState.None)
        //{
        //    _talking.NoImage.enabled = true;
        //}
        //else if (_talking._state == ImageState.Normal)
        //{
        //    _talking.NormalKao.enabled = true;
        //}
        //else if (_talking._state == ImageState.Konwaku)
        //{
        //    _talking.KonwakuKao.enabled = true;

        //}
    }
    public void StartMessage()
    {
       
        _talking.GreenText.enabled = true;
        _talking.TextImage.enabled = true;
        _talking.Kaogura.enabled = true;
        _talking._state = ImageState.Normal;
        _talking.GreenText.text = "…。ん？ここどこ…？";
        startflag = 1;
        IsInConversation = true;
    }
}
