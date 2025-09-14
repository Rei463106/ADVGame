using UnityEngine;
using UnityEngine.UI;

public class Talking : MonoBehaviour
{
    [Header("TextBoxの表示用")]
    public Image TextImage;
    [Header("Textの表示用その１")]
    public Text GreenText;
    [Header("顔グラの表示用")]
    public Image Kaogura;
    [Header("会話していない時用")]
    public Image NoImage;
    [Header("通常の顔の表示用")]
    public Image NormalKao;
    [Header("困惑顔の表示用")]
    public Image KonwakuKao;
    //PlayerMoveを使いたい
    [SerializeField] ImageState _state;


     PlayerMove _playermove;

    //スタート画面でのフラグ
    int startflag;


    /// <summary>
    /// 会話を進めるための処理
    /// </summary>
    int susumu;

    /// <summary>
    /// エンターを押した回数
    /// </summary>
    int enter;

    //プレイヤーのスピード保存用
    float _savespeed;

    //プレイヤーの速度保存用
    Vector2 _velospeed;


    void Start()
    {
        susumu = 0;
        enter = 0;
        startflag = 0;
        TextImage.enabled = false;
        GreenText.enabled = false;
        Kaogura.enabled = false;
        _playermove=FindAnyObjectByType<PlayerMove>();

    }


    void Update()
    {
        NormalKao.enabled = false;
        KonwakuKao.enabled = false;

        if (startflag == 1 && Input.GetKeyDown(KeyCode.Return))
        {
            enter++;
            if (enter == 1)
            {
                GreenText.text = "確か私はおつかいをしていたような気がするけど…。";
            }
            else if (enter == 2)
            {
                GreenText.text = "とりあえずあそこで倒れてる人にでも聞いてみるか。";
            }
            else if (enter == 3)
            {
                GreenText.enabled = false;
                TextImage.enabled = false;
                Kaogura.enabled = false;
                _state = ImageState.None;
                enter = 0;
            }

        }
        //なるべく入れ子構造にしない！！
        if (susumu == 1 && Input.GetKeyDown(KeyCode.Return))
        {
            enter++;  // Enterが押された回数をカウント

            if (enter == 1)
            {
                // 1回目のEnter
                _state = ImageState.Konwaku;
                GreenText.text = "あなたはいったいだれ？";
            }
            else if (enter == 2)
            {
                // 2回目のEnter
                GreenText.enabled = false;
                TextImage.enabled = false;
                Kaogura.enabled = false;
                _state = ImageState.None;
                PlayerFlag.green = 1;

                //動けるようにする処理
                Loadpower();

            }
        }
        //ここから顔グラの処理

        // 顔を一旦全部非表示にする

        if (_state == ImageState.None)
        {
            NoImage.enabled = true;
        }
        else if (_state == ImageState.Normal)
        {
            NormalKao.enabled = true;
        }
        else if (_state == ImageState.Konwaku)
        {
            KonwakuKao.enabled = true;

        }

    }

    public void Message()
    {
        //スピード保存処理
        Savepower();
        if (PlayerFlag.green == 0)
        {
            GreenText.enabled = true;
            TextImage.enabled = true;
            Kaogura.enabled = true;
            _state = ImageState.Normal;
            GreenText.text = "こんにちは…。";
            susumu = 1;

        }
    }

    public void StartMessage()
    {
        GreenText.enabled = true;
        TextImage.enabled = true;
        Kaogura.enabled = true;
        _state = ImageState.Normal;
        GreenText.text = "…。あれ？ここどこ？";
        startflag = 1;

    }

    void Savepower()
    {
        _savespeed = _playermove.speed;
        _playermove.speed = 0;
        _velospeed = _playermove.rb.velocity;
        _playermove.rb.simulated = false;
        _playermove.rb.Sleep();
    }
    void Loadpower()
    {
        _playermove.rb.simulated = true;
        _playermove.rb.WakeUp();
        _playermove.speed = _savespeed;
        _playermove.rb.velocity = _velospeed;
    }

    public enum ImageState
    {
        //会話なし
        None,
        //通常
        Normal,
        //困惑
        Konwaku,
    }
}
