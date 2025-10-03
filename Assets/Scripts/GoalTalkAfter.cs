using UnityEngine;
using UnityEngine.SceneManagement;
using static Talking;

public class GoalTalkAfter : MonoBehaviour
{
    /// <summary>
    /// エンターを押した回数
    /// </summary>
    int enter;

    //スタート画面でのフラグ
    int startflag;

    //二度と動かないようにするために使う
    public static bool hasShownGoalAfterMessage = false;

    Talking _talking;
    GoalTalk _sceneHandler;
    PlayerFlag _playerFlag;


    void Start()
    {
        _talking = FindAnyObjectByType<Talking>();
        _sceneHandler = FindAnyObjectByType<GoalTalk>();
        _playerFlag = FindAnyObjectByType<PlayerFlag>();

        if (!hasShownGoalAfterMessage)
        {
            GoalMessage();
            hasShownGoalAfterMessage = true;
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

        if (startflag == 1 && Input.GetKeyDown(KeyCode.Z))
        {
            enter++;
            if (enter == 1)
            {
                _talking.TextImage.enabled = true;
                _talking.Kaogura.enabled = true;
                _talking._state = ImageState.Normal;
                _talking.GreenText.text = "…あの、もしかして私のほかにだれか来なかった？";
            }
            else if (enter == 2)
            {
                _talking._state = ImageState.Maccho;
                _talking.GreenText.text = "？いや…お前と、お前の1.5倍くらいの身長の男がやってきた。";
            }
            else if (enter == 3)
            {
                _talking._state = ImageState.Maccho;
                _talking.GreenText.text = "男は自分をプロテインと言うから俺が食べちまった。";
            }
            else if (enter == 4)
            {
                _talking._state = ImageState.Normal;
                _talking.GreenText.text = "…。";

            }
            else if (enter == 5)
            {
                _talking.TextImage.enabled = false;
                _talking.Kaogura.enabled = false;
                _talking._state = ImageState.None;
                _talking.GreenText.text = "罪状としてはマッチョメンと誘拐犯、どっちが重いのか。そんなことを考えていたら家に着いていた。";

            }
            else if (enter == 6)
            {
                _talking.GreenText.enabled = false;
                _talking.TextImage.enabled = false;
                _talking.Kaogura.enabled = false;
                _talking._state = ImageState.None;
                _sceneHandler.Syuryou();
                enter = 0;
                startflag = 0;
                IsInConversation = false;
               ;

                SceneManager.LoadScene("Title");
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
    public void GoalMessage()
    {
        PlayerFlag.appear = true;
        _talking.GreenText.enabled = true;
        _talking.TextImage.enabled = false;
        _talking.Kaogura.enabled = false;
        _talking._state = ImageState.None;
        _talking.GreenText.text = "私はここをでることができた。";
        startflag = 1;
        IsInConversation = true;
        SoundTantou.soundstay = true;
    }
}
