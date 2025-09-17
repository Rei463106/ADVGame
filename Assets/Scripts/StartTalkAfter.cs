using UnityEngine;
using static Talking;

public class StartTalkAfter : MonoBehaviour
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
                _talking.GreenText.text = "�m�����͂����������Ă����悤�ȋC�����邯�ǁc�B";
            }
            else if (enter == 2)
            {
                _talking.GreenText.text = "�Ƃ肠�����������œ|��Ă�l�ɂł������Ă݂邩�B";
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
    public void StartMessage()
    {
       
        _talking.GreenText.enabled = true;
        _talking.TextImage.enabled = true;
        _talking.Kaogura.enabled = true;
        _talking._state = ImageState.Normal;
        _talking.GreenText.text = "�c�B����H�����ǂ��H";
        startflag = 1;
        IsInConversation = true;
    }
}
