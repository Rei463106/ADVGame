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

    void Start()
    {

        _talking = FindAnyObjectByType<Talking>();
        _playerMove = FindAnyObjectByType<PlayerMove>();
        susumu = 0;
        enter = 0;
        exitsusumu = 0;
        exitenter = 0;

        talker = 0;

        _talking.TextImage.enabled = false;
        _talking.GreenText.enabled = false;
        _talking.Kaogura.enabled = false;
    }

    void Update()
    {
        if (!inConversation)
        {
            _talking.NormalKao.enabled = false;
            _talking.KonwakuKao.enabled = false;
        }

        // 会話開始（まだinConversationじゃない時）
        if (!inConversation && canTalk && Input.GetKeyDown(KeyCode.Return) && PlayerFlag.green == 0)
        {
            StartConversation();
            return; // ここで終わりにして次フレームから続きに進む
        }
        //greenが１で、goalが２である時
        if (!inConversation && canTalk && Input.GetKeyDown(KeyCode.Return) && PlayerFlag.green == 1 && PlayerFlag.goal == 2)
        {
            GoalConversation(); return;
        }
        if (inConversation && Input.GetKeyDown(KeyCode.Return) && talker == 1)
        {
            exitenter++;
            if (exitsusumu == 1)
            {
                if (exitenter == 1)
                {
                    // 2回目のEnterでここに来る
                    _talking._state = ImageState.Konwaku;
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
                    SpriteRenderer spriteRenderer=GameObject.Find("Player").GetComponent<SpriteRenderer>();
                    spriteRenderer.enabled = false;
                    SceneManager.LoadScene("ED");
                }


            }


        }


        // 会話中の進行
        if (inConversation && Input.GetKeyDown(KeyCode.Return) && talker == 0)
        {
            enter++;

            if (susumu == 1)
            {
                if (enter == 1)
                {
                    // 2回目のEnterでここに来る
                    _talking._state = ImageState.Konwaku;
                    _talking.GreenText.text = "あなたはいったいだれ？";
                }
                else if (enter == 2)
                {
                    Debug.Log("会話終了");
                    _talking.GreenText.enabled = false;
                    _talking.TextImage.enabled = false;
                    _talking.Kaogura.enabled = false;
                    _talking._state = ImageState.None;
                    PlayerFlag.green = 1;
                    PlayerFlag.rightdoor = 1;

                    _talking.Loadpower();
                    inConversation = false;
                    IsInConversation = false;
                }
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
        _talking.GreenText.text = "こんにちは…。";

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
        _talking._state = ImageState.Normal;

        // 初回メッセージ
        _talking.GreenText.text = "お前をここから出られるようにしてやろう。";
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
