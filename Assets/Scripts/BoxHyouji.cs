using UnityEngine;
using UnityEngine.UI;

public class BoxHyouji : MonoBehaviour
{
    //���j���[�̔w�i
    [SerializeField] public Image _menuHaikei;
    //���j���[�̃{�b�N�X�i�z��j
    [SerializeField] public Image[] _menuBox;
    //���j���[�̃e�L�X�g�i�z��j
    [SerializeField] public Text[] _menuText;
    //���j���[�{�b�N�X��0�Ԗڂ̍��W�������Ă�
    Vector2 _boxPosition;
    //�e�L�X�g��0�Ԗڂ̍��W�������Ă�
    Vector2 _textPosition;
    //���ɂǂ̂��炢���W�����炷��
    [SerializeField] int _boxHeight = 10;
    //���ɂǂ̂��炢���W�����炷��
    [SerializeField] int _textHeight = 10;
    //�{�b�N�X��\���������̌��ʉ�
    [SerializeField]AudioClip _audioClip;

    AudioSource _audioSource;
    public bool IsMenuOpen { get; private set; } = false;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Hyouji()
    {
        IsMenuOpen = true;
        _menuHaikei.enabled = true;
        if (_audioClip != null && _audioSource != null)
            _audioSource.PlayOneShot(_audioClip);


        // Scene�ɒu����0�Ԗڂ̈ʒu����ɂ���ianchoredPosition�K�{�I�j
        //anchoredPosition�ɂ����炤�܂��s�����c
        Vector2 boxPos = _menuBox[0].rectTransform.anchoredPosition;
        Vector2 textPos = _menuText[0].rectTransform.anchoredPosition;

        for (int i = 0; i < _menuBox.Length; i++)
        {
            _menuBox[i].enabled = true;
            _menuBox[i].rectTransform.anchoredPosition = boxPos;

            _menuText[i].enabled = true;
            _menuText[i].rectTransform.anchoredPosition = textPos;

            // ���ɕ��ׂ�
            boxPos.y -= _boxHeight;
            textPos.y -= _boxHeight;
        }
    }


    public void Hihyouji()
    {
        //��\���̍ۂ̏���������
         IsMenuOpen = false;
        if (_audioClip != null && _audioSource != null)
            _audioSource.PlayOneShot(_audioClip);

        for (int i = 0; i < _menuBox.Length; i++)
        {
            _menuBox[i].enabled = false;
            _menuText[i].enabled = false;

        }
        _menuHaikei.enabled = false;
    }

}
