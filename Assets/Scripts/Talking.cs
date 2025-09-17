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
    [SerializeField] public ImageState _state;


    PlayerMove _playermove;

  


  

    //プレイヤーのスピード保存用
    float _savespeed;

    //プレイヤーの速度保存用
    Vector2 _velospeed;

    SceneStartHandler _sceneHand;


    //ESCキーを押せなくする
    public static bool IsInConversation = false;




    void Start()
    {
      

      
       
        TextImage.enabled = false;
        GreenText.enabled = false;
        Kaogura.enabled = false;
        _playermove = FindAnyObjectByType<PlayerMove>();
        _sceneHand = FindAnyObjectByType<SceneStartHandler>();

    }


    void Update()
    {
        // まず全部非表示にする
        NormalKao.enabled = false;
        KonwakuKao.enabled = false;
        NoImage.enabled = false;

        // 状態に応じて表示
        switch (_state)
        {
            case ImageState.None:
                NoImage.enabled = true;
                break;
            case ImageState.Normal:
                NormalKao.enabled = true;
                break;
            case ImageState.Konwaku:
                KonwakuKao.enabled = true;
                break;
        }

    }

   

  

    public void Savepower()
    {
        _savespeed = _playermove.speed;
        _playermove.speed = 0;
        _velospeed = _playermove.rb.velocity;
        _playermove.rb.simulated = false;
        _playermove.rb.Sleep();
    }
    public void Loadpower()
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
