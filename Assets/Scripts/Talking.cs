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
    [SerializeField] public ImageState _state;


    PlayerMove _playermove;

  


  

    //�v���C���[�̃X�s�[�h�ۑ��p
    float _savespeed;

    //�v���C���[�̑��x�ۑ��p
    Vector2 _velospeed;

    SceneStartHandler _sceneHand;


    //ESC�L�[�������Ȃ�����
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
        // �܂��S����\���ɂ���
        NormalKao.enabled = false;
        KonwakuKao.enabled = false;
        NoImage.enabled = false;

        // ��Ԃɉ����ĕ\��
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
        //��b�Ȃ�
        None,
        //�ʏ�
        Normal,
        //���f
        Konwaku,
    }
}
