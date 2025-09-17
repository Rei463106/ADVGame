using System.Collections;
using System.Collections.Generic;
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
    private static bool hasShownStartMessage = false;

    Talking _talking;
    GoalTalk _sceneHandler;



    void Start()
    {
        _talking = FindAnyObjectByType<Talking>();
        _sceneHandler = FindAnyObjectByType<GoalTalk>();

        if (!hasShownStartMessage)
        {
            GoalMessage();
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
                _talking.GreenText.text = "���̓�̃}�b�`�������͉��������̂��낤�H";
            }
            else if (enter == 2)
            {
                _talking.GreenText.text = "�c���������āA���������ɘA��Ă����̂��āc�B";
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

        _talking.GreenText.enabled = true;
        _talking.TextImage.enabled = false;
        _talking.Kaogura.enabled = false;
        _talking._state = ImageState.None;
        _talking.GreenText.text = "���͂������ł邱�Ƃ��ł����B";
        startflag = 1;
        IsInConversation = true;
    }
}
