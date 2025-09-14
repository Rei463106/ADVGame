using UnityEngine;
using UnityEngine.UI;

public class Talking : MonoBehaviour
{
    [Header("TextBox�̕\���p")]
    public Image TextImage;
    [Header("Text�̕\���p���̂P")]
    public Text GreenText;
    [Header("��O���̕\���p")]
    public Image Kaogura;
    [Header("��b���Ă��Ȃ����p")]
    public Image NoImage;
    [Header("�ʏ�̊�̕\���p")]
    public Image NormalKao;
    [Header("���f��̕\���p")]
    public Image KonwakuKao;
    //PlayerMove���g������
    [SerializeField] ImageState _state;


     PlayerMove _playermove;

    //�X�^�[�g��ʂł̃t���O
    int startflag;


    /// <summary>
    /// ��b��i�߂邽�߂̏���
    /// </summary>
    int susumu;

    /// <summary>
    /// �G���^�[����������
    /// </summary>
    int enter;

    //�v���C���[�̃X�s�[�h�ۑ��p
    float _savespeed;

    //�v���C���[�̑��x�ۑ��p
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
                GreenText.text = "�m�����͂����������Ă����悤�ȋC�����邯�ǁc�B";
            }
            else if (enter == 2)
            {
                GreenText.text = "�Ƃ肠�����������œ|��Ă�l�ɂł������Ă݂邩�B";
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
        //�Ȃ�ׂ�����q�\���ɂ��Ȃ��I�I
        if (susumu == 1 && Input.GetKeyDown(KeyCode.Return))
        {
            enter++;  // Enter�������ꂽ�񐔂��J�E���g

            if (enter == 1)
            {
                // 1��ڂ�Enter
                _state = ImageState.Konwaku;
                GreenText.text = "���Ȃ��͂�����������H";
            }
            else if (enter == 2)
            {
                // 2��ڂ�Enter
                GreenText.enabled = false;
                TextImage.enabled = false;
                Kaogura.enabled = false;
                _state = ImageState.None;
                PlayerFlag.green = 1;

                //������悤�ɂ��鏈��
                Loadpower();

            }
        }
        //���������O���̏���

        // �����U�S����\���ɂ���

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
        //�X�s�[�h�ۑ�����
        Savepower();
        if (PlayerFlag.green == 0)
        {
            GreenText.enabled = true;
            TextImage.enabled = true;
            Kaogura.enabled = true;
            _state = ImageState.Normal;
            GreenText.text = "����ɂ��́c�B";
            susumu = 1;

        }
    }

    public void StartMessage()
    {
        GreenText.enabled = true;
        TextImage.enabled = true;
        Kaogura.enabled = true;
        _state = ImageState.Normal;
        GreenText.text = "�c�B����H�����ǂ��H";
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
        //��b�Ȃ�
        None,
        //�ʏ�
        Normal,
        //���f
        Konwaku,
    }
}
