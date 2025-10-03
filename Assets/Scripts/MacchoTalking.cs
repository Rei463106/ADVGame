using UnityEngine;
using UnityEngine.SceneManagement;

using static Talking;

public class MacchoTalking : MonoBehaviour
{
    Talking _talking;
    PlayerMove _playerMove;

    bool canTalk = false;        // プレイヤーが近くにいて会話可能か
    bool inConversation = false; // 実際に会話中か

    //スタート用
    int susumu;
    int enter;
    //スタート用フラグ
    public static int talker;

    //ゴール用
    int exitsusumu;
    int exitenter;

    public int randomNumber;
    public static int randomtalking;
    public static int talkto;

    void Start()
    {
        randomNumber = Random.Range(0, 2);

        _talking = FindAnyObjectByType<Talking>();
        _playerMove = FindAnyObjectByType<PlayerMove>();
        susumu = 0;
        enter = 0;
        exitsusumu = 0;
        exitenter = 0;

        talker = 0;
        randomtalking = 0;

        _talking.TextImage.enabled = false;
        _talking.GreenText.enabled = false;
        _talking.Kaogura.enabled = false;
    }

    void Update()
    {
        randomNumber = Random.Range(0, 2);

        if (!inConversation)
        {
            _talking.NormalKao.enabled = false;
            _talking.KonwakuKao.enabled = false;
            _talking.MacchoKao.enabled = false;
            _talking.TankobuKao.enabled = false;

        }
       

        // 会話開始（まだinConversationじゃない時）
        if (!inConversation && canTalk && Input.GetKeyDown(KeyCode.Z) && PlayerFlag.green == 0)
        {
            StartConversation();
            return; // ここで終わりにして次フレームから続きに進む
        }
        //greenが１で、goalが２である時
        if (!inConversation && canTalk && Input.GetKeyDown(KeyCode.Z) && PlayerFlag.green == 1 && PlayerFlag.goal == 2)
        {
            GoalConversation(); return;
        }
        //if (!inConversation && canTalk && Input.GetKeyDown(KeyCode.Z) && PlayerFlag.green == 1&&talkto==1||talkto==2)
        //{
        //    //talktoが3でないとゴールには行けない。
        //    MiddleConversation(); return;
        //}
        if (inConversation && Input.GetKeyDown(KeyCode.Z) && talker == 1)
        {
            exitenter++;
            if (exitsusumu == 1)
            {
                if (exitenter == 1)
                {
                    // 2回目のEnterでここに来る
                    _talking._state = ImageState.Maccho;
                    _talking.GreenText.text = "下がるのだ！";
                }
                else if (exitenter == 2)
                {
                    Debug.Log("会話終了");
                    _talking.GreenText.enabled = false;
                    _talking.TextImage.enabled = false;
                    _talking.Kaogura.enabled = false;
                    _talking._state = ImageState.None;
                    _talking.Loadpower();
                    inConversation = false;
                    IsInConversation = false;
                    SpriteRenderer spriteRenderer = GameObject.Find("Player").GetComponent<SpriteRenderer>();
                    spriteRenderer.enabled = false;
                    SceneManager.LoadScene("ED");
                }


            }


        }
        //if (Input.GetKeyDown(KeyCode.Z) && inConversation && randomNumber == 0&&randomtalking==1)
        //{
        //    exitenter++;
        //    if (exitsusumu == 1)
        //    {
        //        if (exitenter == 1)
        //        {
        //            Debug.Log("会話終了");
        //            _talking.GreenText.enabled = false;
        //            _talking.TextImage.enabled = false;
        //            _talking.Kaogura.enabled = false;
        //            _talking._state = ImageState.None;
        //            _talking.Loadpower();
        //            inConversation = false;
        //            IsInConversation = false;
        //            randomtalking = 0;

        //        }

        //    }
        //}
        //if (Input.GetKeyDown(KeyCode.Z) && inConversation && randomNumber == 1&&randomtalking==2)
        //{
        //    exitenter++;
        //    if (exitsusumu == 1)
        //    {
        //        if (exitenter == 1)
        //        {
        //            _talking._state = ImageState.Maccho;
        //            _talking.GreenText.text = "先週9歳になったばかりだ。";
        //        }
        //        else if (exitenter == 2)
        //        {
        //            _talking._state = ImageState.Normal;
        //            _talking.GreenText.text = "私よりは人生の後輩ってわけね。";

        //        }
        //        else if (exitenter == 3)
        //        {
        //            Debug.Log("会話終了");
        //            _talking.GreenText.enabled = false;
        //            _talking.TextImage.enabled = false;
        //            _talking.Kaogura.enabled = false;
        //            _talking._state = ImageState.None;
        //            PlayerFlag.green = 1;
        //            PlayerFlag.rightdoor = 1;

        //            _talking.Loadpower();
        //            inConversation = false;
        //            IsInConversation = false;
        //            randomtalking=0;
        //        }
        //    }
        //}

        // 会話中の進行
        if (inConversation && Input.GetKeyDown(KeyCode.Z) && talker == 0)
        {
            enter++;

            if (susumu == 1)
            {
                if (enter == 1)
                {
                    // 2回目のEnterでここに来る
                    _talking._state = ImageState.Maccho;
                    _talking.GreenText.text = "…な、なんだ…俺のかすむ視界の中に…おっさんが…";
                }
                else if (enter == 2)
                {
                    _talking._state = ImageState.Normal;
                    _talking.GreenText.text = "あの、ここから出たいんだけど。";
                }
                else if (enter == 3)
                {
                    _talking._state = ImageState.Tankobu;
                    _talking.GreenText.text = "ああ、それなら…";
                }
                else if (enter == 4)
                {
                    _talking._state = ImageState.Maccho;
                    _talking.GreenText.text = "俺にプロテインを持ってきてくれ。左右の部屋に一個ずつある。";
                }
                else if (enter == 5)
                {
                    _talking._state = ImageState.Maccho;
                    _talking.GreenText.text = "そしたら俺はこの埋まった下半身を引き抜く。その衝撃でここは崩れるだろう。";
                }
                else if (enter == 6)
                {
                    _talking._state = ImageState.Maccho;
                    _talking.GreenText.text = "左の部屋のカギは右の部屋においてあるからな。";
                }
                else if (enter == 7)
                {
                    _talking._state = ImageState.Normal;
                    _talking.GreenText.text = "はーい。";
                }
                else if (enter == 8)
                {
                    _talking._state = ImageState.Maccho;
                    _talking.GreenText.text = "今右の部屋を開けたから、まずはそっちに行ってくれ。";
                }
                else if (enter == 9)
                {
                    _talking._state = ImageState.Konwaku;
                    _talking.GreenText.text = "うん。(どうやって…？)";
                }
                else if (enter == 10)
                {
                    _talking._state = ImageState.Maccho;
                    _talking.GreenText.text = "後Xボタンでメニューを開ける。カーソルで選んで、Zで使うんだ。";
                }
                else if (enter == 11)
                {
                    _talking._state = ImageState.Konwaku;
                    _talking.GreenText.text = "（いきなりメタくなった…）";
                }
                else if (enter == 12)
                {
                    _talking._state = ImageState.Maccho;
                    _talking.GreenText.text = "プロテインを２つ使ったら勝手に効果が出る。そしたらまた話しかけてくれ。";
                }
                else if (enter == 13)
                {
                    Debug.Log("会話終了");
                    _talking.GreenText.enabled = false;
                    _talking.TextImage.enabled = false;
                    _talking.Kaogura.enabled = false;
                    _talking._state = ImageState.None;
                    PlayerFlag.green = 1;
                    PlayerFlag.rightdoor = 1;
                    talkto = 1;

                    _talking.Loadpower();
                    inConversation = false;
                    IsInConversation = false;

                }
               
            }
        }


        void StartConversation()
        {
            Talking.IsInConversation = true;   // 会話中フラグON
            enter = 0;
            susumu = 1;
            inConversation = true;

            _talking.Savepower();

            _talking.GreenText.enabled = true;
            _talking.TextImage.enabled = true;
            _talking.Kaogura.enabled = true;
            _talking._state = ImageState.Normal;

            // 初回メッセージ
            _talking.GreenText.text = "こんにちは。あなたが私のことを誘拐したの？";

            Debug.Log("会話開始: こんにちは表示");
        }

        void GoalConversation()
        {
            IsInConversation = true;
            exitenter = 0;
            exitsusumu = 1;

            inConversation = true;

            _talking.Savepower();

            _talking.GreenText.enabled = true;
            _talking.TextImage.enabled = true;
            _talking.Kaogura.enabled = true;
            _talking._state = ImageState.Maccho;

            // 初回メッセージ
            _talking.GreenText.text = "よし、腹がいっぱいになった。準備はいいな？";
        }
        //void MiddleConversation()
        //{
        //    IsInConversation = true;
        //    exitenter = 0;
        //    exitsusumu = 1;
            

        //    inConversation = true;

        //    _talking.Savepower();

        //    _talking.GreenText.enabled = true;
        //    _talking.TextImage.enabled = true;
        //    _talking.Kaogura.enabled = true;


        //    if (randomNumber == 0)
        //    {
        //        _talking._state = ImageState.Maccho;
        //        _talking.GreenText.text = "プロテインは使うだけで俺に効果が出る。二つあるからどっちも使用してくれ。";
        //        randomtalking = 1;

        //    }
        //    if (randomNumber == 1)
        //    {
        //        _talking._state = ImageState.Normal;
        //        _talking.GreenText.text = "あなたって何歳なの？";
        //        randomtalking = 2;
        //    }
        //}
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Macchoman"))
        {
            canTalk = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Macchoman"))
        {
            canTalk = false;
        }
    }
}
