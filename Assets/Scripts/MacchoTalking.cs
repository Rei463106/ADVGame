using UnityEngine;
using UnityEngine.SceneManagement;

using static Talking;

public class MacchoTalking : MonoBehaviour
{
    Talking _talking;
    PlayerMove _playerMove;

    bool canTalk = false;        // �v���C���[���߂��ɂ��ĉ�b�\��
    bool inConversation = false; // ���ۂɉ�b����

    //�X�^�[�g�p
    int susumu;
    int enter;
    //�X�^�[�g�p�t���O
    public static int talker;

    //�S�[���p
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

        // ��b�J�n�i�܂�inConversation����Ȃ����j
        if (!inConversation && canTalk && Input.GetKeyDown(KeyCode.Return) && PlayerFlag.green == 0)
        {
            StartConversation();
            return; // �����ŏI���ɂ��Ď��t���[�����瑱���ɐi��
        }
        //green���P�ŁAgoal���Q�ł��鎞
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
                    // 2��ڂ�Enter�ł����ɗ���
                    _talking._state = ImageState.Konwaku;
                    _talking.GreenText.text = "������̂��I";
                }
                else if (exitenter == 2)
                {
                    Debug.Log("��b�I��");
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


        // ��b���̐i�s
        if (inConversation && Input.GetKeyDown(KeyCode.Return) && talker == 0)
        {
            enter++;

            if (susumu == 1)
            {
                if (enter == 1)
                {
                    // 2��ڂ�Enter�ł����ɗ���
                    _talking._state = ImageState.Konwaku;
                    _talking.GreenText.text = "���Ȃ��͂�����������H";
                }
                else if (enter == 2)
                {
                    Debug.Log("��b�I��");
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
        Talking.IsInConversation = true;   // ��b���t���OON
        enter = 0;
        susumu = 1;
        inConversation = true;

        _talking.Savepower();

        _talking.GreenText.enabled = true;
        _talking.TextImage.enabled = true;
        _talking.Kaogura.enabled = true;
        _talking._state = ImageState.Normal;

        // ���񃁃b�Z�[�W
        _talking.GreenText.text = "����ɂ��́c�B";

        Debug.Log("��b�J�n: ����ɂ��͕\��");
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

        // ���񃁃b�Z�[�W
        _talking.GreenText.text = "���O����������o����悤�ɂ��Ă�낤�B";
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
