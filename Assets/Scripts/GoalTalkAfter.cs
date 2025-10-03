using UnityEngine;
using UnityEngine.SceneManagement;
using static Talking;

public class GoalTalkAfter : MonoBehaviour
{
    /// <summary>
    /// �G���^�[����������
    /// </summary>
    int enter;

    //�X�^�[�g��ʂł̃t���O
    int startflag;

    //��x�Ɠ����Ȃ��悤�ɂ��邽�߂Ɏg��
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
                _talking.GreenText.text = "�c���́A���������Ď��̂ق��ɂ��ꂩ���Ȃ������H";
            }
            else if (enter == 2)
            {
                _talking._state = ImageState.Maccho;
                _talking.GreenText.text = "�H����c���O�ƁA���O��1.5�{���炢�̐g���̒j������Ă����B";
            }
            else if (enter == 3)
            {
                _talking._state = ImageState.Maccho;
                _talking.GreenText.text = "�j�͎������v���e�C���ƌ������牴���H�ׂ��܂����B";
            }
            else if (enter == 4)
            {
                _talking._state = ImageState.Normal;
                _talking.GreenText.text = "�c�B";

            }
            else if (enter == 5)
            {
                _talking.TextImage.enabled = false;
                _talking.Kaogura.enabled = false;
                _talking._state = ImageState.None;
                _talking.GreenText.text = "�ߏ�Ƃ��Ă̓}�b�`�������ƗU���ƁA�ǂ������d���̂��B����Ȃ��Ƃ��l���Ă�����Ƃɒ����Ă����B";

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

        //���������O���̏���

        // �����U�S����\���ɂ���

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
        _talking.GreenText.text = "���͂������ł邱�Ƃ��ł����B";
        startflag = 1;
        IsInConversation = true;
        SoundTantou.soundstay = true;
    }
}
